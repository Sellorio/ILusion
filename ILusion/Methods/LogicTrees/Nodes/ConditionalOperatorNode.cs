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
            var trueExpression = TrueExpression.OfType<ValueNode>().Single();

            if (trueExpression is LiteralNode literal && literal.Value == null)
            {
                return FalseExpression.OfType<ValueNode>().Single().GetValueType();
            }

            return trueExpression.GetValueType();
        }
    }
}
