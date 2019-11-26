using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class FieldAssignmentNode : LogicNode
    {
        public FieldReference Field { get; }
        public ValueNode Instance { get; }
        public ValueNode Value { get; }

        internal FieldAssignmentNode(ValueNode instance, ValueNode value, FieldReference field, IEnumerable<LogicNode> children)
            : base(children)
        {
            Field = field;
            Instance = instance;
            Value = value;
        }
    }
}
