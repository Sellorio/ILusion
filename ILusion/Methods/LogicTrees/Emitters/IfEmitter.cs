using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class IfEmitter : EmitterBase<IfNode>
    {
        protected override void Emit(EmitterContext<IfNode> emitterContext)
        {
            if (emitterContext.Node.ConditionResultVariable != null)
            {
                emitterContext.Target.Body.Instructions.Add(
                    VariableHelper.CreateSetVariableInstruction(emitterContext.Node.ConditionResultVariable));
                emitterContext.Target.Body.Instructions.Add(
                    VariableHelper.CreateLoadVariableInstruction(emitterContext.Node.ConditionResultVariable));
            }

            emitterContext.EmitBranch(OpCodes.Brfalse);
            var toFalseOrEnd = emitterContext.Target.Body.Instructions.Last();

            foreach (var node in emitterContext.Node.TrueStatements)
            {
                EmissionHelper.EmitInstructions(emitterContext.InstructionToNodeMapping, emitterContext.Target, node, emitterContext.ReturnVariable);
            }

            if (emitterContext.Node.FalseStatements != null)
            {
                emitterContext.EmitBranch(OpCodes.Br);
                var toEnd = emitterContext.Target.Body.Instructions.Last();

                foreach (var node in emitterContext.Node.FalseStatements)
                {
                    EmissionHelper.EmitInstructions(emitterContext.InstructionToNodeMapping, emitterContext.Target, node, emitterContext.ReturnVariable);
                }

                toFalseOrEnd.Operand = toEnd.Next;
                BranchHelper.UpdateBranchOpCode(toFalseOrEnd);
            }
        }

        protected override void UpdateBranches(EmitterContext<IfNode> emitterContext)
        {
            var incompleteBranch = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.Node);

            if (emitterContext.Node.FalseStatements == null)
            {
                incompleteBranch.Key.Operand = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.Node.TrueStatements.Last()).Key.Next;
                BranchHelper.UpdateBranchOpCode(incompleteBranch.Key);
            }
            else
            {
                incompleteBranch.Key.Operand = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.Node.FalseStatements.Last()).Key.Next;
                BranchHelper.UpdateBranchOpCode(incompleteBranch.Key);
            }
        }
    }
}
