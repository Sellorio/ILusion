using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ThisReferenceParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldarga,
            OpCodes.Ldarga_S,
            OpCodes.Ldarg_0
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            if (parsingContext.Instruction.OpCode == OpCodes.Ldarg_0 && !parsingContext.Method.DeclaringType.IsValueType && parsingContext.Instruction.Next?.OpCode != OpCodes.Ldobj
                || parsingContext.Method.IsStatic
                || parsingContext.Instruction.Operand != null && (int)parsingContext.Instruction.Operand != 0)
            {
                return false;
            }

            return parsingContext.Success(new ThisReferenceNode(parsingContext.Method.DeclaringType));
        }
    }
}
