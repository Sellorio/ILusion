using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes.ControlBlocks.Switch
{
    public sealed class SwitchDefaultCase : SwitchCase
    {
        public static object CaseValue { get; } = new object();

        internal SwitchDefaultCase(IEnumerable<LogicNode> statements)
            : base(CaseValue, statements)
        {
        }
    }
}
