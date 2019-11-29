using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ConditionalOperatorNode : ValueNode
    {
        public ValueNode Condition { get; }
        public IReadOnlyList<LogicNode> TrueExpression { get; }
        public IReadOnlyList<LogicNode> FalseExpression { get; }

        public ConditionalOperatorNode(
            ValueNode condition,
            IEnumerable<LogicNode> trueExpression,
            IEnumerable<LogicNode> falseExpression,
            IEnumerable<LogicNode> children)
            : base(children)
        {
            Condition = condition;
            TrueExpression = ImmutableArray.CreateRange(trueExpression);
            FalseExpression = ImmutableArray.CreateRange(falseExpression);
        }

        internal override TypeReference GetValueType()
        {
            return TrueExpression.OfType<ValueNode>().Single().GetValueType();
        }
    }
}
