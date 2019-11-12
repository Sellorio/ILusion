using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class LiteralNode : ValueNode
    {
        public object Value { get; }

        internal override Instruction[] ToInstructions()
        {
            OpCode opCode;

            switch (Value)
            {
                case int intValue:
                    switch (intValue)
                    {
                        case -1:
                            opCode = OpCodes.Ldc_I4_M1;
                            break;
                        case 0:
                            opCode = OpCodes.Ldc_I4_0;
                            break;
                        case 1:
                            opCode = OpCodes.Ldc_I4_1;
                            break;
                        case 2:
                            opCode = OpCodes.Ldc_I4_2;
                            break;
                        case 3:
                            opCode = OpCodes.Ldc_I4_3;
                            break;
                        case 4:
                            opCode = OpCodes.Ldc_I4_4;
                            break;
                        case 5:
                            opCode = OpCodes.Ldc_I4_5;
                            break;
                        case 6:
                            opCode = OpCodes.Ldc_I4_6;
                            break;
                        case 7:
                            opCode = OpCodes.Ldc_I4_7;
                            break;
                        case 8:
                            opCode = OpCodes.Ldc_I4_8;
                            break;
                        default:
                            if (intValue >= -127 && intValue <= 127)
                            {
                                return new[] { Instruction.Create(OpCodes.Ldc_I4_S, intValue) };
                            }

                            return new[] { Instruction.Create(OpCodes.Ldc_I4, intValue) };
                    }

                    return new[] { Instruction.Create(opCode) };
                case long longValue:
                    return new[] { Instruction.Create(OpCodes.Ldc_I8, longValue) };
                case float floatValue:
                    return new[] { Instruction.Create(OpCodes.Ldc_R4, floatValue) };
                case double doubleValue:
                    return new[] { Instruction.Create(OpCodes.Ldc_R8, doubleValue) };
                case string stringValue:
                    return new[] { Instruction.Create(OpCodes.Ldstr, stringValue) };
                default:
                    throw new System.NotSupportedException("Unexpected literal type.");
            }
        }

        internal override object GetValue()
        {
            return Value;
        }

        internal override TypeReference GetValueType()
        {
            return Module.ImportReference(Value.GetType());
        }
    }
}
