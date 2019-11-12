using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ArrayElementReferenceNode : ReferenceValueNode
    {
        public ValueNode Array { get; }
        public ValueNode Index { get; }

        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(OpCodes.Ldelema, ((ArrayType)Array.GetValueType()).ElementType) };
        }

        internal override TypeReference GetValueType()
        {
            return new PointerType(((ArrayType)Array.GetValueType()).ElementType);
        }
    }
}
