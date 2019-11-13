using Mono.Cecil;
using System;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal interface IEmitter
    {
        Type SupportedNode { get; }
        void Emit(MethodDefinition target, LogicNode node);
    }
}
