using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ParameterAssignmentParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Starg,
            OpCodes.Starg_S
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var value = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children)[0];
            return parsingContext.Success(new ParameterAssignmentNode(value, (ParameterDefinition)parsingContext.Instruction.Operand, children));
        }
    }
}
