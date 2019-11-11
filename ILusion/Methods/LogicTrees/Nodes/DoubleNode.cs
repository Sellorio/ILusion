using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class DoubleNode : ValueNode
    {
        public double Value { get; }

        internal override Instruction ToInstruction()
        {
            return Instruction.Create(OpCodes.Ldc_R8, Value);
        }

        internal override object GetValue()
        {
            return Value;
        }

        internal override TypeReference GetValueType()
        {
            return Module.ImportReference(typeof(double));
        }
    }
}
