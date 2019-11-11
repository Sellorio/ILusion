using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class LoadArrayLengthNode : ValueNode
    {
        internal override Instruction ToInstruction()
        {
            return Instruction.Create(OpCodes.Ldlen);
        }

        internal override TypeReference GetValueType()
        {
            return Module.ImportReference(typeof(int));
        }
    }
}
