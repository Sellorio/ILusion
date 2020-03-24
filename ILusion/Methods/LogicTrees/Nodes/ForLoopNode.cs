using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ForLoopNode : LoopNode
    {
        public LogicNode IteratorAssignment { get; }

        public ForLoopNode(
            ValueNode condition,
            VariableDefinition conditionResultVariable,
            LogicNode iteratorAssignment,
            IEnumerable<LogicNode> statements,
            IEnumerable<LogicNode> children)
            : base(condition, conditionResultVariable, statements, children)
        {
            IteratorAssignment = iteratorAssignment;
        }
    }
}
