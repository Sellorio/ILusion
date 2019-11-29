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

        public bool TryParse(ParsingContext parsingContext)
        {
            var instruction = parsingContext.Instruction;

            var constrainedModifier = instruction.OpCode == OpCodes.Constrained ? (TypeReference)instruction.Operand : null;

            if (constrainedModifier != null)
            {
                instruction = instruction.Next;
            }

            var methodReference = instruction?.Operand as MethodReference;
            var calledMethod = methodReference?.Resolve();

            if (calledMethod == null || !calledMethod.IsGetter)
            {
                return false;
            }

            var expectedStackValues = calledMethod.IsStatic ? 0 : 1;
            var valueNodes = ParsingHelper.GetValueNodes(parsingContext.NodeStack, expectedStackValues, out var nodes);

            var property = calledMethod.DeclaringType.Properties.First(x => x.GetMethod == calledMethod);
            var isBaseCall = instruction.OpCode == OpCodes.Call && !calledMethod.IsStatic && !calledMethod.DeclaringType.IsValueType && calledMethod.IsVirtual;

            return
                parsingContext.Success(
                    new PropertyNode(calledMethod.IsStatic ? null : valueNodes[0], property, methodReference, isBaseCall, constrainedModifier, nodes),
                    constrainedModifier != null ? 2 : 1);
        }
    }
}
