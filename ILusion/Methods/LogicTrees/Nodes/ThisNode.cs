using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ThisNode : ValueNode
    {
        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(OpCodes.Ldarg_0) };
        }
    }
}
