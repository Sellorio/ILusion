using ILusion.Methods.LogicTrees.Nodes.ControlBlocks;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Emitters.ControlBlocks
{
    internal class ConditionalOperatorEmitter : EmitterBase<ConditionalOperatorNode>
    {
        protected override void Emit(EmitterContext<ConditionalOperatorNode> emitterContext)
        {
            emitterContext.EmitBranch(OpCodes.Brtrue);
            var brTrueInstruction = emitterContext.Target.Body.Instructions.Last();

            foreach (var node in emitterContext.Node.FalseExpression)
            {
                emitterContext.EmitChildInstructions(node);
            }

            emitterContext.EmitBranch(OpCodes.Br);
            var brInstruction = emitterContext.Target.Body.Instructions.Last();

            foreach (var node in emitterContext.Node.TrueExpression)
            {
                emitterContext.EmitChildInstructions(node);
            }

            // update the brtrue to the instruction right after the false block branch (i.e. the first true-block instruction)
            brTrueInstruction.Operand = brInstruction.Next;
        }

        protected override void UpdateBranches(EmitterContext<ConditionalOperatorNode> emitterContext)
        {
            var branchOutOfFalseBlock = emitterContext.InstructionToNodeMapping.Last(x => x.Key.OpCode == OpCodes.Br && x.Value == emitterContext.Node);

            // update the false block branch to the instruction after the last true block instruction
            branchOutOfFalseBlock.Key.Operand = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.Node.TrueExpression.Last()).Key.Next;

            foreach (var node in emitterContext.Node.TrueExpression)
            {
                emitterContext.UpdateChildBranches(node);
            }

            if (emitterContext.Node.FalseExpression != null)
            {
                foreach (var node in emitterContext.Node.FalseExpression)
                {
                    emitterContext.UpdateChildBranches(node);
                }
            }
        }
    }
}
