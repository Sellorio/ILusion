using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes.ControlBlocks.Switch
{
    public sealed class SwitchExpressionNode : ValueNode
    {
        public ValueNode Value { get; }
        public VariableDefinition TemporaryVariable { get; }
        public IReadOnlyList<SwitchExpressionCase> Cases { get; }

        internal SwitchExpressionNode(ValueNode value, VariableDefinition temporaryVariable, IEnumerable<SwitchExpressionCase> cases, IEnumerable<LogicNode> children)
            : base(children)
        {
            Value = value;
            TemporaryVariable = temporaryVariable;
            Cases = ImmutableArray.CreateRange(cases);
        }

        internal override TypeReference GetValueType()
        {
            return Cases.First().ResultValue.GetValueType();
        }
    }
}
