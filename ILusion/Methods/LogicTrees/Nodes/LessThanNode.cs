using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class LessThanNode : ConditionalOperationNode
    {
        internal LessThanNode(TypeReference typeOfBoolean, ValueNode leftOperand, ValueNode rightOperand, IEnumerable<LogicNode> children)
            : base(typeOfBoolean, leftOperand, rightOperand, children)
        {
        }
    }
}
