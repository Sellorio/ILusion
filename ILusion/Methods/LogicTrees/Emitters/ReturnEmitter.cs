using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Linq;

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

        protected override void UpdateBranches(EmitterContext<ReturnNode> emitterContext)
        {
            var instruction = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.Node).Key;

            if (instruction.OpCode != OpCodes.Ret)
            {
                var isFunction = emitterContext.Target.ReturnType.FullName != typeof(void).FullName;
                var targetInstruction = emitterContext.Target.Body.Instructions[emitterContext.Target.Body.Instructions.Count - (isFunction ? 2 : 1)];

                instruction.Operand = targetInstruction;
            }
        }
    }
}
