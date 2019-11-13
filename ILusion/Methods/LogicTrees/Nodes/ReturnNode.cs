using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ReturnNode : LogicNode
    {
        public ValueNode ReturnValue { get; }

        internal ReturnNode(ValueNode returnValue, IEnumerable<LogicNode> children)
            : base(children)
        {
            ReturnValue = returnValue;
        }
    }
}
