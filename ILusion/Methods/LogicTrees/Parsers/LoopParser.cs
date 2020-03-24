using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class LoopParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Brtrue,
            OpCodes.Brtrue_S,
            OpCodes.Br,
            OpCodes.Br_S
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var targetInstruction = (Instruction)parsingContext.Instruction.Operand;

            // this is a conditional operator
            if (targetInstruction.Offset > parsingContext.Instruction.Offset)
            {
                return false;
            }

            var condition = ParsingHelper.ParseConditionalNodeCondition(parsingContext.NodeStack, out var conditionResultVariable, out var children);
            var firstConditionNode = NodeHelper.GetFirstRecursively(condition);
            var firstConditionInstruction = parsingContext.InstructionToNodeMapping.First(x => x.Value == firstConditionNode).Key;
            var statements = new List<LogicNode>();
            var isWhile = false;

            if ((targetInstruction.Previous?.OpCode == OpCodes.Br || targetInstruction.Previous?.OpCode == OpCodes.Br_S)
                && parsingContext.InstructionToNodeMapping[(Instruction)targetInstruction.Previous.Operand] == firstConditionNode)
            {
                isWhile = true;
            }

            if (!parsingContext.NodeStack.Select(NodeHelper.GetFirstRecursively).Contains(parsingContext.InstructionToNodeMapping[targetInstruction]))
            {
                // differenciates between go-to targeting previous line and a loop - since all statements in the loop would be on the stack
                return false;
            }

            while (true)
            {
                var node = parsingContext.NodeStack.Peek();
                var first = NodeHelper.GetFirstRecursively(node);
                var instruction = parsingContext.InstructionToNodeMapping.First(x => x.Value == first).Key;

                if (instruction.Offset >= targetInstruction.Offset)
                {
                    statements.Add(parsingContext.NodeStack.Pop());
                }
                else if (isWhile && instruction == targetInstruction.Previous)
                {
                    parsingContext.NodeStack.Pop();
                }
                else
                {
                    break;
                }
            }

            statements.Reverse();

            if (isWhile)
            {
                var lastStatement = statements.LastOrDefault();

                if (lastStatement is VariableAssignmentNode || lastStatement is ParameterAssignmentNode)
                {
                    var firstNodeOfAssignment = NodeHelper.GetFirstRecursively(lastStatement);
                    var firstInstructionOfAssignment = parsingContext.InstructionToNodeMapping.First(x => x.Value == firstNodeOfAssignment).Key;

                    HandleBreakAndContinue(parsingContext, statements, parsingContext.Instruction.Next, firstInstructionOfAssignment);

                    var initialAssignments = new List<LogicNode>();

                    while (parsingContext.NodeStack.Peek() is VariableAssignmentNode || parsingContext.NodeStack.Peek() is ParameterAssignmentNode)
                    {
                        initialAssignments.Add(parsingContext.NodeStack.Pop());
                    }

                    return parsingContext.Success(
                        new ForNode(
                            Enumerable.Reverse(initialAssignments),
                            condition,
                            conditionResultVariable,
                            lastStatement,
                            statements.Take(statements.Count - 1),
                            children));
                }
                else
                {
                    HandleBreakAndContinue(parsingContext, statements, parsingContext.Instruction.Next, firstConditionInstruction);
                    return parsingContext.Success(new WhileNode(condition, conditionResultVariable, statements, children));
                }
            }
            else
            {
                HandleBreakAndContinue(parsingContext, statements, parsingContext.Instruction.Next, firstConditionInstruction);
                return parsingContext.Success(new DoWhileNode(condition, conditionResultVariable, statements, children));
            }
        }

        private static void HandleBreakAndContinue(ParsingContext parsingContext, List<LogicNode> statements, Instruction breakInstruction, Instruction continueInstruction)
        {
            for (var i = 0; i < statements.Count; i++)
            {
                var statement = statements[i];

                if (statement is IfNode ifNode)
                {
                    ifNode.TrueStatements = HandleBreakAndContinueInIf(parsingContext, ifNode.TrueStatements, breakInstruction, continueInstruction);
                    ifNode.FalseStatements = HandleBreakAndContinueInIf(parsingContext, ifNode.FalseStatements, breakInstruction, continueInstruction);
                }
                else
                {
                    var newStatement = HandleBreakAndContinue(parsingContext, statement, breakInstruction, continueInstruction);

                    if (newStatement != statement)
                    {
                        statements[i] = newStatement;
                    }
                }
            }
        }

        private static LogicNode HandleBreakAndContinue(ParsingContext parsingContext, LogicNode node, Instruction breakInstruction, Instruction continueInstruction)
        {
            var result = node;

            if (node is GoToNode goTo)
            {
                if (goTo.OriginalTarget == breakInstruction)
                {
                    result = new BreakNode();
                }
                else if (goTo.OriginalTarget == continueInstruction)
                {
                    result = new ContinueNode();
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

        private static IReadOnlyList<LogicNode> HandleBreakAndContinueInIf(
            ParsingContext parsingContext,
            IReadOnlyList<LogicNode> statements,
            Instruction breakInstruction,
            Instruction continueInstruction)
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
                    subIfNode.TrueStatements = HandleBreakAndContinueInIf(parsingContext, subIfNode.TrueStatements, breakInstruction, continueInstruction);
                    subIfNode.FalseStatements = HandleBreakAndContinueInIf(parsingContext, subIfNode.FalseStatements, breakInstruction, continueInstruction);
                }
                else
                {
                    var newStatement = HandleBreakAndContinue(parsingContext, statement, breakInstruction, continueInstruction);

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
