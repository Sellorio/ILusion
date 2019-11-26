using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ParameterEmitter : EmitterBase<ParameterNode>
    {
        protected override void Emit(EmitterContext<ParameterNode> emitterContext)
        {
            switch (emitterContext.Node.Parameter.Index)
            {
                case 0:
                    emitterContext.Emit(emitterContext.Target.IsStatic ? OpCodes.Ldarg_0 : OpCodes.Ldarg_1);
                    break;
                case 1:
                    emitterContext.Emit(emitterContext.Target.IsStatic ? OpCodes.Ldarg_1 : OpCodes.Ldarg_2);
                    break;
                case 2:
                    emitterContext.Emit(emitterContext.Target.IsStatic ? OpCodes.Ldarg_2 : OpCodes.Ldarg_3);
                    break;
                case 3:
                    if (emitterContext.Target.IsStatic)
                    {
                        emitterContext.Emit(OpCodes.Ldarg_3);
                    }
                    else
                    {
                        emitterContext.Emit(OpCodes.Ldarg_S, 4);
                    }
                    break;
                default:
                    emitterContext.Emit(
                        emitterContext.Node.Parameter.Index > 255 ? OpCodes.Ldarg : OpCodes.Ldarg_S,
                        emitterContext.Node.Parameter);
                    break;
            }

            if (emitterContext.Node.Parameter.ParameterType is ByReferenceType byRef)
            {
                switch (byRef.ElementType.FullName)
                {
                    case "System.SByte":
                        emitterContext.Emit(OpCodes.Ldind_I1);
                        break;
                    case "System.Byte":
                        emitterContext.Emit(OpCodes.Ldind_U1);
                        break;
                    case "System.Int16":
                        emitterContext.Emit(OpCodes.Ldind_I2);
                        break;
                    case "System.UInt16":
                        emitterContext.Emit(OpCodes.Ldind_U2);
                        break;
                    case "System.Int32":
                        emitterContext.Emit(OpCodes.Ldind_I4);
                        break;
                    case "System.UInt32":
                        emitterContext.Emit(OpCodes.Ldind_U4);
                        break;
                    case "System.Int64":
                    case "System.UInt64":
                        emitterContext.Emit(OpCodes.Ldind_I8);
                        break;
                    case "System.Single":
                        emitterContext.Emit(OpCodes.Ldind_R4);
                        break;
                    case "System.Double":
                        emitterContext.Emit(OpCodes.Ldind_R8);
                        break;
                    default:
                        if (byRef.ElementType.IsValueType)
                        {
                            emitterContext.Emit(OpCodes.Ldobj, byRef.ElementType);
                        }
                        else
                        {
                            emitterContext.Emit(OpCodes.Ldind_Ref);
                        }
                        break;
                }
            }
        }
    }
}
