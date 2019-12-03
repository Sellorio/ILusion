using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class IfNode : ConditionalNode
    {
        public IReadOnlyList<LogicNode> TrueStatements { get; internal set; }
        public IReadOnlyList<LogicNode> FalseStatements { get; internal set; }

        public IfNode(
            ValueNode condition,
            VariableDefinition conditionResultVariable,
            IEnumerable<LogicNode> trueStatements,
            IEnumerable<LogicNode> falseStatements,
            IEnumerable<LogicNode> children)
            : base(condition, conditionResultVariable, children)
        {
            TrueStatements = ImmutableArray.CreateRange(trueStatements);
            FalseStatements = falseStatements == null ? null : (IReadOnlyList<LogicNode>)ImmutableArray.CreateRange(falseStatements);
        }
    }
}
