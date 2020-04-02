using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ILusion.Methods.LogicTrees.Nodes.ControlBlocks.Switch
{
    public sealed class SwitchNode : LogicNode
    {
        public ValueNode Value { get; }
        public VariableDefinition TemporaryVariable { get; }
        public IReadOnlyList<SwitchCase> Cases { get; }

        internal SwitchNode(ValueNode value, VariableDefinition temporaryVariable, IEnumerable<SwitchCase> cases, IEnumerable<LogicNode> children)
            : base(children)
        {
            Value = value;
            TemporaryVariable = temporaryVariable;
            Cases = ImmutableArray.CreateRange(cases);
        }
    }
}
