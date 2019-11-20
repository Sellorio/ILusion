using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class GoToNode : BranchNode
    {
        internal GoToNode(Instruction originalTarget)
            : base(originalTarget)
        {
        }
    }
}
