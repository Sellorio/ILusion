using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees
{
    public abstract class ConditionalNode : LogicNode
    {
        public VariableDefinition ConditionResultVariable { get; }
        public ValueNode Condition { get; }

        internal ConditionalNode(
            ValueNode condition,
            VariableDefinition conditionResultVariable,
            IEnumerable<LogicNode> children)
            : base(children)
        {
            Condition = condition;
            ConditionResultVariable = conditionResultVariable;
        }
    }
}
