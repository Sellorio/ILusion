using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ParameterNode : LogicNode
    {
        public bool AsReference { get; }
        public ParameterDefinition Parameter { get; }

        internal override Instruction[] ToInstructions()
        {
            OpCode opCode;
            var specifyIndex = false;

            switch (Parameter.Index)
            {
                case 0:
                    opCode = OpCodes.Ldarg_0;
                    break;
                case 1:
                    opCode = OpCodes.Ldarg_1;
                    break;
                case 2:
                    opCode = OpCodes.Ldarg_2;
                    break;
                case 3:
                    opCode = OpCodes.Ldarg_3;
                    break;
                default:
                    specifyIndex = true;
                    opCode = Parameter.Index > 255 ? OpCodes.Ldarg : OpCodes.Ldarg;
                    break;
            }

            return new[] { specifyIndex ? Instruction.Create(opCode, Parameter.Index) : Instruction.Create(opCode) };
        }
    }
}
