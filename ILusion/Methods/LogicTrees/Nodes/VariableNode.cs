using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class VariableNode : ValueNode
    {
        public VariableDefinition Variable { get; }

        internal VariableNode(VariableDefinition variable)
            : base(Enumerable.Empty<LogicNode>())
        {
            Variable = variable;
        }

        internal override TypeReference GetValueType()
        {
            return Variable.VariableType;
        }
    }
}
