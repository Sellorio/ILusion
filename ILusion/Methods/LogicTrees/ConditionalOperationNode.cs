using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees
{
    public abstract class ConditionalOperationNode : OperationNode
    {
        private readonly TypeReference _typeOfBoolean;

        internal ConditionalOperationNode(TypeReference typeOfBoolean, ValueNode leftOperand, ValueNode rightOperand, IEnumerable<LogicNode> children)
            : base(leftOperand, rightOperand, children)
        {
            _typeOfBoolean = typeOfBoolean;
        }

        internal override sealed TypeReference GetValueType()
        {
            return _typeOfBoolean;
        }
    }
}
