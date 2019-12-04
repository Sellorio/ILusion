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
            var endInstruction = targetInstruction; // False blocks will be parsed later

            var trueBlock = ParsingHelper.ParseBlock(parsingContext.Method, parsingContext.InstructionToNodeMapping, trueInstruction, trueEndInstruction);

            var consumedInstructions = parsingContext.Method.Body.Instructions.Count(x => x.Offset >= parsingContext.Instruction.Offset && x.Offset < endInstruction.Offset);

            return parsingContext.Success(new IfNode(condition, conditionResultVariable, trueBlock, null, children), consumedInstructions);
        }
    }
}
