using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ThisNode : ValueNode
    {
        internal ThisNode()
            : base(Enumerable.Empty<LogicNode>())
        {
        }
    }
}
