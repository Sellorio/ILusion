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

        public void Emit(
            Dictionary<Instruction, LogicNode> instructionToNodeMapping,
            MethodDefinition target,
            LogicNode node,
            VariableDefinition returnVariable,
            LogicNode breakContext,
            LogicNode continueContext)
        {
            Emit(new EmitterContext<TNode>(instructionToNodeMapping, target, (TNode)node, returnVariable, breakContext, continueContext));
        }

        public void UpdateBranches(
            Dictionary<Instruction, LogicNode> instructionToNodeMapping,
            MethodDefinition target,
            LogicNode node,
            VariableDefinition returnVariable,
            LogicNode breakContext,
            LogicNode continueContext)
        {
            UpdateBranches(new EmitterContext<TNode>(instructionToNodeMapping, target, (TNode)node, returnVariable, breakContext, continueContext));
        }

        protected abstract void Emit(EmitterContext<TNode> emitterContext);

        protected virtual void UpdateBranches(EmitterContext<TNode> emitterContext)
        {
        }
    }
}
