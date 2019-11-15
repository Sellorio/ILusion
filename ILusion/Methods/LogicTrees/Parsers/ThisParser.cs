﻿using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ThisParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldarg_0,
            OpCodes.Ldarg,
            OpCodes.Ldarg_S
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            if (method.IsStatic || instruction.OpCode != OpCodes.Ldarg_0 && (int)instruction.Operand != 0)
            {
                node = null;
                consumedInstructions = 0;
                return false;
            }

            node = new ThisNode();
            consumedInstructions = 1;
            return true;
        }
    }
}