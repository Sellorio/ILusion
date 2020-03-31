using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class GoToParser : IParser
    {
        public int Order => 9999;

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Br,
            OpCodes.Br_S
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            return parsingContext.Success(new GoToNode((Instruction)parsingContext.Instruction.Operand));
        }
    }
}
