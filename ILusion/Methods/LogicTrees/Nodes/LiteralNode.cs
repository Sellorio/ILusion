using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class LiteralNode : ValueNode
    {
        public object Value { get; }

        internal LiteralNode(object value)
            : base(new LogicNode[0])
        {
            Value = value;
        }

        internal override object GetValue()
        {
            return Value;
        }

        internal override TypeReference GetValueType()
        {
            return Module.ImportReference(Value.GetType());
        }
    }
}
