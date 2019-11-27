﻿using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class PropertyAssignmentParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Callvirt,
            OpCodes.Call,
            OpCodes.Constrained
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            node = default;
            consumedInstructions = default;

            var constrainedModifier = instruction.OpCode == OpCodes.Constrained ? (TypeReference)instruction.Operand : null;

            if (constrainedModifier != null)
            {
                instruction = instruction.Next;
            }

            var methodReference = instruction?.Operand as MethodReference;
            var calledMethod = methodReference?.Resolve();

            if (calledMethod == null || !calledMethod.IsSetter)
            {
                return false;
            }

            var expectedStackValues = calledMethod.IsStatic ? 1 : 2;
            var valueNodes = ParsingHelper.GetValueNodes(nodeStack, expectedStackValues, out var nodes);

            var property = calledMethod.DeclaringType.Properties.First(x => x.SetMethod == calledMethod);
            var isBaseCall = instruction.OpCode == OpCodes.Call && !calledMethod.IsStatic && !calledMethod.DeclaringType.IsValueType && calledMethod.IsVirtual;

            node =
                new PropertyAssignmentNode(
                    calledMethod.IsStatic ? null : valueNodes[0],
                    calledMethod.IsStatic ? valueNodes[0] : valueNodes[1],
                    property,
                    methodReference,
                    isBaseCall,
                    constrainedModifier,
                    nodes);

            consumedInstructions = constrainedModifier != null ? 2 : 1;

            return true;
        }
    }
}