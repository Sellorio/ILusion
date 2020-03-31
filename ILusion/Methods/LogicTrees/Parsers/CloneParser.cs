using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class CloneParser : IParser
    {
        public int Order => 0;

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Dup
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            return parsingContext.Success(new CloneNode(ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out _, popNodes: false)[0]));
        }
    }
}
