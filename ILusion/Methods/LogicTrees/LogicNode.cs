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

        internal abstract Instruction[] ToInstructions();
    }
}
