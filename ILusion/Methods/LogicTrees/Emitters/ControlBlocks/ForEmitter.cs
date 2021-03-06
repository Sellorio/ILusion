﻿using ILusion.Methods.LogicTrees.Nodes.ControlBlocks;

namespace ILusion.Methods.LogicTrees.Emitters.ControlBlocks
{
    internal class ForEmitter : EmitterBase<ForNode>
    {
        protected override void Emit(EmitterContext<ForNode> emitterContext)
        {
            foreach (var initialAssignment in emitterContext.Node.InitialAssignments)
            {
                emitterContext.EmitChildInstructions(initialAssignment);
            }

            emitterContext.EmitChildInstructions(emitterContext.Node.Loop);
        }

        protected override void UpdateBranches(EmitterContext<ForNode> emitterContext)
        {
            emitterContext.UpdateChildBranches(emitterContext.Node.Loop);
        }
    }
}
