using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ILusion.Methods.LogicTrees
{
    public abstract class LoopNode : ConditionalNode
    {
        public IReadOnlyList<LogicNode> Statements { get; internal set; }

        internal LoopNode(
            ValueNode condition,
            VariableDefinition conditionResultVariable,
            IEnumerable<LogicNode> statements,
            IEnumerable<LogicNode> children)
            : base(condition, conditionResultVariable, children)
        {
            Statements = ImmutableArray.CreateRange(statements);
        }
    }
}
