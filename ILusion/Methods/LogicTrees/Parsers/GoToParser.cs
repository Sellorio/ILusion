using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
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
            // or, if the target is on the same level (interpreted as a while or do-while loop)
            if (parsingContext.Method.ReturnType.FullName == typeof(void).FullName && parsingContext.Instruction.Operand == parsingContext.Method.Body.Instructions.Last()
                || ((Instruction)parsingContext.Instruction.Operand).Offset < parsingContext.Instruction.Offset
                    && parsingContext.NodeStack.Select(NodeHelper.GetFirstRecursively).Contains(parsingContext.InstructionToNodeMapping[(Instruction)parsingContext.Instruction.Operand]))
            {
                return false;
            }

            return parsingContext.Success(new GoToNode((Instruction)parsingContext.Instruction.Operand));
        }
    }
}
