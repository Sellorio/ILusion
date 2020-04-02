using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes.ControlBlocks.Switch
{
    public sealed class SwitchExpressionTypeCase : SwitchExpressionCase
    {
        public new TypeReference Value => (TypeReference)base.Value;
        public VariableDefinition Variable { get; }

        internal SwitchExpressionTypeCase(TypeReference type, VariableDefinition variable, ValueNode resultValue)
            : base(type, resultValue)
        {
            Variable = variable;
        }
    }
}
