using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class NoOperationNode : LogicNode
    {
        internal override Instruction ToInstruction()
        {
            return Instruction.Create(OpCodes.Nop);
        }
    }
}
