using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class NoOperationParser : IParser
    {
        public int Order => 0;

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Nop
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            return parsingContext.Success(new NoOperationNode());
        }
    }
}
