using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class FieldReferenceParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldflda,
            OpCodes.Ldsflda
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var field = (FieldReference)parsingContext.Instruction.Operand;
            var isStatic = parsingContext.Instruction.OpCode == OpCodes.Ldsflda;
            var valueNodes = ParsingHelper.GetValueNodes(parsingContext.NodeStack, isStatic ? 0 : 1, out var children);
            return parsingContext.Success(new FieldReferenceNode(isStatic ? null : valueNodes[0], field, children));
        }
    }
}
