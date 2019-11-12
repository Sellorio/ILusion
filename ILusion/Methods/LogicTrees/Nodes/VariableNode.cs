using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class VariableNode : ValueNode
    {
        public VariableDefinition Variable { get; }

        internal override Instruction[] ToInstructions()
        {
            OpCode opCode;
            var specifyIndex = false;

            switch (Variable.Index)
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
                    specifyIndex = true;
                    opCode = Variable.Index > 255 ? OpCodes.Ldloc : OpCodes.Ldloc_S;
                    break;
            }

            return new[] { specifyIndex ? Instruction.Create(opCode, Variable.Index) : Instruction.Create(opCode) };
        }

        internal override TypeReference GetValueType()
        {
            return Variable.VariableType;
        }
    }
}
