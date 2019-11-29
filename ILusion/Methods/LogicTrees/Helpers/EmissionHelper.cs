using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Emitters;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Helpers
{
    internal static class EmissionHelper
    {
        private static readonly Dictionary<Type, IEmitter> _mappedEmitters =
            typeof(IEmitter).Assembly.GetTypes()
                .Where(x => !x.IsInterface && !x.IsAbstract && x.Namespace == typeof(IEmitter).Namespace && typeof(IEmitter).IsAssignableFrom(x))
                .Select(x => (IEmitter)Activator.CreateInstance(x))
                .ToDictionary(x => x.SupportedNode, x => x);

        internal static void EmitInstructions(
            Dictionary<Instruction, LogicNode> instructionToNodeMapping,
            MethodDefinition methodDefinition,
            LogicNode node,
            VariableDefinition returnVariable)
        {
            foreach (var child in node.Children)
            {
                EmitInstructions(instructionToNodeMapping, methodDefinition, child, returnVariable);
            }

            if (!_mappedEmitters.TryGetValue(node.GetType(), out var emitter))
            {
                throw new EmissionException($"No emitter found that supports {node.GetType().Name}.");
            }

            emitter.Emit(instructionToNodeMapping, methodDefinition, node, returnVariable);
        }

        internal static void UpdateBranches(
            Dictionary<Instruction, LogicNode> instructionToNodeMapping,
            MethodDefinition methodDefinition,
            LogicNode node,
            VariableDefinition returnVariable)
        {
            if (!_mappedEmitters.TryGetValue(node.GetType(), out var emitter))
            {
                throw new EmissionException($"No emitter found that supports {node.GetType().Name}.");
            }

            emitter.UpdateBranches(instructionToNodeMapping, methodDefinition, node, returnVariable);
        }
    }
}
