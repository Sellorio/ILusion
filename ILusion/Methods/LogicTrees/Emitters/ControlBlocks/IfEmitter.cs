using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes.ControlBlocks;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Emitters.ControlBlocks
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
                emitterContext.EmitChildInstructions(node);
            }

            if (emitterContext.Node.FalseStatements != null)
            {
                emitterContext.EmitBranch(OpCodes.Br);
                var toEnd = emitterContext.Target.Body.Instructions.Last();

                foreach (var node in emitterContext.Node.FalseStatements)
                {
                    emitterContext.EmitChildInstructions(node);
                }

                toFalseOrEnd.Operand = toEnd.Next;
            }
        }

        protected override void UpdateBranches(EmitterContext<IfNode> emitterContext)
        {
            var incompleteBranch = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.Node);

            if (emitterContext.Node.FalseStatements == null)
            {
                incompleteBranch.Key.Operand = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.Node.TrueStatements.Last()).Key.Next;
            }
            else
            {
                incompleteBranch.Key.Operand = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.Node.FalseStatements.Last()).Key.Next;
            }

            foreach (var statement in emitterContext.Node.TrueStatements)
            {
                emitterContext.UpdateChildBranches(statement);
            }

            if (emitterContext.Node.FalseStatements != null)
            {
                foreach (var statement in emitterContext.Node.FalseStatements)
                {
                    emitterContext.UpdateChildBranches(statement);
                }
            }
        }
    }
}
