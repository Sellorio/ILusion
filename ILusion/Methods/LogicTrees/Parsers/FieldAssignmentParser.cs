using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class FieldAssignmentParser : IParser
    {
        public int Order => 0;

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Stfld,
            OpCodes.Stsfld
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var isStatic = parsingContext.Instruction.OpCode == OpCodes.Stsfld;
            var valueNodes = ParsingHelper.GetValueNodes(parsingContext.NodeStack, isStatic ? 1 : 2, out var children);

            return
                parsingContext.Success(
                    new FieldAssignmentNode(
                        isStatic ? null : valueNodes[0],
                        valueNodes[isStatic ? 0 : 1],
                        (FieldReference)parsingContext.Instruction.Operand, children));
        }
    }
}
