using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Helpers
{
    internal static class OpCodeHelper
    {
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
    }
}
