using System;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class CastNode : ValueNode
    {
        public ValueNode Value { get; }
        public TypeReference Type { get; }

        internal override Instruction[] ToInstructions()
        {
            var sourceType = Value.GetValueType();
            var objectType = Module.ImportReference(typeof(object));
            var resolvedTargetType = Type.Resolve();

            if (Type == objectType)
            {
                if (sourceType?.Resolve()?.IsClass != true)
                {
                    return new[] { Instruction.Create(OpCodes.Box) };
                }
            }
            else if (sourceType == objectType)
            {
                if (Type is GenericParameter || Type is GenericInstanceType)
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
    }
}
