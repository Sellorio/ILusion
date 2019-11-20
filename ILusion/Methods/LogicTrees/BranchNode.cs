using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees
{
    public abstract class BranchNode : LogicNode
    {
        internal Instruction OriginalTarget { get; }
        public LogicNode Target { get; internal set; }

        internal BranchNode(Instruction originalTarget)
            : base(Enumerable.Empty<LogicNode>())
        {
            OriginalTarget = originalTarget;
        }
    }
}
