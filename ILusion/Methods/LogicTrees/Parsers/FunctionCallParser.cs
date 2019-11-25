using System;
using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class FunctionCallParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Call,
            OpCodes.Callvirt,
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

            if (calledMethod == null
                || calledMethod.IsConstructor
                || calledMethod.IsGetter
                || calledMethod.IsSetter
                || calledMethod.ReturnType.FullName == "System.Void"
                || calledMethod.DeclaringType.FullName == typeof(Activator).FullName && calledMethod.Name == nameof(Activator.CreateInstance) && calledMethod.HasGenericParameters)
            {
                return false;
            }

            var expectedStackValues = calledMethod.IsStatic ? calledMethod.Parameters.Count : calledMethod.Parameters.Count + 1;
            var valueNodes = ParsingHelper.GetValueNodes(nodeStack, expectedStackValues, out var nodes);

            // Callvirt is used for all instance method calls, not just virtual ones. See here for reason:
            // https://blogs.msdn.microsoft.com/ericgu/2008/07/02/why-does-c-always-use-callvirt/
            var isBaseCall = instruction.OpCode == OpCodes.Call && !calledMethod.IsStatic && !calledMethod.DeclaringType.IsValueType;

            if (!calledMethod.IsStatic && calledMethod.DeclaringType.FullName == typeof(bool).FullName)
            {
                ParsingHelper.HandleBooleanLiteral(method, valueNodes[0]);
            }

            var parameterNodes = calledMethod.IsStatic ? valueNodes : valueNodes.Skip(1).ToArray();

            for (var i = 0; i < parameterNodes.Length; i++)
            {
                if (calledMethod.Parameters[i].ParameterType.FullName == typeof(bool).FullName)
                {
                    ParsingHelper.HandleBooleanLiteral(method, parameterNodes[i]);
                }
            }

            node =
                new FunctionCallNode(
                    methodReference,
                    calledMethod.IsStatic ? null : valueNodes[0],
                    parameterNodes,
                    isBaseCall,
                    constrainedModifier,
                    nodes);

            consumedInstructions = constrainedModifier != null ? 2 : 1;

            return true;
        }
    }
}
