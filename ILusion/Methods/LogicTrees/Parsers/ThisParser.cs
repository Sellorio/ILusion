using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ThisParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldarg_0
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            if (method.IsStatic || instruction.OpCode != OpCodes.Ldarg_0 && (int)instruction.Operand != 0)
            {
                node = null;
                consumedInstructions = 0;
                return false;
            }

            var isStruct = method.DeclaringType.IsValueType;

            if (isStruct)
            {
                if (instruction.Next?.OpCode == OpCodes.Ldobj)
                {
                    consumedInstructions = 2;
                }
                else
                {
                    node = null;
                    consumedInstructions = 0;
                    return false;
                }
            }
            else
            {
                consumedInstructions = 1;
            }

            node = new ThisNode(method.DeclaringType);
            return true;
        }
    }
}
