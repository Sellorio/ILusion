using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ConditionalOperatorEmitter : EmitterBase<ConditionalOperatorNode>
    {
        protected override void Emit(EmitterContext<ConditionalOperatorNode> emitterContext)
        {
            emitterContext.EmitBranch(OpCodes.Brtrue);
            var brTrueInstruction = emitterContext.Target.Body.Instructions.Last();

            foreach (var node in emitterContext.Node.FalseExpression)
            {
                EmissionHelper.EmitInstructions(emitterContext.InstructionToNodeMapping, emitterContext.Target, node, emitterContext.ReturnVariable);
            }

            emitterContext.EmitBranch(OpCodes.Br);
            var brInstruction = emitterContext.Target.Body.Instructions.Last();

            foreach (var node in emitterContext.Node.TrueExpression)
            {
                EmissionHelper.EmitInstructions(emitterContext.InstructionToNodeMapping, emitterContext.Target, node, emitterContext.ReturnVariable);
            }

            // update the brtrue to the instruction right after the false block branch (i.e. the first true-block instruction)
            brTrueInstruction.Operand = brInstruction.Next;
        }

        protected override void UpdateBranches(EmitterContext<ConditionalOperatorNode> emitterContext)
        {
            var branchOutOfFalseBlock = emitterContext.InstructionToNodeMapping.Last(x => x.Key.OpCode == OpCodes.Br && x.Value == emitterContext.Node);

            // update the false block branch to the instruction after the last true block instruction
            branchOutOfFalseBlock.Key.Operand = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.Node.TrueExpression.Last()).Key.Next;
        }
    }
}
