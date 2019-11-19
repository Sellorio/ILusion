using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ParameterReferenceNode : ReferenceValueNode
    {
        public ParameterDefinition Parameter { get; }

        internal ParameterReferenceNode(ParameterDefinition parameter)
            : base(Enumerable.Empty<LogicNode>())
        {
            Parameter = parameter;
        }

        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(Parameter.Index > 255 ? OpCodes.Ldarga : OpCodes.Ldarga_S, Parameter.Index) };
        }

        internal override TypeReference GetValueType()
        {
            return new PointerType(Parameter.ParameterType);
        }
    }
}
