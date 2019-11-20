using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal abstract class EmitterBase<TNode> : IEmitter
        where TNode : LogicNode
    {
        public Type SupportedNode { get; } = typeof(TNode);

        public void Emit(Dictionary<Instruction, LogicNode> instructionToNodeMapping, MethodDefinition target, LogicNode node)
        {
            Emit(new EmitterContext<TNode>(instructionToNodeMapping, target, (TNode)node));
        }

        protected abstract void Emit(EmitterContext<TNode> emitterContext);
    }
}
