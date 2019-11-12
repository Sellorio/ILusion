using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ArrayLengthNode : ValueNode
    {
        public ValueNode Array { get; }

        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(OpCodes.Ldlen) };
        }

        internal override TypeReference GetValueType()
        {
            return Module.ImportReference(typeof(int));
        }
    }
}
