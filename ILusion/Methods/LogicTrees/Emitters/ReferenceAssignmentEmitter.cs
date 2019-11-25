using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ReferenceAssignmentEmitter : EmitterBase<ReferenceAssignmentNode>
    {
        protected override void Emit(EmitterContext<ReferenceAssignmentNode> emitterContext)
        {
            var type = ((PointerType)emitterContext.Node.Reference.GetValueType()).ElementType;

            switch (type.FullName)
            {
                case "System.SByte":
                case "System.Byte":
                    emitterContext.Emit(OpCodes.Stind_I1, type);
                    break;
                case "System.Int16":
                case "System.UInt16":
                    emitterContext.Emit(OpCodes.Stind_I2, type);
                    break;
                case "System.Int32":
                case "System.UInt32":
                    emitterContext.Emit(OpCodes.Stind_I4, type);
                    break;
                case "System.Int64":
                case "System.UInt64":
                    emitterContext.Emit(OpCodes.Stind_I8, type);
                    break;
                case "System.Single":
                    emitterContext.Emit(OpCodes.Stind_R4, type);
                    break;
                case "System.Double":
                    emitterContext.Emit(OpCodes.Stind_R8, type);
                    break;
                default:
                    if (type.IsValueType)
                    {
                        emitterContext.Emit(OpCodes.Stobj, type);
                    }
                    else
                    {
                        emitterContext.Emit(OpCodes.Stind_Ref, type);
                    }
                    break;
            }
        }
    }
}
