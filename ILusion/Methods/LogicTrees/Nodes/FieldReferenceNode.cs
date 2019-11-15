using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class FieldReferenceNode : ReferenceValueNode
    {
        public FieldDefinition Field { get; }
        public ValueNode Instance { get; }

        internal FieldReferenceNode(ValueNode instance, FieldDefinition field, IEnumerable<LogicNode> children)
            : base(children)
        {
            Instance = instance;
            Field = field;
        }

        internal override TypeReference GetValueType()
        {
            return new PointerType(Field.FieldType);
        }
    }
}
