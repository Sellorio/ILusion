using System.Collections.Generic;
using System.Collections.Immutable;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class IfNode : LogicNode
    {
        public ValueNode Condition { get; }
        public IReadOnlyList<LogicNode> TrueStatements { get; }
        public IReadOnlyList<LogicNode> FalseStatements { get; }

        public IfNode(
            ValueNode condition,
            IEnumerable<LogicNode> trueStatements,
            IEnumerable<LogicNode> falseStatements,
            IEnumerable<LogicNode> children)
            : base(children)
        {
            Condition = condition;
            TrueStatements = ImmutableArray.CreateRange(trueStatements);
            FalseStatements = falseStatements == null ? null : (IReadOnlyList<LogicNode>)ImmutableArray.CreateRange(falseStatements);
        }
    }
}
