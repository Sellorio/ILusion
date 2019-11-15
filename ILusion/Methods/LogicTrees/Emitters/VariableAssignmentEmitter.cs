using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class VariableAssignmentEmitter : EmitterBase<VariableAssignmentNode>
    {
        protected override void Emit(EmitterContext<VariableAssignmentNode> emitterContext)
        {
            OpCode opCode;

            switch (emitterContext.Node.Variable.Index)
            {
                case 0:
                    opCode = OpCodes.Stloc_0;
                    break;
                case 1:
                    opCode = OpCodes.Stloc_1;
                    break;
                case 2:
                    opCode = OpCodes.Stloc_2;
                    break;
                case 3:
                    opCode = OpCodes.Stloc_3;
                    break;
                default:
                    opCode = emitterContext.Node.Variable.Index > 255 ? OpCodes.Stloc : OpCodes.Stloc;
                    emitterContext.Emit(opCode, emitterContext.Node.Variable);
                    break;
            }

            emitterContext.Emit(opCode);
        }
    }
}
