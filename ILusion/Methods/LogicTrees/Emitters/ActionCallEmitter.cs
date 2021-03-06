﻿using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ActionCallEmitter : EmitterBase<ActionCallNode>
    {
        protected override void Emit(EmitterContext<ActionCallNode> emitterContext)
        {
            if (emitterContext.Node.ConstrainedModifier != null)
            {
                emitterContext.Emit(OpCodes.Constrained, emitterContext.Node.ConstrainedModifier);
            }

            emitterContext.Emit(
                emitterContext.Node.Instance == null
                    || emitterContext.Node.IsBaseCall
                    || emitterContext.Node.Method.DeclaringType.IsValueType ? OpCodes.Call : OpCodes.Callvirt,
                emitterContext.Node.Method);
        }
    }
}
