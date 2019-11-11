using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class LongNode : ValueNode
    {
        public long Value { get; }

        internal override Instruction ToInstruction()
        {
            return Instruction.Create(OpCodes.Ldc_I8, Value);
        }

        internal override object GetValue()
        {
            return Value;
        }

        internal override TypeReference GetValueType()
        {
            return Module.ImportReference(typeof(long));
        }
    }
}
