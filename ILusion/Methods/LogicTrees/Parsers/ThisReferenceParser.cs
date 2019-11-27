using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
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

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            if (instruction.OpCode == OpCodes.Ldarg_0 && !method.DeclaringType.IsValueType && instruction.Next?.OpCode != OpCodes.Ldobj
                || method.IsStatic
                || instruction.Operand != null && (int)instruction.Operand != 0)
            {
                node = null;
                consumedInstructions = 0;
                return false;
            }

            node = new ThisReferenceNode(method.DeclaringType);
            consumedInstructions = 1;
            return true;
        }
    }
}
