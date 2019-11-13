using System;
using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal abstract class EmitterBase<TNode> : IEmitter
        where TNode : LogicNode
    {
        public Type SupportedNode { get; } = typeof(TNode);

        public void Emit(MethodDefinition target, LogicNode node)
        {
            Emit(target, (TNode)node);
        }

        protected abstract void Emit(EmitterContext<TNode> emitterContext);
    }
}
