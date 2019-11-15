using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class DiscardNode : LogicNode
    {
        public ValueNode DiscardedValue { get; }

        internal DiscardNode(ValueNode discardedValue, IEnumerable<LogicNode> children)
            : base(children)
        {
            DiscardedValue = discardedValue;
        }
    }
}
