using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class FieldNode : ValueNode
    {
        public FieldDefinition Field { get; }
        public ValueNode Instance { get; }

        internal override TypeReference GetValueType()
        {
            return Field.FieldType;
        }
    }
}
