using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ParameterParser : IParser
    {
        private static readonly OpCode?[] _dereferenceOpCodes =
        {
            OpCodes.Ldind_I1,
            OpCodes.Ldind_I2,
            OpCodes.Ldind_I4,
            OpCodes.Ldind_I8,
            OpCodes.Ldind_R4,
            OpCodes.Ldind_R8,
            OpCodes.Ldind_Ref,
            OpCodes.Ldind_U1,
            OpCodes.Ldind_U2,
            OpCodes.Ldind_U4,
            OpCodes.Ldobj
        };

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldarg_0,
            OpCodes.Ldarg_1,
            OpCodes.Ldarg_2,
            OpCodes.Ldarg_3,
            OpCodes.Ldarg_S,
            OpCodes.Ldarg
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
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
                default:
                    parameter = (ParameterDefinition)instruction.Operand;
                    break;
            }

            if (parameter.ParameterType is ByReferenceType byRef)
            {
                if (!_dereferenceOpCodes.Contains(instruction.Next?.OpCode))
                {
                    consumedInstructions = 0;
                    node = null;
                    return false;
                }

                consumedInstructions = 2;
            }

            node = new ParameterNode(parameter);
            return true;
        }
    }
}
