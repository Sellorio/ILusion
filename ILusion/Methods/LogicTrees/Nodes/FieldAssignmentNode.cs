using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class FieldAssignmentNode : LogicNode
    {
        public FieldDefinition Field { get; }
        public ValueNode Instance { get; }
        public ValueNode Value { get; }

        internal FieldAssignmentNode(FieldDefinition field, ValueNode instance, ValueNode value, IEnumerable<LogicNode> children)
            : base(children)
        {
            Field = field;
            Instance = instance;
            Value = value;
        }
    }
}
