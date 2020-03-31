using ILusion.Exceptions;
using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Helpers
{
    internal static class OpCodeHelper
    {
        internal static readonly HashSet<OpCode> LdlocOpCodes = new HashSet<OpCode>
        {
            OpCodes.Ldloc,
            OpCodes.Ldloc_0,
            OpCodes.Ldloc_1,
            OpCodes.Ldloc_2,
            OpCodes.Ldloc_3,
            OpCodes.Ldloc_S
        };

        internal static readonly HashSet<OpCode> LdcI4OpCodes = new HashSet<OpCode>
        {
            OpCodes.Ldc_I4_M1,
            OpCodes.Ldc_I4_0,
            OpCodes.Ldc_I4_1,
            OpCodes.Ldc_I4_2,
            OpCodes.Ldc_I4_3,
            OpCodes.Ldc_I4_4,
            OpCodes.Ldc_I4_5,
            OpCodes.Ldc_I4_6,
            OpCodes.Ldc_I4_7,
            OpCodes.Ldc_I4_8,
            OpCodes.Ldc_I4_S,
            OpCodes.Ldc_I4
        };

        internal static OpCode LoadLocalOpCode(int index, out bool requiresParameter)
        {
            OpCode opCode;
            requiresParameter = false;

            switch (index)
            {
                case 0:
                    opCode = OpCodes.Ldloc_0;
                    break;
                case 1:
                    opCode = OpCodes.Ldloc_1;
                    break;
                case 2:
                    opCode = OpCodes.Ldloc_2;
                    break;
                case 3:
                    opCode = OpCodes.Ldloc_3;
                    break;
                default:
                    requiresParameter = true;
                    opCode = index > 255 ? OpCodes.Ldloc : OpCodes.Ldloc_S;
                    break;
            }

            return opCode;
        }

        internal static OpCode LoadParameterOpCode(int index, out bool requiresParameter)
        {
            OpCode opCode;
            requiresParameter = false;

            switch (index)
            {
                case 0:
                    opCode = OpCodes.Ldarg_0;
                    break;
                case 1:
                    opCode = OpCodes.Ldarg_1;
                    break;
                case 2:
                    opCode = OpCodes.Ldarg_2;
                    break;
                case 3:
                    opCode = OpCodes.Ldarg_3;
                    break;
                default:
                    requiresParameter = true;
                    opCode = index > 255 ? OpCodes.Ldarg : OpCodes.Ldarg_S;
                    break;
            }

            return opCode;
        }

        internal static int GetInteger(Instruction instruction)
        {
            switch (instruction.OpCode.Code)
            {
                case Code.Ldc_I4_M1:
                    return -1;
                case Code.Ldc_I4_0:
                    return 0;
                case Code.Ldc_I4_1:
                    return 1;
                case Code.Ldc_I4_2:
                    return 2;
                case Code.Ldc_I4_3:
                    return 3;
                case Code.Ldc_I4_4:
                    return 4;
                case Code.Ldc_I4_5:
                    return 5;
                case Code.Ldc_I4_6:
                    return 6;
                case Code.Ldc_I4_7:
                    return 7;
                case Code.Ldc_I4_8:
                    return 8;
                case Code.Ldc_I4_S:
                    return (sbyte)instruction.Operand;
                case Code.Ldc_I4:
                    return (int)instruction.Operand;
            }

            throw new ParsingException("The given instruction was not an Int32 literal.");
        }
    }
}
