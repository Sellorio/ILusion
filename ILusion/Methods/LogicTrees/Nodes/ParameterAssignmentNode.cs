using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ParameterAssignmentNode : LogicNode
    {
        public ValueNode Value { get; }
        public ParameterDefinition Parameter { get; }

        internal ParameterAssignmentNode(ValueNode value, ParameterDefinition parameter, IEnumerable<LogicNode> children)
            : base(children)
        {
            Value = value;
            Parameter = parameter;
        }
    }
}
