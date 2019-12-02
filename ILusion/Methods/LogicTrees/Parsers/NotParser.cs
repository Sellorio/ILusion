using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class NotParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ceq
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var valueNodes = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 2, out var children, false);

            if (valueNodes[1] is LiteralNode literal
                && 0.Equals(literal.Value)
                && valueNodes[0] is ValueNode value
                && (value.GetValueType().FullName == typeof(bool).FullName))
            {
                ParsingHelper.GetValueNodes(parsingContext.NodeStack, 2, out _);

                return
                    parsingContext.Success(
                        new NotNode(
                            value,
                            parsingContext.Method.Module.ImportReference(typeof(bool)),
                            children.Except(new[] { valueNodes[1] })));
            }

            return false;
        }
    }
}
