using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ArrayElementReferenceParser : IParser
    {
        public int Order => 0;

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldelema
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var valueNodes = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 2, out var children);
            return parsingContext.Success(new ArrayElementReferenceNode(valueNodes[0], valueNodes[1], children));
        }
    }
}
