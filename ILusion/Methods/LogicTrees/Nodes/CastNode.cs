using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class CastNode : ValueNode
    {
        public ValueNode Value { get; }
        public TypeReference Type { get; }

        /// <summary>
        /// For numeric casts which may result in an overflow, this specifies whether
        /// or not an <see cref="System.OverflowException"/> is thrown in case of an overflow.
        /// </summary>
        public bool ThrowOnOverflow { get; }

        internal CastNode(ValueNode value, TypeReference type, bool throwOnOverflow, IEnumerable<LogicNode> children)
            : base(children)
        {
            Value = value;
            Type = type;
            ThrowOnOverflow = throwOnOverflow;
        }

        internal override TypeReference GetValueType()
        {
            return Type;
        }
    }
}
