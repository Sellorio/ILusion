using System;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class SetArrayElementNode : LogicNode
    {
        public ValueNode Array { get; }
        public ValueNode Index { get; }
        public ValueNode Value { get; }
        public bool UseAny { get; }

        internal override Instruction ToInstruction()
        {
            var type = ((ArrayType)Array.GetValueType()).ElementType.Resolve();

            if (UseAny)
            {
                return Instruction.Create(OpCodes.Stelem_Any);
            }

            switch (type.FullName)
            {
                case "System.SByte":
                    return Instruction.Create(OpCodes.Stelem_I1);
                case "System.Int16":
                    return Instruction.Create(OpCodes.Stelem_I2);
                case "System.Int32":
                    return Instruction.Create(OpCodes.Stelem_I4);
                case "System.Int64":
                    return Instruction.Create(OpCodes.Stelem_I8);
                case "System.Single":
                    return Instruction.Create(OpCodes.Stelem_R4);
                case "System.Double":
                    return Instruction.Create(OpCodes.Stelem_R8);
                default:
                    if (type.IsClass)
                    {
                        return Instruction.Create(OpCodes.Stelem_Ref, type);
                    }
                    else
                    {
                        return Instruction.Create(OpCodes.Stelem_Any, type);
                    }
            }
        }
    }
}
