using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ConditionalOperatorParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Brtrue,
            OpCodes.Brtrue_S
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var targetInstruction = (Instruction)parsingContext.Instruction.Operand;

            // this is a do-while loop
            if (targetInstruction.Offset < parsingContext.Instruction.Offset)
            {
                return false;
            }

            var firstTrueBlockInstruction = targetInstruction;
            var firstFalseBlockInstruction = parsingContext.Instruction.Next;
            var endInstruction = (Instruction)firstTrueBlockInstruction.Previous.Operand;

            var trueBlock = ParsingHelper.ParseBlock(parsingContext.Method, parsingContext.InstructionToNodeMapping, firstTrueBlockInstruction, endInstruction);
            var falseBlock = ParsingHelper.ParseBlock(parsingContext.Method, parsingContext.InstructionToNodeMapping, firstFalseBlockInstruction, firstTrueBlockInstruction.Previous);
            var condition = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children)[0];

            var consumedInstructions = parsingContext.Method.Body.Instructions.Count(x => x.Offset >= parsingContext.Instruction.Offset && x.Offset < endInstruction.Offset);

            return parsingContext.Success(new ConditionalOperatorNode(condition, trueBlock, falseBlock, children), consumedInstructions);
        }
    }
}
