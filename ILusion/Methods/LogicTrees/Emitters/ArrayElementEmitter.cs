using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ArrayElementEmitter : EmitterBase<ArrayElementNode>
    {
        protected override void Emit(EmitterContext<ArrayElementNode> emitterContext)
        {
            var elementType = ((ArrayType)emitterContext.Node.Array.GetValueType()).ElementType;
            var elementIsClass = TypeHelper.IsClass(elementType);

            switch (elementType.FullName)
            {
                case "System.SByte":
                    emitterContext.Emit(OpCodes.Ldelem_I1);
                    break;
                case "System.Int16":
                    emitterContext.Emit(OpCodes.Ldelem_I2);
                    break;
                case "System.Int32":
                    emitterContext.Emit(OpCodes.Ldelem_I4);
                    break;
                case "System.Int64":
                    emitterContext.Emit(OpCodes.Ldelem_I8);
                    break;
                case "System.Byte":
                    emitterContext.Emit(OpCodes.Ldelem_U1);
                    break;
                case "System.UInt16":
                    emitterContext.Emit(OpCodes.Ldelem_U2);
                    break;
                case "System.UInt32":
                    emitterContext.Emit(OpCodes.Ldelem_U4);
                    break;
                case "System.Single":
                    emitterContext.Emit(OpCodes.Ldelem_R4);
                    break;
                case "System.Double":
                    emitterContext.Emit(OpCodes.Ldelem_R8);
                    break;
                case "System.UInt64":
                    // This seems to be a compiler bug. I suspect there is some hack happening behind the scenes
                    // to allow this to work since no truncation or value mis-interpretation is happening as a
                    // result of using the int64 instruction for a uint64 array.
                    emitterContext.Emit(OpCodes.Ldelem_I8);
                    break;
                default:
                    if (elementIsClass)
                    {
                        // This *might* be a compiler bug in C#, but I'm going to do the same thing here.
                        // Based on other IL I've seen, if you have a constraint on a type that indicates that
                        // the generic parameter will always be a class, the IL should account for this.
                        if (elementType.IsGenericParameter)
                        {
                            emitterContext.Emit(OpCodes.Ldelem_Any, elementType);
                        }
                        else
                        {
                            emitterContext.Emit(OpCodes.Ldelem_Ref);
                        }
                    }
                    else
                    {
                        emitterContext.Emit(OpCodes.Ldelem_Any, elementType);
                    }
                    break;
            }
        }
    }
}
