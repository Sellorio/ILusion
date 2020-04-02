using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes.ControlBlocks
{
    public sealed class ForNode : LogicNode
    {
        public IReadOnlyList<LogicNode> InitialAssignments { get; }
        public ForLoopNode Loop { get; }

        public ForNode(
            IEnumerable<LogicNode> initialAssignments,
            ValueNode condition,
            VariableDefinition conditionResultVariable,
            LogicNode iteratorAssignment,
            IEnumerable<LogicNode> statements,
            IEnumerable<LogicNode> loopChildren)
            : base(Enumerable.Empty<LogicNode>())
        {
            InitialAssignments = ImmutableArray.CreateRange(initialAssignments);
            Loop = new ForLoopNode(condition, conditionResultVariable, iteratorAssignment, statements, loopChildren);
        }
    }
}
