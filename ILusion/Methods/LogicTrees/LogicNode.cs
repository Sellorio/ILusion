using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ILusion.Methods.LogicTrees
{
    public abstract class LogicNode
    {
        public IReadOnlyList<LogicNode> Children { get; }

        internal LogicNode(IEnumerable<LogicNode> children = null)
        {
            Children = ImmutableArray.CreateRange(children ?? new LogicNode[0]);
        }

        internal virtual Instruction[] ToInstructions()
        {
            throw new System.NotSupportedException("This method is being phased out in favour of Emitters.");
        }
    }
}
