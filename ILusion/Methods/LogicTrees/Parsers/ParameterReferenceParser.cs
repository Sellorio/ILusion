using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ParameterReferenceParser : IParser
    {
        public int Order => 0;

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

        public bool TryParse(ParsingContext parsingContext)
        {
            if (parsingContext.Instruction.OpCode == OpCodes.Ldarga || parsingContext.Instruction.OpCode == OpCodes.Ldarga_S)
            {
                return parsingContext.Success(new ParameterReferenceNode((ParameterDefinition)parsingContext.Instruction.Operand));
            }

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
                case Code.Ldarga:
                case Code.Ldarga_S:
                    return parsingContext.Success(new ParameterReferenceNode((ParameterDefinition)parsingContext.Instruction.Operand));
                default:
                    parameter = (ParameterDefinition)parsingContext.Instruction.Operand;
                    break;
            }

            if (!(parameter.ParameterType is ByReferenceType) || parsingContext.Instruction.Next?.OpCode == OpCodes.Ldobj)
            {
                return false;
            }

            return parsingContext.Success(new ParameterReferenceNode(parameter));
        }
    }
}
