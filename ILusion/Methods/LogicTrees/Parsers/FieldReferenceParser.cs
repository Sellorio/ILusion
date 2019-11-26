﻿using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class FieldReferenceParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldflda,
            OpCodes.Ldsflda
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var field = (FieldReference)instruction.Operand;
            var isStatic = instruction.OpCode == OpCodes.Ldsflda;
            var valueNodes = ParsingHelper.GetValueNodes(nodeStack, isStatic ? 0 : 1, out var children);
            node = new FieldReferenceNode(isStatic ? null : valueNodes[0], field, children);
            consumedInstructions = 1;
            return true;
        }
    }
}
