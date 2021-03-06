﻿using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class PropertyNode : ValueNode
    {
        public ValueNode Instance { get; }
        public PropertyDefinition Property { get; }
        public MethodReference GetMethod { get; }
        public bool IsBaseCall { get; }
        public TypeReference ConstrainedModifier { get; }

        internal PropertyNode(
            ValueNode instance,
            PropertyDefinition property,
            MethodReference getMethod,
            bool isBaseCall,
            TypeReference constrainedModifier,
            IEnumerable<LogicNode> children)
            : base(children)
        {
            Instance = instance;
            Property = property;
            GetMethod = getMethod;
            IsBaseCall = isBaseCall;
            ConstrainedModifier = constrainedModifier;
        }

        internal override TypeReference GetValueType()
        {
            return GetMethod.ReturnType;
        }
    }
}
