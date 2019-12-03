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
            var statements = new List<LogicNode>();
            var isWhile = false;

            if ((targetInstruction.Previous?.OpCode == OpCodes.Br || targetInstruction.Previous?.OpCode == OpCodes.Br_S)
                && parsingContext.InstructionToNodeMapping[(Instruction)targetInstruction.Previous.Operand] == NodeHelper.GetFirstRecursively(condition))
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

            HandleBreak(parsingContext, statements, parsingContext.Instruction.Next);

            if (isWhile)
            {
                return parsingContext.Success(new WhileNode(condition, conditionResultVariable, statements, children));
            }
            else
            {
                return parsingContext.Success(new DoWhileNode(condition, conditionResultVariable, statements, children));
            }
        }

        private static void HandleBreak(ParsingContext parsingContext, List<LogicNode> statements, Instruction breakInstruction)
        {
            for (var i = 0; i < statements.Count; i++)
            {
                var statement = statements[i];

                if (statement is IfNode ifNode)
                {
                    ifNode.TrueStatements = HandleBreakInIf(parsingContext, ifNode, ifNode.TrueStatements, breakInstruction);
                    ifNode.FalseStatements = HandleBreakInIf(parsingContext, ifNode, ifNode.FalseStatements, breakInstruction);
                }
                else
                {
                    var newStatement = HandleBreak(parsingContext, statement, breakInstruction);

                    if (newStatement != statement)
                    {
                        statements[i] = newStatement;
                    }
                }
            }
        }

        private static IReadOnlyList<LogicNode> HandleBreakInIf(ParsingContext parsingContext, IfNode ifNode, IReadOnlyList<LogicNode> statements, Instruction breakInstruction)
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
                    subIfNode.TrueStatements = HandleBreakInIf(parsingContext, subIfNode, subIfNode.TrueStatements, breakInstruction);
                    subIfNode.FalseStatements = HandleBreakInIf(parsingContext, subIfNode, subIfNode.FalseStatements, breakInstruction);
                }
                else
                {
                    var newStatement = HandleBreak(parsingContext, statement, breakInstruction);

                    if (newStatement != statement)
                    {
                        editableStatements[i] = newStatement;
                    }
                }
            }

            return ImmutableArray.CreateRange(editableStatements);
        }

        private static LogicNode HandleBreak(ParsingContext parsingContext, LogicNode node, Instruction breakInstruction)
        {
            var result = node;

            if (node is GoToNode goTo && goTo.OriginalTarget == breakInstruction)
            {
                result = new BreakNode(breakInstruction);
            }
            else if (node is ReturnNode && breakInstruction.OpCode == OpCodes.Ret)
            {
                result = new BreakNode(null);
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
    }
}
