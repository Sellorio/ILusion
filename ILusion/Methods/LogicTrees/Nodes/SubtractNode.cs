using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class SubtractNode : OperationNode
    {
        public bool ThrowOnOverflow { get; }

        internal SubtractNode(ValueNode leftOperand, ValueNode rightOperand, bool throwOnOverflow, IEnumerable<LogicNode> children)
            : base(leftOperand, rightOperand, children)
        {
            ThrowOnOverflow = throwOnOverflow;
        }
    }
}
