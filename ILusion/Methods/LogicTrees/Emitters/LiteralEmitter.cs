using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class LiteralEmitter : EmitterBase<LiteralNode>
    {
        protected override void Emit(EmitterContext<LiteralNode> emitterContext)
        {
            switch (emitterContext.Node.Value)
            {
                case int intValue:
                    switch (intValue)
                    {
                        case -1:
                            emitterContext.Emit(OpCodes.Ldc_I4_M1);
                            break;
                        case 0:
                            emitterContext.Emit(OpCodes.Ldc_I4_0);
                            break;
                        case 1:
                            emitterContext.Emit(OpCodes.Ldc_I4_1);
                            break;
                        case 2:
                            emitterContext.Emit(OpCodes.Ldc_I4_2);
                            break;
                        case 3:
                            emitterContext.Emit(OpCodes.Ldc_I4_3);
                            break;
                        case 4:
                            emitterContext.Emit(OpCodes.Ldc_I4_4);
                            break;
                        case 5:
                            emitterContext.Emit(OpCodes.Ldc_I4_5);
                            break;
                        case 6:
                            emitterContext.Emit(OpCodes.Ldc_I4_6);
                            break;
                        case 7:
                            emitterContext.Emit(OpCodes.Ldc_I4_7);
                            break;
                        case 8:
                            emitterContext.Emit(OpCodes.Ldc_I4_8);
                            break;
                        default:
                            if (intValue >= -127 && intValue <= 127)
                            {
                                emitterContext.Emit(OpCodes.Ldc_I4_S, intValue);
                                return;
                            }

                            emitterContext.Emit(OpCodes.Ldc_I4, intValue);
                            return;
                    }
                    break;
                case long longValue:
                    emitterContext.Emit(OpCodes.Ldc_I8, longValue);
                    break;
                case float floatValue:
                    emitterContext.Emit(OpCodes.Ldc_R4, floatValue);
                    break;
                case double doubleValue:
                    emitterContext.Emit(OpCodes.Ldc_R8, doubleValue);
                    break;
                case string stringValue:
                    emitterContext.Emit(OpCodes.Ldstr, stringValue);
                    break;
                default:
                    throw new NotSupportedException("Unexpected literal type.");
            }
        }
    }
}
