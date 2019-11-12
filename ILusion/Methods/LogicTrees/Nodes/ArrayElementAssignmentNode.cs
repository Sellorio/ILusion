using System;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ArrayElementAssignmentNode : LogicNode
    {
        public ValueNode Array { get; }
        public ValueNode Index { get; }
        public ValueNode Value { get; }

        internal override Instruction[] ToInstructions()
        {
            var elementType = ((ArrayType)Array.GetValueType()).ElementType;

            OpCode opCode;

            if (elementType is GenericParameter)
            {
                opCode = OpCodes.Stelem_Any;
            }
            else
            {
                switch (elementType.FullName)
                {
                    case "System.SByte":
                        opCode = OpCodes.Stelem_I1;
                        break;
                    case "System.Int16":
                        opCode = OpCodes.Stelem_I2;
                        break;
                    case "System.Int32":
                        opCode = OpCodes.Stelem_I4;
                        break;
                    case "System.Int64":
                        opCode = OpCodes.Stelem_I8;
                        break;
                    case "System.Single":
                        opCode = OpCodes.Stelem_R4;
                        break;
                    case "System.Double":
                        opCode = OpCodes.Stelem_R8;
                        break;
                    default:
                        var resolvedElementType = elementType.Resolve();
                        return new[] { Instruction.Create(resolvedElementType.IsClass ? OpCodes.Stelem_Ref : OpCodes.Stelem_Any, elementType) };
                }
            }

            return new[] { Instruction.Create(opCode) };
        }
    }
}
