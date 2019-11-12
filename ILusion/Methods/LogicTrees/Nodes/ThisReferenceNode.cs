using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ThisReferenceNode : ReferenceValueNode
    {
        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(OpCodes.Ldarga_S, 0) };
        }
    }
}
