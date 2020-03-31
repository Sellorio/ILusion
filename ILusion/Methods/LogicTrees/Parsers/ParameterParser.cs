using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ParameterParser : IParser
    {
        public int Order => 0;

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

        public bool TryParse(ParsingContext parsingContext)
        {
            if (parsingContext.Instruction.OpCode == OpCodes.Ldarg_0 && !parsingContext.Method.IsStatic)
            {
                return false;
            }

            ParameterDefinition parameter;

            switch (parsingContext.Instruction.OpCode.Code)
            {
                case Code.Ldarg_0:
                    parameter = parsingContext.Method.Parameters[0];
                    break;
                case Code.Ldarg_1:
                    parameter = parsingContext.Method.Parameters[parsingContext.Method.IsStatic ? 1 : 0];
                    break;
                case Code.Ldarg_2:
                    parameter = parsingContext.Method.Parameters[parsingContext.Method.IsStatic ? 2 : 1];
                    break;
                case Code.Ldarg_3:
                    parameter = parsingContext.Method.Parameters[parsingContext.Method.IsStatic ? 3 : 2];
                    break;
                default:
                    parameter = (ParameterDefinition)parsingContext.Instruction.Operand;
                    break;
            }

            if (parameter.ParameterType is ByReferenceType byRef)
            {
                if (!_dereferenceOpCodes.Contains(parsingContext.Instruction.Next?.OpCode))
                {
                    return false;
                }

                return parsingContext.Success(new ParameterNode(parameter), 2);
            }

            return parsingContext.Success(new ParameterNode(parameter));
        }
    }
}
