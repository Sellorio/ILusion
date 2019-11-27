using System.Collections.Generic;
using System.Collections.Immutable;

namespace ILusion.Methods.LogicTrees
{
    public abstract class LogicNode
    {
        public IReadOnlyList<LogicNode> Children { get; }

        internal LogicNode(IEnumerable<LogicNode> children)
        {
            Children = ImmutableArray.CreateRange(children);
        }
    }
}
