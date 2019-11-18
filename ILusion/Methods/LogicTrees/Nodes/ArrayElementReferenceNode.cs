using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ArrayElementReferenceNode : ReferenceValueNode
    {
        public ValueNode Array { get; }
        public ValueNode Index { get; }

        internal ArrayElementReferenceNode(ValueNode array, ValueNode index, IEnumerable<LogicNode> children)
            : base(children)
        {
            Array = array;
            Index = index;
        }

        internal override TypeReference GetValueType()
        {
            return new PointerType(((ArrayType)Array.GetValueType()).ElementType);
        }
    }
}
