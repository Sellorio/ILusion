using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ArrayElementAssignmentNode : LogicNode
    {
        public ValueNode Array { get; }
        public ValueNode Index { get; }
        public ValueNode Value { get; }

        internal ArrayElementAssignmentNode(ValueNode array, ValueNode index, ValueNode value, IEnumerable<LogicNode> children)
            : base(children)
        {
            Array = array;
            Index = index;
            Value = value;
        }
    }
}
