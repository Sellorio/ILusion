using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ArrayLengthNode : ValueNode
    {
        private readonly TypeReference _typeOfInt;
        public ValueNode Array { get; }
        public bool AsLong { get; }

        internal ArrayLengthNode(TypeReference typeOfInt, ValueNode array, bool asLong, IEnumerable<LogicNode> children)
            : base(children)
        {
            _typeOfInt = typeOfInt;
            Array = array;
            AsLong = asLong;
        }

        internal override TypeReference GetValueType()
        {
            return _typeOfInt;
        }
    }
}
