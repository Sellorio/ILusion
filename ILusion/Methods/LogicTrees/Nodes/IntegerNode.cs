using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class IntegerNode : ValueNode
    {
        public int Value { get; }

        internal override Instruction ToInstruction()
        {
            OpCode result;

            switch (Value)
            {
                case -1:
                    result = OpCodes.Ldc_I4_M1;
                    break;
                case 0:
                    result = OpCodes.Ldc_I4_0;
                    break;
                case 1:
                    result = OpCodes.Ldc_I4_1;
                    break;
                case 2:
                    result = OpCodes.Ldc_I4_2;
                    break;
                case 3:
                    result = OpCodes.Ldc_I4_3;
                    break;
                case 4:
                    result = OpCodes.Ldc_I4_4;
                    break;
                case 5:
                    result = OpCodes.Ldc_I4_5;
                    break;
                case 6:
                    result = OpCodes.Ldc_I4_6;
                    break;
                case 7:
                    result = OpCodes.Ldc_I4_7;
                    break;
                case 8:
                    result = OpCodes.Ldc_I4_8;
                    break;
                default:
                    if (Value >= -127 && Value <= 127)
                    {
                        result = OpCodes.Ldc_I4_S;
                    }
                    else
                    {
                        result = OpCodes.Ldc_I4;
                    }

                    return Instruction.Create(result, Value);
            }

            return Instruction.Create(result);
        }

        internal override object GetValue()
        {
            return Value;
        }

        internal override TypeReference GetValueType()
        {
            return Module.ImportReference(typeof(int));
        }
    }
}
