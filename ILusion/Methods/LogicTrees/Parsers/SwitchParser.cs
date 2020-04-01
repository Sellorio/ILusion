using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Methods.LogicTrees.Parsers.Data;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal sealed class SwitchParser : IParser
    {
        public int Order => 0;

        private static readonly string[] _switchableTypes =
        {
            typeof(byte).FullName,
            typeof(sbyte).FullName,
            typeof(short).FullName,
            typeof(ushort).FullName,
            typeof(int).FullName,
            typeof(uint).FullName,
            typeof(long).FullName,
            typeof(ulong).FullName
        };

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Beq,
            OpCodes.Beq_S,
            OpCodes.Brtrue,
            OpCodes.Brtrue_S,
            OpCodes.Brfalse,
            OpCodes.Brfalse_S,
            OpCodes.Bgt,
            OpCodes.Bgt_S,
            OpCodes.Bgt_Un,
            OpCodes.Bgt_Un_S,
            OpCodes.Switch
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            if (IsAtSwitch(parsingContext.Instruction, out var instructionDepth))
            {
                while (!(parsingContext.NodeStack.Peek() is VariableAssignmentNode))
                {
                    parsingContext.NodeStack.Pop();
                }

                var value = ((VariableAssignmentNode)parsingContext.NodeStack.Peek()).Value;
                var children = parsingContext.NodeStack.Peek().Children;
                parsingContext.NodeStack.Pop();

                var instruction = parsingContext.Instruction;
                var switchCaseHeaders = new List<SwitchCaseHeader>();

                for (var i = 0; i < instructionDepth; i++)
                {
                    instruction = instruction.Previous;
                }

                var temporaryVariable = OpCodeHelper.GetLocal(parsingContext.Method, instruction);

                instruction = instruction.Next; // skip assignment to temporary variable

                while (TryParseClump(parsingContext.Method, ref instruction, temporaryVariable, switchCaseHeaders))
                {
                    // keep trying to parse more clumps
                }

                var instructionAfterLastCase = (Instruction)instruction.Operand;
                var switchCases = ExpandSwitchCaseHeaders(parsingContext, switchCaseHeaders, instructionAfterLastCase);
                var endInstruction = EvaluateProbableEndInstruction(parsingContext, switchCaseHeaders, switchCases, instructionAfterLastCase);
                var defaultStartInstruction = instructionAfterLastCase == endInstruction ? null : instructionAfterLastCase;

                foreach (var switchCase in switchCases)
                {
                    var statements = switchCase.Statements.ToList();
                    HandleBreakAndGoToCase(parsingContext, statements, switchCaseHeaders, defaultStartInstruction, endInstruction);
                    switchCase.Statements = ImmutableArray.CreateRange(statements);
                }

                if (defaultStartInstruction != null)
                {
                    ParseDefaultCase(parsingContext, switchCaseHeaders, switchCases, defaultStartInstruction, endInstruction);
                }

                var consumedInstructions =
                    parsingContext.Method.Body.Instructions.IndexOf(endInstruction)
                    - parsingContext.Method.Body.Instructions.IndexOf(parsingContext.Instruction);

                return parsingContext.Success(new SwitchNode(value, temporaryVariable, switchCases, children), consumedInstructions);
            }

            return false;
        }

        private static bool TryParseClump(
            MethodDefinition method,
            ref Instruction instruction,
            VariableDefinition temporaryVariable,
            List<SwitchCaseHeader> switchCases)
        {
            if (OpCodeHelper.LdlocOpCodes.Contains(instruction.OpCode)
                && OpCodeHelper.GetLocal(method, instruction) == temporaryVariable)
            {
                var currentInstruction = instruction.Next;

                var result =
                    TryParseSwitchClump(ref currentInstruction, temporaryVariable.VariableType, switchCases)
                    || TryParseBranchClump(ref currentInstruction, temporaryVariable.VariableType, switchCases);

                if (result)
                {
                    instruction = currentInstruction;
                }

                return result;
            }

            return false;
        }

        private static bool TryParseSwitchClump(ref Instruction instruction, TypeReference valueType, List<SwitchCaseHeader> switchCases)
        {
            var resolvedValueType = valueType.Resolve();

            if (!_switchableTypes.Contains(valueType.FullName) && resolvedValueType?.IsEnum != true)
            {
                return false;
            }

            var offset = 0;
            var currentInstruction = instruction;

            if (OpCodeHelper.LdcI4OpCodes.Contains(currentInstruction.OpCode))
            {
                var magnitude = OpCodeHelper.GetInteger(currentInstruction);
                currentInstruction = currentInstruction.Next;

                if (currentInstruction.OpCode == OpCodes.Sub)
                {
                    offset = magnitude;
                }
                else if (currentInstruction.OpCode == OpCodes.Add)
                {
                    offset = -magnitude;
                }
                else
                {
                    return false;
                }

                currentInstruction = currentInstruction.Next;
            }

            if (currentInstruction.OpCode != OpCodes.Switch)
            {
                return false;
            }

            var switchInstructions = (Instruction[])currentInstruction.Operand;

            for (var i = 0; i < switchInstructions.Length; i++)
            {
                var integerValue = offset + i;

                object caseValue =
                    resolvedValueType?.IsEnum != true
                        ? (object)integerValue
                        : resolvedValueType.Fields.First(x => integerValue.Equals(x.Constant));

                switchCases.Add(new SwitchCaseHeader
                {
                    BodyStartInstruction = switchInstructions[i],
                    Value = caseValue
                });
            }

            instruction = currentInstruction.Next;

            // after a branch/switch, it always branches to the next instruction unconditionally, skip it
            if ((instruction.OpCode == OpCodes.Br || instruction.OpCode == OpCodes.Br_S)
                && instruction.Operand == instruction.Next)
            {
                instruction = instruction.Next;
            }

            return true;
        }

        private static bool TryParseBranchClump(ref Instruction instruction, TypeReference valueType, List<SwitchCaseHeader> switchCases)
        {
            return false;
        }

        private static List<SwitchCase> ExpandSwitchCaseHeaders(ParsingContext parsingContext, List<SwitchCaseHeader> switchCaseHeaders, Instruction firstInstructionAfterSwitch)
        {
            var result = new SwitchCase[switchCaseHeaders.Count + 1];

            for (var i = 0; i < switchCaseHeaders.Count; i++)
            {
                var value = switchCaseHeaders[i].Value;
                var startInstruction = switchCaseHeaders[i].BodyStartInstruction;

                var endInstruction =
                    i == switchCaseHeaders.Count - 1
                        ? firstInstructionAfterSwitch
                        : switchCaseHeaders.Skip(i + 1).OrderBy(x => x.BodyStartInstruction.Offset).First().BodyStartInstruction;

                // fake case (gaps produced by some Switch instructions and fallthrough to default)
                if (startInstruction == firstInstructionAfterSwitch)
                {
                    continue;
                }

                // fallthrough to case
                if (switchCaseHeaders.Skip(i + 1).Any(x => x.BodyStartInstruction == startInstruction))
                {
                    // will be replaced in next loop through - after all concrete SwitchCase items and SwitchDefaultCase have been added
                    continue;
                }

                var switchCaseStatements =
                    ParsingHelper.ParseBlock(parsingContext.Method, parsingContext.InstructionToNodeMapping, startInstruction, endInstruction)
                        .ToList();

                if (value == SwitchDefaultCase.CaseValue)
                {
                    result[i] = new SwitchDefaultCase(switchCaseStatements);
                }
                else
                {
                    result[i] = new SwitchCase(value, switchCaseStatements);
                }
            }

            // handle fallthrough cases
            for (var i = 0; i < switchCaseHeaders.Count; i++)
            {
                if (result[i] == null && switchCaseHeaders[i].BodyStartInstruction != firstInstructionAfterSwitch)
                {
                    var targetHeader = switchCaseHeaders.Last(x => x.BodyStartInstruction == switchCaseHeaders[i].BodyStartInstruction);
                    var target = result[switchCaseHeaders.IndexOf(targetHeader)];
                    result[i] = new SwitchFallthroughCase(switchCaseHeaders[i].Value, target);
                }
            }

            return result.Where(x => x != null).ToList();
        }

        private static Instruction EvaluateProbableEndInstruction(
            ParsingContext parsingContext,
            List<SwitchCaseHeader> switchCaseHeaders,
            IList<SwitchCase> switchCases,
            Instruction instructionAfterLastCase)
        {
            return
                switchCases
                    .Select(x => GetPossibleEndInstruction(parsingContext, switchCaseHeaders, x.Statements, instructionAfterLastCase))
                    .Where(x => x != null)
                    .OrderBy(x => x.Offset)
                    .FirstOrDefault() ?? instructionAfterLastCase;
        }

        private static Instruction GetPossibleEndInstruction(
            ParsingContext parsingContext,
            List<SwitchCaseHeader> switchCaseHeaders,
            IEnumerable<LogicNode> statements,
            Instruction instructionAfterLastCase)
        {
            var possibilities = new List<Instruction>();

            foreach (var statement in statements)
            {
                if (statement is GoToNode goTo)
                {
                    if (goTo.OriginalTarget.Offset > instructionAfterLastCase.Offset && switchCaseHeaders.All(x => x.BodyStartInstruction != goTo.OriginalTarget))
                    {
                        possibilities.Add(goTo.OriginalTarget);
                    }
                }
                else if (statement is ReturnNode returnNode)
                {
                    if (returnNode.ReturnValue == null)
                    {
                        possibilities.Add(parsingContext.Method.Body.Instructions.Last());
                    }
                }
                else if (statement is IfNode ifNode)
                {
                    possibilities.Add(GetPossibleEndInstruction(parsingContext, switchCaseHeaders, ifNode.TrueStatements, instructionAfterLastCase));

                    if (ifNode.FalseStatements != null)
                    {
                        possibilities.Add(GetPossibleEndInstruction(parsingContext, switchCaseHeaders, ifNode.TrueStatements, instructionAfterLastCase));
                    }
                }
            }

            return possibilities.OrderBy(x => x.Offset).FirstOrDefault();
        }

        private static void ParseDefaultCase(ParsingContext parsingContext, IList<SwitchCaseHeader> switchCaseHeaders, List<SwitchCase> switchCases, Instruction start, Instruction end)
        {
            var defaultCaseStatements =
                ParsingHelper.ParseBlock(parsingContext.Method, parsingContext.InstructionToNodeMapping, start, end)
                    .ToList();

            HandleBreakAndGoToCase(parsingContext, defaultCaseStatements, switchCaseHeaders, start, end);

            switchCases.Add(new SwitchDefaultCase(defaultCaseStatements));
        }

        /// <summary>
        /// Checks whether or not the current location is actually a switch staetment and not something simpler.
        /// </summary>
        /// <param name="instruction">The current instruction being parsed.</param>
        /// <param name="instructionDepth">How far into the switch statement the current instruction is. This is used to backtrack when parsing switches.</param>
        /// <returns>The result of the check.</returns>
        private static bool IsAtSwitch(Instruction instruction, out int instructionDepth)
        {
            if (instruction.OpCode == OpCodes.Switch)
            {
                if (instruction.Previous.OpCode == OpCodes.Sub)
                {
                    instructionDepth = 4;
                }
                else
                {
                    instructionDepth = 2;
                }

                return true;
            }
            else if (
                instruction.OpCode == OpCodes.Bgt ||
                instruction.OpCode == OpCodes.Bgt_S ||
                instruction.OpCode == OpCodes.Bgt_Un ||
                instruction.OpCode == OpCodes.Bgt_Un_S)
            {
                // this is used to skip between different clumps in integer switch statements
                instructionDepth = 3;
                return true;
            }
            else if (instruction.OpCode == OpCodes.Beq || instruction.OpCode == OpCodes.Beq_S)
            {
                // this is used for integers (when not using switch opcode, floats and doubles)
                instructionDepth = 3;
                return true;
            }
            else if (
                IsDecimalBranch(instruction, out instructionDepth) ||
                IsStringBranch(instruction, out instructionDepth))
            {
                return true;
            }
            else
            {
                return false; // Type branches not implemented yet.
            }
        }

        private static bool IsDecimalBranch(Instruction instruction, out int instructionDepth)
        {
            var currentInstructionAppearsToBeDecimalBranch =
                (instruction.OpCode == OpCodes.Brtrue || instruction.OpCode == OpCodes.Brtrue_S) &&
                instruction.Previous.OpCode == OpCodes.Call &&
                ((MethodReference)instruction.Previous.Operand).Name == "op_Equality" &&
                ((MethodReference)instruction.Previous.Operand).DeclaringType.FullName == "System.Decimal" &&
                instruction.Previous.Previous.OpCode == OpCodes.Call &&
                ((MethodReference)instruction.Previous.Previous.Operand).DeclaringType.FullName == "System.Decimal" &&
                ((MethodReference)instruction.Previous.Previous.Operand).ReturnType.FullName == "System.Decimal";

            if (currentInstructionAppearsToBeDecimalBranch &&
                OpCodeHelper.LdlocOpCodes.Contains(instruction.Next.OpCode) &&
                instruction.Next.Operand == instruction.Previous.Previous.Previous.Operand)
            {
                var currentInstruction = instruction.Next.Next;

                while (currentInstruction.OpCode.ToString().StartsWith("Ldc_I4"))
                {
                    currentInstruction = currentInstruction.Next;
                }

                if (currentInstruction.OpCode == OpCodes.Call &&
                    ((MethodReference)currentInstruction.Operand).DeclaringType.FullName == "System.Decimal" &&
                    ((MethodReference)currentInstruction.Operand).ReturnType.FullName == "System.Decimal" &&
                    (currentInstruction.Next.OpCode == OpCodes.Brtrue || currentInstruction.Next.OpCode == OpCodes.Brtrue_S))
                {
                    instructionDepth = 3;
                    currentInstruction = instruction.Previous.Previous;

                    while (currentInstruction.OpCode.ToString().StartsWith("Ldc_I4"))
                    {
                        currentInstruction = currentInstruction.Previous;
                        instructionDepth++;
                    }

                    return true;
                }
            }

            instructionDepth = 0;
            return false;
        }

        private static bool IsStringBranch(Instruction instruction, out int instructionDepth)
        {
            instructionDepth = 4;

            return
                (instruction.OpCode == OpCodes.Brtrue || instruction.OpCode == OpCodes.Brtrue_S) &&
                instruction.Previous.OpCode == OpCodes.Call &&
                ((MethodReference)instruction.Previous.Operand).Name == "op_Equality" &&
                ((MethodReference)instruction.Previous.Operand).DeclaringType.FullName == "System.String" &&
                instruction.Previous.Previous.OpCode == OpCodes.Ldstr &&
                OpCodeHelper.LdlocOpCodes.Contains(instruction.Previous.Previous.Previous.OpCode) &&
                OpCodeHelper.LdlocOpCodes.Contains(instruction.Next.OpCode) &&
                instruction.Next.Operand == instruction.Previous.Previous.Previous.Operand &&
                instruction.Next.Next.OpCode == OpCodes.Ldstr &&
                instruction.Next.Next.Next.OpCode == OpCodes.Call &&
                ((MethodReference)instruction.Next.Next.Next.Operand) == instruction.Previous.Operand &&
                (instruction.Next.Next.Next.Next.OpCode == OpCodes.Brtrue || instruction.Next.Next.Next.Next.OpCode == OpCodes.Brtrue_S);
        }

        private static void HandleBreakAndGoToCase(
            ParsingContext parsingContext,
            List<LogicNode> statements,
            IList<SwitchCaseHeader> switchCaseHeaders,
            Instruction defaultInstruction,
            Instruction breakInstruction)
        {
            for (var i = 0; i < statements.Count; i++)
            {
                var statement = statements[i];

                if (statement is IfNode ifNode)
                {
                    ifNode.TrueStatements = HandleBreakAndGoToCaseInIf(parsingContext, ifNode.TrueStatements, switchCaseHeaders, defaultInstruction, breakInstruction);
                    ifNode.FalseStatements = HandleBreakAndGoToCaseInIf(parsingContext, ifNode.FalseStatements, switchCaseHeaders, defaultInstruction, breakInstruction);
                }
                else
                {
                    var newStatement = HandleBreakAndGoToCase(parsingContext, statement, switchCaseHeaders, defaultInstruction, breakInstruction);

                    if (newStatement != statement)
                    {
                        statements[i] = newStatement;
                    }
                }
            }
        }

        private static LogicNode HandleBreakAndGoToCase(
            ParsingContext parsingContext,
            LogicNode node,
            IList<SwitchCaseHeader> switchCaseHeaders,
            Instruction defaultInstruction,
            Instruction breakInstruction)
        {
            var result = node;

            if (node is GoToNode goTo)
            {
                if (goTo.OriginalTarget == breakInstruction)
                {
                    result = new BreakNode();
                }
                else if (goTo.OriginalTarget == defaultInstruction)
                {
                    result = new GoToDefaultNode();
                }
                else
                {
                    foreach (var caseHeader in switchCaseHeaders)
                    {
                        if (goTo.OriginalTarget == caseHeader.BodyStartInstruction)
                        {
                            result = new GoToCaseNode(caseHeader.Value);
                            break;
                        }
                    }
                }
            }
            else if (node is ReturnNode && breakInstruction.OpCode == OpCodes.Ret)
            {
                result = new BreakNode();
            }

            if (result != node)
            {
                foreach (var key in parsingContext.InstructionToNodeMapping.Where(x => x.Value == node).Select(x => x.Key).ToList())
                {
                    parsingContext.InstructionToNodeMapping[key] = result;
                }
            }

            return result;
        }

        private static IReadOnlyList<LogicNode> HandleBreakAndGoToCaseInIf(
            ParsingContext parsingContext,
            IReadOnlyList<LogicNode> statements,
            IList<SwitchCaseHeader> switchCaseHeaders,
            Instruction defaultInstruction,
            Instruction breakInstruction)
        {
            if (statements == null)
            {
                return null;
            }

            var editableStatements = statements.ToList();

            for (var i = 0; i < statements.Count; i++)
            {
                var statement = statements[i];

                if (statement is IfNode subIfNode)
                {
                    subIfNode.TrueStatements = HandleBreakAndGoToCaseInIf(parsingContext, subIfNode.TrueStatements, switchCaseHeaders, defaultInstruction, breakInstruction);
                    subIfNode.FalseStatements = HandleBreakAndGoToCaseInIf(parsingContext, subIfNode.FalseStatements, switchCaseHeaders, defaultInstruction, breakInstruction);
                }
                else
                {
                    var newStatement = HandleBreakAndGoToCase(parsingContext, statement, switchCaseHeaders, defaultInstruction, breakInstruction);

                    if (newStatement != statement)
                    {
                        editableStatements[i] = newStatement;
                    }
                }
            }

            return ImmutableArray.CreateRange(editableStatements);
        }
    }
}
