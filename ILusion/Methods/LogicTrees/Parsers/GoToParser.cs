using System.Linq;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class GoToParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Br,
            OpCodes.Br_S
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            // branch is targetting the last (OpCode.Ret) instruction in a non-function
            if (parsingContext.Method.ReturnType.FullName == typeof(void).FullName && parsingContext.Instruction.Operand == parsingContext.Method.Body.Instructions.Last())
            {
                return false;
            }

            return parsingContext.Success(new GoToNode((Instruction)parsingContext.Instruction.Operand));
        }
    }
}
