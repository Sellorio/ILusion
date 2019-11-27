using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class VariableAssignmentNode : LogicNode
    {
        public VariableDefinition Variable { get; }
        public ValueNode Value { get; }

        internal VariableAssignmentNode(VariableDefinition variable, ValueNode value, IEnumerable<LogicNode> children)
            : base(children)
        {
            Variable = variable;
            Value = value;
        }
    }
}
