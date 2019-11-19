using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ArrayElementNode : ValueNode
    {
        public ValueNode Array { get; }
        public ValueNode Index { get; }

        internal ArrayElementNode(ValueNode array, ValueNode index, IEnumerable<LogicNode> children)
            : base(children)
        {
            Array = array;
            Index = index;
        }

        internal override TypeReference GetValueType()
        {
            return ((ArrayType)Array.GetValueType()).ElementType;
        }
    }
}
