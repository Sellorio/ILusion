using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class IsEmitter : EmitterBase<IsNode>
    {
        protected override void Emit(EmitterContext<IsNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Isinst, emitterContext.Node.TargetType);

            if (emitterContext.Node.CastedVariable != null)
            {
                var setInstruction = VariableHelper.CreateSetVariableInstruction(emitterContext.Node.CastedVariable);
                var getInstruction = VariableHelper.CreateLoadVariableInstruction(emitterContext.Node.CastedVariable);

                if (setInstruction.Operand == null)
                {
                    emitterContext.Emit(setInstruction.OpCode);
                    emitterContext.Emit(getInstruction.OpCode);
                }
                else
                {
                    emitterContext.Emit(setInstruction.OpCode, (VariableDefinition)setInstruction.Operand);
                    emitterContext.Emit(getInstruction.OpCode, (VariableDefinition)setInstruction.Operand);
                }
            }

            emitterContext.Emit(OpCodes.Ldnull);
            emitterContext.Emit(OpCodes.Cgt_Un);
        }
    }
}
