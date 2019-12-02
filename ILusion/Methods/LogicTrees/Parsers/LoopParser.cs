using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class LoopParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Brtrue,
            OpCodes.Brtrue_S
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
                return parsingContext.Success(new WhileNode(condition, conditionResultVariable, statements, children));
            }
            else
            {
                return parsingContext.Success(new DoWhileNode(condition, conditionResultVariable, statements, children));
            }
        }
    }
}
