using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class BreakNode : BranchNode
    {
        internal BreakNode(Instruction originalTarget)
            : base(originalTarget)
        {
        }
    }
}
