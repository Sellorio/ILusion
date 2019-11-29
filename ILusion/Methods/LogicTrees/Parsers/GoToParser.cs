using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
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

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            // branch is targetting the last (OpCode.Ret) instruction in a non-function
            if (method.ReturnType.FullName == typeof(void).FullName && instruction.Operand == method.Body.Instructions.Last())
            {
                node = null;
                consumedInstructions = 0;
                return false;
            }

            node = new GoToNode((Instruction)instruction.Operand);
            consumedInstructions = 1;
            return true;
        }
    }
}
