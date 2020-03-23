using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ContinueEmitter : EmitterBase<ContinueNode>
    {
        protected override void Emit(EmitterContext<ContinueNode> emitterContext)
        {
            emitterContext.EmitBranch(OpCodes.Br);
        }

        protected override void UpdateBranches(EmitterContext<ContinueNode> emitterContext)
        {
            var branch = emitterContext.InstructionToNodeMapping.Single(x => x.Value == emitterContext.Node);

            if (emitterContext.ContinueContext == null)
            {
                throw new InvalidOperationException("Continue is only valid inside a loop statement.");
            }

            var target = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.ContinueContext.Children.First()).Key;
            branch.Key.Operand = target;
        }
    }
}
