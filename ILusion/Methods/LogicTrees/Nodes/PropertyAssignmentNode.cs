using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class PropertyAssignmentNode : LogicNode
    {
        public ValueNode Instance { get; }
        public ValueNode Value { get; }
        public PropertyDefinition Property { get; }
        public MethodReference SetMethod { get; }
        public bool IsBaseCall { get; }
        public TypeReference ConstrainedModifier { get; }

        internal PropertyAssignmentNode(
            ValueNode instance,
            ValueNode value,
            PropertyDefinition property,
            MethodReference setMethod,
            bool isBaseCall,
            TypeReference constrainedModifier,
            IEnumerable<LogicNode> children)
            : base(children)
        {
            Instance = instance;
            Value = value;
            Property = property;
            SetMethod = setMethod;
            IsBaseCall = isBaseCall;
            ConstrainedModifier = constrainedModifier;
        }
    }
}
