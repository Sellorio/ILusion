namespace ILusion.Methods.LogicTrees.Nodes.ControlBlocks.Switch
{
    public class SwitchExpressionCase
    {
        public object Value { get; }
        public ValueNode ResultValue { get; }

        internal SwitchExpressionCase(object value, ValueNode resultValue)
        {
            Value = value;
            ResultValue = resultValue;
        }
    }
}
