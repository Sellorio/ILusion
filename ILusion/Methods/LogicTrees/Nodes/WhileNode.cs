using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class WhileNode : LoopNode
    {
        internal WhileNode(
            ValueNode condition,
            VariableDefinition conditionResultVariable,
            IEnumerable<LogicNode> statements,
            IEnumerable<LogicNode> children)
            : base(condition, conditionResultVariable, statements, children)
        {
        }
    }
}
