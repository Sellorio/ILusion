using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class LoadArrayElementNode : ValueNode
    {
        public ValueNode Array { get; }
        public ValueNode Index { get; }
        public bool UseAny { get; }
        public bool AsReference { get; }

        internal override Instruction ToInstruction()
        {
            var type = ((ArrayType)Array.GetValueType()).ElementType.Resolve();

            if (UseAny)
            {
                return Instruction.Create(OpCodes.Ldelem_Any);
            }

            if (AsReference)
            {
                return Instruction.Create(OpCodes.Ldelema, type);
            }

            switch (type.FullName)
            {
                case "System.SByte":
                    return Instruction.Create(OpCodes.Ldelem_I1);
                case "System.Int16":
                    return Instruction.Create(OpCodes.Ldelem_I2);
                case "System.Int32":
                    return Instruction.Create(OpCodes.Ldelem_I4);
                case "System.Int64":
                    return Instruction.Create(OpCodes.Ldelem_I8);
                case "System.Byte":
                    return Instruction.Create(OpCodes.Ldelem_U1);
                case "System.UInt16":
                    return Instruction.Create(OpCodes.Ldelem_U2);
                case "System.UInt32":
                    return Instruction.Create(OpCodes.Ldelem_U4);
                case "System.Single":
                    return Instruction.Create(OpCodes.Ldelem_R4);
                case "System.Double":
                    return Instruction.Create(OpCodes.Ldelem_R8);
                default:
                    if (type.IsClass)
                    {
                        return Instruction.Create(OpCodes.Ldelem_Ref, type);
                    }
                    else
                    {
                        return Instruction.Create(OpCodes.Ldelem_Any, type);
                    }
            }
        }
    }
}
