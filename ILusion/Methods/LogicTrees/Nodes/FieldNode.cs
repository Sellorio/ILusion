using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class FieldNode : ValueNode
    {
        public ValueNode Instance { get; }
        public FieldDefinition Field { get; }

        internal FieldNode(ValueNode instance, FieldDefinition field, IEnumerable<LogicNode> children)
            : base(children)
        {
            Instance = instance;
            Field = field;
        }

        internal override TypeReference GetValueType()
        {
            return Field.FieldType;
        }
    }
}
