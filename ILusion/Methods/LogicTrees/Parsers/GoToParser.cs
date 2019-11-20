﻿using System.Collections.Generic;
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
            node = new GoToNode((Instruction)instruction.Operand);
            consumedInstructions = 1;
            return true;
        }
    }
}
