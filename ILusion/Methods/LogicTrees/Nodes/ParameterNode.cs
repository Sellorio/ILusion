using Mono.Cecil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ParameterNode : ValueNode
    {
        public ParameterDefinition Parameter { get; }

        internal ParameterNode(ParameterDefinition parameter)
            : base(Enumerable.Empty<LogicNode>())
        {
            Parameter = parameter;
        }

        internal override TypeReference GetValueType()
        {
            return Parameter.ParameterType;
        }
    }
}
