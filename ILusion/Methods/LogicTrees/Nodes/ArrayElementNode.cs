using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ArrayElementNode : ValueNode
    {
        public ValueNode Array { get; }
        public ValueNode Index { get; }

        internal override Instruction[] ToInstructions()
        {
            var elementType = ((ArrayType)Array.GetValueType()).ElementType;

            if (elementType is GenericParameter)
            {
                return new[] { Instruction.Create(OpCodes.Ldelem_Any) };
            }

            OpCode opCode;

            switch (elementType.FullName)
            {
                case "System.SByte":
                    opCode = OpCodes.Ldelem_I1;
                    break;
                case "System.Int16":
                    opCode = OpCodes.Ldelem_I2;
                    break;
                case "System.Int32":
                    opCode = OpCodes.Ldelem_I4;
                    break;
                case "System.Int64":
                    opCode = OpCodes.Ldelem_I8;
                    break;
                case "System.Byte":
                    opCode = OpCodes.Ldelem_U1;
                    break;
                case "System.UInt16":
                    opCode = OpCodes.Ldelem_U2;
                    break;
                case "System.UInt32":
                    opCode = OpCodes.Ldelem_U4;
                    break;
                case "System.Single":
                    opCode = OpCodes.Ldelem_R4;
                    break;
                case "System.Double":
                    opCode = OpCodes.Ldelem_R8;
                    break;
                default:
                    var resolvedElementType = elementType.Resolve();
                    return new[] { Instruction.Create(resolvedElementType.IsClass ? OpCodes.Ldelem_Ref : OpCodes.Ldelem_Any, resolvedElementType) };
            }

            return new[] { Instruction.Create(opCode) };
        }

        internal override TypeReference GetValueType()
        {
            return ((ArrayType)Array.GetValueType()).ElementType;
        }
    }
}
