using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ReferenceAssignmentNode : LogicNode
    {
        public ReferenceValueNode Reference { get; }
        public ValueNode Value { get; }

        public ReferenceAssignmentNode(ReferenceValueNode reference, ValueNode value, IEnumerable<LogicNode> children)
            : base(children)
        {
            Reference = reference;
            Value = value;
        }
    }
}
