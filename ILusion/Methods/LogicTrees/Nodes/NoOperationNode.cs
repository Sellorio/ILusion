using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class NoOperationNode : LogicNode
    {
        internal NoOperationNode()
            : base(Enumerable.Empty<LogicNode>())
        {
        }
    }
}
