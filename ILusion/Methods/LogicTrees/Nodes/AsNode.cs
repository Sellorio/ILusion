using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class AsNode : ValueNode
    {
        public ValueNode Value { get; }
        public TypeReference TargetType { get; }

        internal AsNode(ValueNode value, TypeReference targetType, IEnumerable<LogicNode> children)
            : base(children)
        {
            Value = value;
            TargetType = targetType;
        }

        internal override TypeReference GetValueType()
        {
            return TargetType;
        }
    }
}
