using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ContinueNode : BranchNode
    {
        internal ContinueNode(Instruction originalTarget)
            : base(originalTarget)
        {
        }
    }
}
