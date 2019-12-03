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

            var condition = ParsingHelper.ParseConditionalNodeCondition(parsingContext.NodeStack, out var conditionResultVariable, out var children);

            var trueInstruction = parsingContext.Instruction.Next;
            var trueEndInstruction = targetInstruction;
            var falseInstruction = default(Instruction);
            var endInstruction = targetInstruction; // initially assuming no false block

            if (targetInstruction.Previous.OpCode == OpCodes.Br || targetInstruction.Previous.OpCode == OpCodes.Br_S)
            {
                var suspectedEndOfIf = (Instruction)targetInstruction.Previous.Operand;

                if (suspectedEndOfIf.Offset > targetInstruction.Offset
                    && suspectedEndOfIf.Previous.OpCode != OpCodes.Brtrue
                    && suspectedEndOfIf.Previous.OpCode != OpCodes.Brtrue_S)
                {
                    trueEndInstruction = targetInstruction.Previous;
                    falseInstruction = targetInstruction;
                    endInstruction = suspectedEndOfIf;
                }
            }

            var trueBlock = ParsingHelper.ParseBlock(parsingContext.Method, parsingContext.InstructionToNodeMapping, trueInstruction, trueEndInstruction);
            var falseBlock = falseInstruction != default ? ParsingHelper.ParseBlock(parsingContext.Method, parsingContext.InstructionToNodeMapping, falseInstruction, endInstruction) : null;

            var consumedInstructions = parsingContext.Method.Body.Instructions.Count(x => x.Offset >= parsingContext.Instruction.Offset && x.Offset < endInstruction.Offset);

            return parsingContext.Success(new IfNode(condition, conditionResultVariable, trueBlock, falseBlock, children), consumedInstructions);
        }
    }
}
