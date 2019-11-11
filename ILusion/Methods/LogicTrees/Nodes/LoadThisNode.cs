using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class LoadThisNode : LogicNode
    {
        public bool AsReference { get; }

        internal override Instruction ToInstruction()
        {
            return AsReference ? Instruction.Create(OpCodes.Ldarga_S, 0) : Instruction.Create(OpCodes.Ldarg_0);
        }
    }
}
