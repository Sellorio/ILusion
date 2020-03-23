using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ArrayElementParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldelem_Any,
            OpCodes.Ldelem_I,
            OpCodes.Ldelem_I1,
            OpCodes.Ldelem_I2,
            OpCodes.Ldelem_I4,
            OpCodes.Ldelem_I8,
            OpCodes.Ldelem_R4,
            OpCodes.Ldelem_R8,
            OpCodes.Ldelem_Ref,
            OpCodes.Ldelem_U1,
            OpCodes.Ldelem_U2,
            OpCodes.Ldelem_U4
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var valueNodes = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 2, out var children);
            return parsingContext.Success(new ArrayElementNode(valueNodes[0], valueNodes[1], children));
        }
    }
}
