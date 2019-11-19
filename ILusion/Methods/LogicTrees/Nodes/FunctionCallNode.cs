using Mono.Cecil;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class FunctionCallNode : ValueNode
    {
        public MethodReference Method { get; }
        public ValueNode Instance { get; }
        public IReadOnlyList<ValueNode> Parameters { get; }
        public bool IsBaseCall { get; }
        public TypeReference ConstrainedModifier { get; }

        internal FunctionCallNode(
            MethodReference method,
            ValueNode instance,
            IEnumerable<ValueNode> parameters,
            bool isBaseCall,
            TypeReference constrainedModifier,
            IEnumerable<LogicNode> children)
            : base(children)
        {
            Method = method;
            Instance = instance;
            Parameters = ImmutableArray.CreateRange(parameters);
            IsBaseCall = isBaseCall;
            ConstrainedModifier = constrainedModifier;
        }

        internal override TypeReference GetValueType()
        {
            return Method.ReturnType;
        }
    }
}
