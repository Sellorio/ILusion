using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class LessThanParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Clt,
            OpCodes.Clt_Un
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var values = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 2, out var children);
            var typeOfBoolean = parsingContext.Method.Module.ImportReference(typeof(bool));
            return parsingContext.Success(new LessThanNode(typeOfBoolean, values[0], values[1], children));
        }
    }
}
