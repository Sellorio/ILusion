using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ReturnEmitter : EmitterBase<ReturnNode>
    {
        protected override void Emit(EmitterContext<ReturnNode> emitterContext)
        {
            if (emitterContext.Target.ReturnType.FullName != typeof(void).FullName)
            {
                if (emitterContext.ReturnVariable == null)
                {
                    emitterContext.Emit(OpCodes.Ret);
                    return;
                }
                else
                {
                    var instruction = VariableHelper.CreateSetVariableInstruction(emitterContext.ReturnVariable);

                    if (instruction.Operand == null)
                    {
                        emitterContext.Emit(instruction.OpCode);
                    }
                    else
                    {
                        emitterContext.Emit(instruction.OpCode, (VariableDefinition)instruction.Operand);
                    }
                }
            }

            emitterContext.EmitBranch(OpCodes.Br);
        }
    }
}
