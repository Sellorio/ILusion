using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class GoToCaseNode : LogicNode
    {
        public object CaseValue { get; }

        internal GoToCaseNode(object caseValue)
            : base(Enumerable.Empty<LogicNode>())
        {
            CaseValue = caseValue;
        }
    }
}
