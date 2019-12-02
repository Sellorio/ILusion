using System.Collections.Generic;
using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class NotNode : ValueNode
    {
        private readonly TypeReference _typeOfBoolean;

        public ValueNode Value { get; }

        internal NotNode(ValueNode value, TypeReference typeOfBoolean, IEnumerable<LogicNode> children)
            : base(children)
        {
            _typeOfBoolean = typeOfBoolean;
            Value = value;
        }

        internal override TypeReference GetValueType()
        {
            return _typeOfBoolean;
        }
    }
}
