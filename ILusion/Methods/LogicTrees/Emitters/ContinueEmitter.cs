using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
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
                throw new EmissionException("Continue is only valid inside a loop statement.");
            }

            var targetNode =
                NodeHelper.GetFirstRecursively(
                    emitterContext.ContinueContext is ForLoopNode forLoop
                        ? forLoop.IteratorAssignment
                        : emitterContext.ContinueContext);

            var target = emitterContext.InstructionToNodeMapping.Last(x => x.Value == targetNode).Key;
            branch.Key.Operand = target;
        }
    }
}
