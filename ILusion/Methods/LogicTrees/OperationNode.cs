using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees
{
    public abstract class OperationNode : ValueNode
    {
        public ValueNode LeftOperand { get; }
        public ValueNode RightOperand { get; }

        internal OperationNode(ValueNode leftOperand, ValueNode rightOperand, IEnumerable<LogicNode> children)
            : base(children)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }

        internal override TypeReference GetValueType()
        {
            return LeftOperand.GetValueType();
        }
    }
}
