using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ThisParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldarg_0
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            if (parsingContext.Method.IsStatic || parsingContext.Instruction.OpCode != OpCodes.Ldarg_0 && (int)parsingContext.Instruction.Operand != 0)
            {
                return false;
            }

            var isStruct = parsingContext.Method.DeclaringType.IsValueType;

            int consumedInstructions;

            if (isStruct)
            {
                if (parsingContext.Instruction.Next?.OpCode == OpCodes.Ldobj)
                {
                    consumedInstructions = 2;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                consumedInstructions = 1;
            }

            return parsingContext.Success(new ThisNode(parsingContext.Method.DeclaringType), consumedInstructions);
        }
    }
}
