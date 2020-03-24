using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class AddNode : OperationNode
    {
        public bool ThrowOnOverflow { get; }

        public AddNode(ValueNode leftOperand, ValueNode rightOperand, bool throwOnOverflow, IEnumerable<LogicNode> children)
            : base(leftOperand, rightOperand, children)
        {
            ThrowOnOverflow = throwOnOverflow;
        }
    }
}
