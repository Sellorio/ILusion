using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class CastNode : ValueNode
    {
        private readonly TypeReference _typeOfObject;
        public ValueNode Value { get; }
        public TypeReference Type { get; }

        internal CastNode(TypeReference typeOfObject, ValueNode value, TypeReference type, IEnumerable<LogicNode> children)
            : base(children)
        {
            _typeOfObject = typeOfObject;
            Value = value;
            Type = type;
        }

        internal override Instruction[] ToInstructions()
        {
            var sourceType = Value.GetValueType();
            var resolvedTargetType = Type.Resolve();

            if (Type == _typeOfObject)
            {
                if (sourceType?.Resolve()?.IsClass != true)
                {
                    return new[] { Instruction.Create(OpCodes.Box) };
                }
            }
            else if (sourceType == _typeOfObject)
            {
                if (Type is GenericParameter)
                {
                    return new[] { Instruction.Create(OpCodes.Unbox_Any, Type) };
                }

                if (resolvedTargetType != null && !resolvedTargetType.IsClass)
                {
                    return new[]
                    {
                        Instruction.Create(OpCodes.Unbox, Type),
                        Instruction.Create(OpCodes.Ldobj)
                    };
                }
            }

            return new[] { Instruction.Create(OpCodes.Castclass, Type) };
        }

        internal override TypeReference GetValueType()
        {
            return Type;
        }
    }
}
