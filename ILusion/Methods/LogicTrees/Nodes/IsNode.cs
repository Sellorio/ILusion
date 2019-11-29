using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class IsNode : ValueNode
    {
        private readonly TypeReference _typeOfBoolean;

        public ValueNode Value { get; }
        public TypeReference TargetType { get; }
        public VariableDefinition CastedVariable { get; }

        public IsNode(ValueNode value, TypeReference targetType, VariableDefinition castedVariable, TypeReference typeOfBoolean, IEnumerable<LogicNode> children)
            : base(children)
        {
            _typeOfBoolean = typeOfBoolean;
            TargetType = targetType;
            Value = value;
            CastedVariable = castedVariable;
        }

        internal override TypeReference GetValueType()
        {
            return _typeOfBoolean;
        }
    }
}
