using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class FieldAssignmentNode : LogicNode
    {
        public FieldDefinition Field { get; }
        public ValueNode Instance { get; }
        public ValueNode Value { get; }
    }
}
