using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class BreakEmitter : EmitterBase<BreakNode>
    {
        protected override void Emit(EmitterContext<BreakNode> emitterContext)
        {
            emitterContext.EmitBranch(OpCodes.Br);
        }

        protected override void UpdateBranches(EmitterContext<BreakNode> emitterContext)
        {
            var branch = emitterContext.InstructionToNodeMapping.Single(x => x.Value == emitterContext.Node);

            if (emitterContext.ContinueContext == null)
            {
                throw new InvalidOperationException("Break is only valid inside a loop or switch statement.");
            }

            var target = emitterContext.InstructionToNodeMapping.Last(x => x.Value == emitterContext.ContinueContext).Key.Next;
            branch.Key.Operand = target;
        }
    }
}
