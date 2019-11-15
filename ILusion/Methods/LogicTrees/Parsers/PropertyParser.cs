using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class PropertyParser : IParser
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

            var calledMethod = (instruction?.Operand as MethodReference)?.Resolve();

            if (calledMethod == null || !calledMethod.IsGetter)
            {
                return false;
            }

            var expectedStackValues = calledMethod.IsStatic ? 0 : 1;
            var valueNodes = ParsingHelper.GetValueNodes(nodeStack, expectedStackValues, out var nodes);

            // Callvirt is used for all instance method calls, not just virtual ones. See here for reason:
            // https://blogs.msdn.microsoft.com/ericgu/2008/07/02/why-does-c-always-use-callvirt/
            var isBaseCall = instruction.OpCode == OpCodes.Call && !calledMethod.IsStatic && !calledMethod.DeclaringType.IsValueType;

            var property = calledMethod.DeclaringType.Properties.First(x => x.GetMethod == calledMethod);

            node = new PropertyNode(calledMethod.IsStatic ? null : valueNodes[0], property, isBaseCall, constrainedModifier, nodes);
            consumedInstructions = constrainedModifier != null ? 2 : 1;

            return true;
        }
    }
}
