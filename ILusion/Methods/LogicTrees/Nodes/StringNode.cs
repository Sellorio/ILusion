using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class StringNode : ValueNode
    {
        public string Value { get; }

        internal override Instruction ToInstruction()
        {
            return Instruction.Create(OpCodes.Ldstr, Value);
        }

        internal override object GetValue()
        {
            return Value;
        }

        internal override TypeReference GetValueType()
        {
            return Module.ImportReference(typeof(string));
        }
    }
}
