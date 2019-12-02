using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class IfParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Brfalse,
            OpCodes.Brfalse_S
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var targetInstruction = (Instruction)parsingContext.Instruction.Operand;

            // this is a do-while loop
            if (targetInstruction.Offset < parsingContext.Instruction.Offset)
            {
                return false;
            }

            var condition = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children)[0];
            var conditionStartNode = NodeHelper.GetFirstRecursively(condition);
            var conditionStartInstruction = parsingContext.InstructionToNodeMapping.First(x => x.Value == conditionStartNode);

            var trueInstruction = parsingContext.Instruction.Next;
            var trueEndInstruction = targetInstruction;
            var falseInstruction = default(Instruction);
            var endInstruction = targetInstruction; // initially assuming no false block

            if (targetInstruction.Previous.OpCode == OpCodes.Br || targetInstruction.Previous.OpCode == OpCodes.Br_S)
            {
                // while loop
                if (targetInstruction.Previous.Operand == conditionStartInstruction.Key)
                {
                    return false;
                }

                trueEndInstruction = targetInstruction.Previous;
                falseInstruction = targetInstruction;
                endInstruction = (Instruction)targetInstruction.Previous.Operand;
            }

            var trueBlock = ParsingHelper.ParseBlock(parsingContext.Method, parsingContext.InstructionToNodeMapping, trueInstruction, trueEndInstruction);
            var falseBlock = falseInstruction != default ? ParsingHelper.ParseBlock(parsingContext.Method, parsingContext.InstructionToNodeMapping, falseInstruction, endInstruction) : null;

            var consumedInstructions = parsingContext.Method.Body.Instructions.Count(x => x.Offset >= parsingContext.Instruction.Offset && x.Offset < endInstruction.Offset);

            return parsingContext.Success(new IfNode(condition, trueBlock, falseBlock, children), consumedInstructions);
        }
    }
}
