using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class LiteralNode : ValueNode
    {
        private TypeReference _typeOfValue;
        public object Value { get; private set; }

        internal LiteralNode(TypeReference typeOfValue, object value)
            : base(new LogicNode[0])
        {
            _typeOfValue = typeOfValue;
            Value = value;
        }

        internal void ChangeValue(TypeReference typeOfValue, object value)
        {
            _typeOfValue = typeOfValue;
            Value = value;
        }

        internal override TypeReference GetValueType()
        {
            return _typeOfValue;
        }
    }
}
