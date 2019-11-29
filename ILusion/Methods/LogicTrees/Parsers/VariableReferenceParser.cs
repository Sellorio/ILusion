using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class VariableReferenceParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldloca,
            OpCodes.Ldloca_S
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            return parsingContext.Success(new VariableReferenceNode((VariableDefinition)parsingContext.Instruction.Operand));
        }
    }
}
