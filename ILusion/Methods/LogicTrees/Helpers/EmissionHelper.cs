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

        private static readonly Dictionary<OpCode, OpCode> LongToShort = new Dictionary<OpCode, OpCode>
        {
            { OpCodes.Br, OpCodes.Br_S },
            { OpCodes.Brfalse, OpCodes.Brfalse_S },
            { OpCodes.Brtrue, OpCodes.Brtrue_S }
        };

        internal static void EmitInstructions(
            Dictionary<Instruction, LogicNode> instructionToNodeMapping,
            MethodDefinition target,
            LogicNode node,
            VariableDefinition returnVariable,
            LogicNode breakContext,
            LogicNode continueContext)
        {
            foreach (var child in node.Children)
            {
                EmitInstructions(instructionToNodeMapping, target, child, returnVariable, breakContext, continueContext);
            }

            if (!_mappedEmitters.TryGetValue(node.GetType(), out var emitter))
            {
                throw new EmissionException($"No emitter found that supports {node.GetType().Name}.");
            }

            emitter.Emit(instructionToNodeMapping, target, node, returnVariable, breakContext, continueContext);
        }

        internal static void UpdateBranches(
            Dictionary<Instruction, LogicNode> instructionToNodeMapping,
            MethodDefinition target,
            LogicNode node,
            VariableDefinition returnVariable,
            LogicNode breakContext,
            LogicNode continueContext)
        {
            foreach (var child in node.Children)
            {
                UpdateBranches(instructionToNodeMapping, target, child, returnVariable, breakContext, continueContext);
            }

            if (!_mappedEmitters.TryGetValue(node.GetType(), out var emitter))
            {
                throw new EmissionException($"No emitter found that supports {node.GetType().Name}.");
            }

            emitter.UpdateBranches(instructionToNodeMapping, target, node, returnVariable, breakContext, continueContext);
        }

        internal static void ComputeOffsets(MethodDefinition method)
        {
            ComputeOffsets(method.Body.Instructions[0]);

            foreach (var branch in method.Body.Instructions.Where(x => LongToShort.ContainsKey(x.OpCode)))
            {
                var target = (Instruction)branch.Operand;

                // 3 is the difference of 5 - 2 (br vs br.s offset)
                if (target.Offset <= 255 + 3)
                {
                    branch.OpCode = LongToShort[branch.OpCode];
                }

                ComputeOffsets(branch.Next);
            }
        }

        internal static void TrimReturnIfUnused(MethodDefinition method)
        {
            var returnInstruction = method.Body.Instructions.Last();

            // if the return isn't used due to an infinite loop somewhere in the code - only applcable to Actions
            if (returnInstruction.OpCode == OpCodes.Ret
                && (returnInstruction.Previous?.OpCode == OpCodes.Br || returnInstruction.Previous?.OpCode == OpCodes.Br_S)
                && method.Body.Instructions.All(x => x.Operand != returnInstruction))
            {
                method.Body.Instructions.Remove(returnInstruction);
            }
        }

        private static void ComputeOffsets(Instruction startFrom)
        {
            while (startFrom != null)
            {
                UpdateOffset(startFrom);
                startFrom = startFrom.Next;
            }
        }

        private static void UpdateOffset(Instruction instruction)
        {
            if (instruction.Previous == null)
            {
                instruction.Offset = 0;
                return;
            }

            var opCodeSize = 1;

            switch (instruction.Previous.OpCode.Code)
            {
                case Code.Constrained:
                case Code.Initobj:
                case Code.Ceq:
                case Code.Cgt:
                case Code.Cgt_Un:
                case Code.Ckfinite:
                case Code.Clt:
                case Code.Clt_Un:
                    opCodeSize = 2;
                    break;
            }

            int operandSize;

            if (instruction.Previous.Operand == null)
            {
                operandSize = 0;
            }
            else if (instruction.Previous.OpCode.ToString().EndsWith(".s"))
            {
                operandSize = 1;
            }
            else if (
                instruction.Previous.OpCode == OpCodes.Ldc_I8
                || instruction.Previous.OpCode == OpCodes.Ldc_R8)
            {
                operandSize = 8;
            }
            else
            {
                operandSize = 4;
            }

            instruction.Offset = instruction.Previous.Offset + opCodeSize + operandSize;
        }
    }
}
