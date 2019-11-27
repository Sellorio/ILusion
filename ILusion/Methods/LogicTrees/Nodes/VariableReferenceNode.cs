using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class VariableReferenceNode : ReferenceValueNode
    {
        public VariableDefinition Variable { get; }

        internal VariableReferenceNode(VariableDefinition variable)
            : base(new LogicNode[0])
        {
            Variable = variable;
        }

        internal override TypeReference GetValueType()
        {
            return new PointerType(Variable.VariableType);
        }
    }
}
