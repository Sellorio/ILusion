using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class LoadVariableNode : LogicNode
    {
        public bool AsReference { get; }
        public VariableDefinition Variable { get; }

        internal override Instruction ToInstruction()
        {
            OpCode opCode;
            var specifyIndex = false;

            if (AsReference)
            {
                opCode = Variable.Index > 255 ? OpCodes.Ldloca : OpCodes.Ldloca_S;
            }
            else
            {
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
                        opCode = Variable.Index > 255 ? OpCodes.Ldloc : OpCodes.Ldloc;
                        break;
                }
            }

            return specifyIndex ? Instruction.Create(opCode, Variable.Index) : Instruction.Create(opCode);
        }
    }
}
