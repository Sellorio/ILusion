using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ContinueNode : LogicNode
    {
        internal ContinueNode()
            : base(Enumerable.Empty<LogicNode>())
        {
        }
    }
}
