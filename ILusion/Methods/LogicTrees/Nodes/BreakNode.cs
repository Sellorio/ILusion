using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class BreakNode : LogicNode
    {
        internal BreakNode()
            : base(Enumerable.Empty<LogicNode>())
        {
        }
    }
}
