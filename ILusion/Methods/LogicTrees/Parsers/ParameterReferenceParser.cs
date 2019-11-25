using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ParameterReferenceParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldarga,
            OpCodes.Ldarga_S,
            OpCodes.Ldarg_0,
            OpCodes.Ldarg_1,
            OpCodes.Ldarg_2,
            OpCodes.Ldarg_3,
            OpCodes.Ldarg_S,
            OpCodes.Ldarg
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            if (instruction.OpCode == OpCodes.Ldarga || instruction.OpCode == OpCodes.Ldarga_S)
            {
                node = new ParameterReferenceNode((ParameterDefinition)instruction.Operand);
                consumedInstructions = 1;
                return true;
            }

            if (instruction.OpCode == OpCodes.Ldarg_0 && !method.IsStatic)
            {
                node = null;
                consumedInstructions = 0;
                return false;
            }

            consumedInstructions = 1;

            ParameterDefinition parameter;

            switch (instruction.OpCode.Code)
            {
                case Code.Ldarg_0:
                    parameter = method.Parameters[0];
                    break;
                case Code.Ldarg_1:
                    parameter = method.Parameters[method.IsStatic ? 1 : 0];
                    break;
                case Code.Ldarg_2:
                    parameter = method.Parameters[method.IsStatic ? 2 : 1];
                    break;
                case Code.Ldarg_3:
                    parameter = method.Parameters[method.IsStatic ? 3 : 2];
                    break;
                case Code.Ldarga:
                case Code.Ldarga_S:
                    node = new ParameterReferenceNode((ParameterDefinition)instruction.Operand);
                    consumedInstructions = 1;
                    return true;
                default:
                    parameter = (ParameterDefinition)instruction.Operand;
                    break;
            }

            if (!(parameter.ParameterType is ByReferenceType) || instruction.Next?.OpCode == OpCodes.Ldobj)
            {
                consumedInstructions = 0;
                node = null;
                return false;
            }

            node = new ParameterReferenceNode(parameter);
            return true;
        }
    }
}
