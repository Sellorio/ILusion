using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class WhileEmitter : IEmitter
    {
        public Type SupportedNode => typeof(WhileNode);

        public void Emit(Dictionary<Instruction, LogicNode> instructionToNodeMapping, MethodDefinition target, LogicNode node, VariableDefinition returnVariable)
            => LoopEmitter.Instance.Emit(instructionToNodeMapping, target, node, returnVariable);

        public void UpdateBranches(Dictionary<Instruction, LogicNode> instructionToNodeMapping, MethodDefinition method, LogicNode node, VariableDefinition returnVariable)
            => LoopEmitter.Instance.UpdateBranches(instructionToNodeMapping, method, node, returnVariable);
    }
}
