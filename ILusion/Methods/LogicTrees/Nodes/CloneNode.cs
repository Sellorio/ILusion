using System.Linq;
using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class CloneNode : ValueNode
    {
        public ValueNode Value { get; }

        public CloneNode(ValueNode value)
            : base(Enumerable.Empty<LogicNode>())
        {
            Value = value;
        }

        internal override TypeReference GetValueType()
        {
            return Value.GetValueType();
        }
    }
}
