﻿using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Methods.LogicTrees.Nodes.ControlBlocks;
using ILusion.Methods.LogicTrees.Nodes.ControlBlocks.Switch;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Parsers.ControlBlocks.Switch
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
            OpCodes.Switch
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            if (IsAtSwitch(parsingContext.Method, parsingContext.Instruction, out var instructionDepth))
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
                    || TryParseBranchClump(method, ref currentInstruction, temporaryVariable.VariableType, switchCases);

                if (result)
                {
                    instruction = currentInstruction;

                    // clumps are separated by a branch to the next instruction
                    if ((instruction.OpCode == OpCodes.Br || instruction.OpCode == OpCodes.Br_S) &&
                        instruction.Operand == instruction.Next)
                    {
                        var instructionCopy = instruction;
                        // when the last case of a type switch is a struct or generic with variable, there is no br to end/default so we need to look up for the last brfalse
                        if (switchCases.Any(x => x.BodyStartInstruction == instructionCopy))
                        {
                            while (instruction.OpCode != OpCodes.Brfalse && instruction.OpCode != OpCodes.Brfalse_S)
                            {
                                instruction = instruction.Previous;
                            }
                        }
                        else
                        {
                            instruction = instruction.Next;
                        }
                    }
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

        private static bool TryParseBranchClump(MethodDefinition method, ref Instruction instruction, TypeReference valueType, List<SwitchCaseHeader> switchCases)
        {
            var valueTypeName = valueType.FullName;

            if (valueType.FullName == typeof(string).FullName)
            {
                return TryParseStringBranchClump(ref instruction, switchCases);
            }
            else if (valueType.FullName == typeof(decimal).FullName)
            {
                return TryParseDecimalBranchClump(ref instruction, switchCases);
            }
            else if (
                valueType.FullName == typeof(float).FullName ||
                valueType.FullName == typeof(double).FullName)
            {
                return TryParseFloatingPointBranchClump(ref instruction, switchCases);
            }
            else if (
                valueType.FullName == typeof(byte).FullName ||
                valueTypeName == typeof(sbyte).FullName ||
                valueTypeName == typeof(short).FullName ||
                valueTypeName == typeof(ushort).FullName ||
                valueTypeName == typeof(int).FullName ||
                valueTypeName == typeof(uint).FullName ||
                valueTypeName == typeof(long).FullName ||
                valueTypeName == typeof(ulong).FullName ||
                valueType.Resolve()?.IsEnum == true)
            {
                return TryParseIntegerBranchClump(ref instruction, valueType, switchCases);
            }
            else
            {
                return TryParseTypeBranchClump(method, ref instruction, switchCases); // type switch
            }
        }

        private static bool TryParseStringBranchClump(ref Instruction instruction, List<SwitchCaseHeader> switchCases)
        {
            var value = instruction.Operand;

            if (instruction.OpCode == OpCodes.Brfalse || instruction.OpCode == OpCodes.Brfalse_S)
            {
                switchCases.Add(new SwitchCaseHeader { Value = null, BodyStartInstruction = (Instruction)instruction.Operand });
                instruction = instruction.Next;
                return true;
            }

            instruction = instruction.Next;

            if (instruction.OpCode != OpCodes.Call)
            {
                throw new ParsingException("Unable to parse string switch.");
            }

            instruction = instruction.Next;

            if (instruction.OpCode != OpCodes.Brtrue && instruction.OpCode != OpCodes.Brtrue_S)
            {
                throw new ParsingException("Unable to parse string switch.");
            }

            switchCases.Add(new SwitchCaseHeader { Value = value, BodyStartInstruction = (Instruction)instruction.Operand });

            instruction = instruction.Next;

            return true;
        }

        private static bool TryParseDecimalBranchClump(ref Instruction instruction, List<SwitchCaseHeader> switchCases)
        {
            var decimalConstructorParameters = new List<int>();

            while (OpCodeHelper.LdcI4OpCodes.Contains(instruction.OpCode))
            {
                decimalConstructorParameters.Add(OpCodeHelper.GetInteger(instruction));
                instruction = instruction.Next;
            }

            var value = decimalConstructorParameters.Count switch
            {
                1 => new decimal(decimalConstructorParameters[0]),
                5 =>
                    new decimal(
                        decimalConstructorParameters[0],
                        decimalConstructorParameters[1],
                        decimalConstructorParameters[2],
                        decimalConstructorParameters[3] == 1,
                        (byte)decimalConstructorParameters[4]),
                _ => throw new ParsingException("Unable to parse decimal literal in switch.")
            };

            if (instruction.OpCode != OpCodes.Newobj)
            {
                throw new ParsingException("Unable to parse decimal switch.");
            }

            instruction = instruction.Next;

            if (instruction.OpCode != OpCodes.Call)
            {
                throw new ParsingException("Unable to parse decimal switch.");
            }

            instruction = instruction.Next;

            if (instruction.OpCode != OpCodes.Brtrue && instruction.OpCode != OpCodes.Brtrue_S)
            {
                throw new ParsingException("Unable to parse decimal switch.");
            }

            switchCases.Add(new SwitchCaseHeader { Value = value, BodyStartInstruction = (Instruction)instruction.Operand });

            instruction = instruction.Next;

            return true;
        }

        private static bool TryParseFloatingPointBranchClump(ref Instruction instruction, List<SwitchCaseHeader> switchCases)
        {
            if ((instruction.OpCode == OpCodes.Ldc_R4 || instruction.OpCode == OpCodes.Ldc_R8) &&
                (instruction.Next.OpCode == OpCodes.Beq || instruction.Next.OpCode == OpCodes.Beq_S))
            {
                switchCases.Add(new SwitchCaseHeader { Value = instruction.Operand, BodyStartInstruction = (Instruction)instruction.Next.Operand });
                instruction = instruction.Next.Next;
                return true;
            }

            return false;
        }

        private static bool TryParseIntegerBranchClump(ref Instruction instruction, TypeReference valueType, List<SwitchCaseHeader> switchCases)
        {
            if (TryParseIntegerValueBranch(ref instruction, valueType, switchCases))
            {
                return true;
            }
            else if (
                (OpCodeHelper.LdcI4OpCodes.Contains(instruction.OpCode) || instruction.OpCode == OpCodes.Ldc_I8) &&
                (instruction.Next.OpCode == OpCodes.Bgt || instruction.Next.OpCode == OpCodes.Bgt_S))
            {
                var nextClumpInstruction = (Instruction)instruction.Next.Operand;
                instruction = instruction.Next.Next.Next;

                // parse the different values in this clump
                while (TryParseIntegerValueBranch(ref instruction, valueType, switchCases))
                {
                    // clumps are separated by a branch to the next instruction
                    if ((instruction.OpCode == OpCodes.Br || instruction.OpCode == OpCodes.Br_S) &&
                        instruction.Operand == instruction.Next)
                    {
                        instruction = instruction.Next;
                    }
                    else
                    {
                        break;
                    }

                    if (OpCodeHelper.LdlocOpCodes.Contains(instruction.OpCode))
                    {
                        instruction = instruction.Next;
                    }
                }

                instruction = nextClumpInstruction;
                return true;
            }

            return false;
        }

        private static bool TryParseIntegerValueBranch(ref Instruction instruction, TypeReference valueType, List<SwitchCaseHeader> switchCases)
        {
            var resolvedValueType = valueType.Resolve();

            // when testing against zero, Brfalse is used instead of Ldc+Beq
            if (instruction.OpCode == OpCodes.Brfalse || instruction.OpCode == OpCodes.Brfalse_S)
            {
                object caseValue =
                    resolvedValueType?.IsEnum != true
                        ? (object)0
                        : resolvedValueType.Fields.First(x => 0.Equals(x.Constant));

                switchCases.Add(new SwitchCaseHeader { Value = caseValue, BodyStartInstruction = (Instruction)instruction.Operand });
                instruction = instruction.Next;
                return true;
            }
            else if (
                OpCodeHelper.LdcI4OpCodes.Contains(instruction.OpCode) &&
                (instruction.Next.OpCode == OpCodes.Beq || instruction.Next.OpCode == OpCodes.Beq_S))
            {
                var integerValue = OpCodeHelper.GetInteger(instruction);
                object caseValue =
                    resolvedValueType?.IsEnum != true
                        ? (object)integerValue
                        : resolvedValueType.Fields.First(x => integerValue.Equals(x.Constant));

                switchCases.Add(new SwitchCaseHeader { Value = caseValue, BodyStartInstruction = (Instruction)instruction.Next.Operand });
                instruction = instruction.Next.Next;
                return true;
            }
            else if (
                instruction.OpCode == OpCodes.Ldc_I8 &&
                (instruction.Next.OpCode == OpCodes.Beq || instruction.Next.OpCode == OpCodes.Beq_S))
            {
                var instructionCopy = instruction;

                object caseValue =
                    resolvedValueType?.IsEnum != true
                        ? instruction.Operand
                        : resolvedValueType.Fields.First(x => instructionCopy.Operand.Equals(x.Constant));

                switchCases.Add(new SwitchCaseHeader { Value = caseValue, BodyStartInstruction = (Instruction)instruction.Next.Operand });
                instruction = instruction.Next.Next;
                return true;
            }

            return false;
        }

        private static bool TryParseTypeBranchClump(MethodDefinition method, ref Instruction instruction, List<SwitchCaseHeader> switchCases)
        {
            var targetType = (TypeReference)instruction.Operand;

            instruction = instruction.Next;

            if (instruction.OpCode == OpCodes.Brfalse || instruction.OpCode == OpCodes.Brfalse_S)
            {
                // when a value type case with a variable are used, the result of isinst is checked, then then the value is unboxed
                instruction = instruction.Next.Next.Next;
                var variable = OpCodeHelper.GetLocal(method, instruction);
                instruction = instruction.Next;

                switchCases.Add(new SwitchCaseHeader { BodyStartInstruction = (Instruction)instruction.Operand, Value = targetType, Variable = variable });

                instruction = instruction.Next;

                return true;
            }
            else
            {
                // generic class with variable will unbox
                if (instruction.OpCode == OpCodes.Unbox_Any)
                {
                    instruction = instruction.Next;
                }

                var variable =
                    OpCodeHelper.StlocOpCodes.Contains(instruction.OpCode)
                        ? OpCodeHelper.GetLocal(method, instruction)
                        : null;

                instruction = variable == null ? instruction : instruction.Next.Next;

                // generic class with variable will box the value again for the brtrue check
                if (instruction.OpCode == OpCodes.Box)
                {
                    instruction = instruction.Next;
                }

                if (instruction.OpCode != OpCodes.Brtrue && instruction.OpCode != OpCodes.Brtrue_S)
                {
                    throw new ParsingException("Unable to parse type switch.");
                }

                switchCases.Add(new SwitchCaseHeader { Value = targetType, Variable = variable, BodyStartInstruction = (Instruction)instruction.Operand });

                instruction = instruction.Next;
            }

            return true;
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

                // type switches with a variable branch to an unconditional branch which points to the next instruction
                if (value is TypeReference && switchCaseHeaders[i].Variable != null)
                {
                    startInstruction = startInstruction.Next;
                }

                var switchCaseStatements =
                    ParsingHelper.ParseBlock(parsingContext.Method, parsingContext.InstructionToNodeMapping, startInstruction, endInstruction)
                        .ToList();

                if (value == SwitchDefaultCase.CaseValue)
                {
                    result[i] = new SwitchDefaultCase(switchCaseStatements);
                }
                else if (value is TypeReference typeReference)
                {
                    result[i] = new SwitchTypeCase(typeReference, switchCaseHeaders[i].Variable, switchCaseStatements);
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
        /// <param name="method">The method being parsed.</param>
        /// <param name="instruction">The current instruction being parsed.</param>
        /// <param name="instructionDepth">How far into the switch statement the current instruction is. This is used to backtrack when parsing switches.</param>
        /// <returns>The result of the check.</returns>
        private static bool IsAtSwitch(MethodDefinition method, Instruction instruction, out int instructionDepth)
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
                (instruction.OpCode == OpCodes.Brfalse || instruction.OpCode == OpCodes.Brfalse_S) &&
                (instruction.Next.OpCode == OpCodes.Br || instruction.Next.OpCode == OpCodes.Br_S))
            {
                // integer branch mode with zero as the first case
                instructionDepth = 2;
                return true;
            }
            else if (
                IsDecimalBranch(instruction, out instructionDepth) ||
                IsStringBranch(instruction, out instructionDepth) ||
                IsTypeBranch(method, instruction, out instructionDepth))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsDecimalBranch(Instruction instruction, out int instructionDepth)
        {
            var currentInstructionAppearsToBeDecimalBranch =
                (instruction.OpCode == OpCodes.Brtrue || instruction.OpCode == OpCodes.Brtrue_S) &&
                instruction.Previous.OpCode == OpCodes.Call &&
                ((MethodReference)instruction.Previous.Operand).Name == "op_Equality" &&
                ((MethodReference)instruction.Previous.Operand).DeclaringType.FullName == "System.Decimal" &&
                instruction.Previous.Previous.OpCode == OpCodes.Newobj &&
                ((MethodReference)instruction.Previous.Previous.Operand).DeclaringType.FullName == "System.Decimal";

            if (currentInstructionAppearsToBeDecimalBranch && OpCodeHelper.LdlocOpCodes.Contains(instruction.Next.OpCode))
            {
                var currentInstruction = instruction.Next.Next;

                while (OpCodeHelper.LdcI4OpCodes.Contains(currentInstruction.OpCode))
                {
                    currentInstruction = currentInstruction.Next;
                }

                if (currentInstruction.OpCode == OpCodes.Newobj &&
                    ((MethodReference)currentInstruction.Operand).DeclaringType.FullName == typeof(decimal).FullName &&
                    currentInstruction.Next.OpCode == OpCodes.Call &&
                    ((MethodReference)currentInstruction.Next.Operand).Name == "op_Equality" &&
                    ((MethodReference)currentInstruction.Next.Operand).DeclaringType.FullName == "System.Decimal" &&
                    (currentInstruction.Next.Next.OpCode == OpCodes.Brtrue || currentInstruction.Next.Next.OpCode == OpCodes.Brtrue_S))
                {
                    instructionDepth = 4;

                    currentInstruction = instruction.Previous.Previous.Previous;

                    while (OpCodeHelper.LdcI4OpCodes.Contains(currentInstruction.OpCode))
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
            instructionDepth = 2;

            return
                OpCodeHelper.LdlocOpCodes.Contains(instruction.Previous.OpCode) &&
                instruction.Previous.OpCode == instruction.Next.OpCode &&
                instruction.Previous.Operand == instruction.Next.Operand &&
                instruction.Next.Next.OpCode == OpCodes.Ldstr;
        }

        private static bool IsTypeBranch(MethodDefinition method, Instruction instruction, out int instructionDepth)
        {
            var isTypeSwitchWithVariableDefinedForFirstTypeCheck =
                OpCodeHelper.LdlocOpCodes.Contains(instruction.Previous.OpCode) &&
                OpCodeHelper.StlocOpCodes.Contains(instruction.Previous.Previous.OpCode) &&
                OpCodeHelper.GetLocal(method, instruction.Previous) == OpCodeHelper.GetLocal(method, instruction.Previous.Previous) &&
                instruction.Previous.Previous.Previous.OpCode == OpCodes.Isinst &&
                instruction.Previous.Previous.Previous.Previous.OpCode == instruction.Next.OpCode &&
                instruction.Previous.Previous.Previous.Previous.Operand == instruction.Next.Operand;

            if (isTypeSwitchWithVariableDefinedForFirstTypeCheck)
            {
                instructionDepth = 5;
                return true;
            }

            var isTypeSwitchWithoutVariableDefinedForFirstTypeCheck =
                instruction.Previous.OpCode == OpCodes.Isinst &&
                instruction.Previous.Previous.OpCode == instruction.Next.OpCode &&
                instruction.Previous.Previous.Operand == instruction.Next.Operand;

            instructionDepth = 3;
            return isTypeSwitchWithoutVariableDefinedForFirstTypeCheck;
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
