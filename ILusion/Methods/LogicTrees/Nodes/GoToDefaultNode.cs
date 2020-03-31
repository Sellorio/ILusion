using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class GoToDefaultNode : LogicNode
    {
        internal GoToDefaultNode()
            : base(Enumerable.Empty<LogicNode>())
        {
        }
    }
}
