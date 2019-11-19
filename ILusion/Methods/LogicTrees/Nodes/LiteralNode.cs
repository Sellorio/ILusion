using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class LiteralNode : ValueNode
    {
        private readonly TypeReference _typeOfValue;
        public object Value { get; }

        internal LiteralNode(TypeReference typeOfValue, object value)
            : base(new LogicNode[0])
        {
            _typeOfValue = typeOfValue;
            Value = value;
        }

        internal override object GetValue()
        {
            return Value;
        }

        internal override TypeReference GetValueType()
        {
            return _typeOfValue;
        }
    }
}
