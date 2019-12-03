using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
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
            var target =
                emitterContext.Node.OriginalTarget == null
                    ? emitterContext.Target.Body.Instructions.Last()
                    : emitterContext.InstructionToNodeMapping.First(x => x.Value == emitterContext.Node.Target).Key;

            branch.Key.Operand = target;
        }
    }
}
