using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class PropertyAssignmentParser : IParser
    {
        public int Order => 0;

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

            if (calledMethod == null || !calledMethod.IsSetter)
            {
                return false;
            }

            var expectedStackValues = calledMethod.IsStatic ? 1 : 2;
            var valueNodes = ParsingHelper.GetValueNodes(parsingContext.NodeStack, expectedStackValues, out var nodes);

            var property = calledMethod.DeclaringType.Properties.First(x => x.SetMethod == calledMethod);
            var isBaseCall = instruction.OpCode == OpCodes.Call && !calledMethod.IsStatic && !calledMethod.DeclaringType.IsValueType && calledMethod.IsVirtual;

            return
                parsingContext.Success(
                    new PropertyAssignmentNode(
                        calledMethod.IsStatic ? null : valueNodes[0],
                        calledMethod.IsStatic ? valueNodes[0] : valueNodes[1],
                        property,
                        methodReference,
                        isBaseCall,
                        constrainedModifier,
                        nodes),
                    constrainedModifier != null ? 2 : 1);
        }
    }
}
