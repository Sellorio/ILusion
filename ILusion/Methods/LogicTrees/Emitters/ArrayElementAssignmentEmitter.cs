using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ArrayElementAssignmentEmitter : EmitterBase<ArrayElementAssignmentNode>
    {
        protected override void Emit(EmitterContext<ArrayElementAssignmentNode> emitterContext)
        {
            var elementType = ((ArrayType)emitterContext.Node.Array.GetValueType()).ElementType;

            if (elementType is GenericParameter)
            {
                emitterContext.Emit(OpCodes.Stelem_Any, elementType);
            }
            else if (!elementType.IsValueType)
            {
                emitterContext.Emit(OpCodes.Stelem_Ref);
            }
            else
            {
                switch (elementType.FullName)
                {
                    case "System.Boolean":
                    case "System.SByte":
                        emitterContext.Emit(OpCodes.Stelem_I1);
                        break;
                    case "System.Int16":
                        emitterContext.Emit(OpCodes.Stelem_I2);
                        break;
                    case "System.Int32":
                        emitterContext.Emit(OpCodes.Stelem_I4);
                        break;
                    case "System.Int64":
                        emitterContext.Emit(OpCodes.Stelem_I8);
                        break;
                    case "System.Single":
                        emitterContext.Emit(OpCodes.Stelem_R4);
                        break;
                    case "System.Double":
                        emitterContext.Emit(OpCodes.Stelem_R8);
                        break;
                    default:
                        emitterContext.Emit(OpCodes.Stelem_Any, elementType);
                        break;
                }
            }
        }
    }
}
