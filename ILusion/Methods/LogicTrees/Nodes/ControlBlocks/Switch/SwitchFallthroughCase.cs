using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes.ControlBlocks.Switch
{
    public sealed class SwitchFallthroughCase : SwitchCase
    {
        public SwitchCase Target { get; }

        internal SwitchFallthroughCase(object value, SwitchCase target)
            : base(value, Enumerable.Empty<LogicNode>())
        {
            Target = target;
        }
    }
}
