using System;
using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class CastParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Box,
            //OpCodes.Unbox,            this is not used by CSC
            OpCodes.Unbox_Any,
            OpCodes.Castclass,
            //OpCodes.Conv_I,           native int values not supported
            OpCodes.Conv_I1,
            OpCodes.Conv_I2,
            OpCodes.Conv_I4,
            OpCodes.Conv_I8,
            //OpCodes.Conv_Ovf_I,       native int values not supported
            OpCodes.Conv_Ovf_I1,
            OpCodes.Conv_Ovf_I1_Un,
            OpCodes.Conv_Ovf_I2,
            OpCodes.Conv_Ovf_I2_Un,
            OpCodes.Conv_Ovf_I4,
            OpCodes.Conv_Ovf_I4_Un,
            OpCodes.Conv_Ovf_I8,
            OpCodes.Conv_Ovf_I8_Un,
            //OpCodes.Conv_Ovf_I_Un,    native int values not supported
            //OpCodes.Conv_Ovf_U,       native int values not supported
            OpCodes.Conv_Ovf_U1,
            OpCodes.Conv_Ovf_U1_Un,
            OpCodes.Conv_Ovf_U2,
            OpCodes.Conv_Ovf_U2_Un,
            OpCodes.Conv_Ovf_U4,
            OpCodes.Conv_Ovf_U4_Un,
            OpCodes.Conv_Ovf_U8,
            //OpCodes.Conv_Ovf_U8_Un,   don't know how to produce this opcode
            //OpCodes.Conv_Ovf_U_Un,    native int values not supported
            OpCodes.Conv_R4,
            OpCodes.Conv_R8,
            OpCodes.Conv_R_Un,
            //OpCodes.Conv_U,           native int values not supported
            OpCodes.Conv_U1,
            OpCodes.Conv_U2,
            OpCodes.Conv_U4,
            OpCodes.Conv_U8
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var value = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children)[0];

            switch (parsingContext.Instruction.OpCode.Code)
            {
                case Code.Box:
                    if (((TypeReference)parsingContext.Instruction.Operand).FullName == typeof(bool).FullName)
                    {
                        ParsingHelper.HandleBooleanLiteral(parsingContext.Method, value);
                    }

                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(object)), false, children));
                case Code.Unbox_Any:
                    return parsingContext.Success(new CastNode(value, (TypeReference)parsingContext.Instruction.Operand, false, children));
                case Code.Castclass:
                    return parsingContext.Success(new CastNode(value, (TypeReference)parsingContext.Instruction.Operand, false, children));
                case Code.Conv_I1:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(sbyte)), false, children));
                case Code.Conv_I2:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(short)), false, children));
                case Code.Conv_I4:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(int)), false, children));
                case Code.Conv_I8:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(long)), false, children));
                case Code.Conv_Ovf_I1:
                case Code.Conv_Ovf_I1_Un:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(sbyte)), true, children));
                case Code.Conv_Ovf_I2:
                case Code.Conv_Ovf_I2_Un:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(short)), true, children));
                case Code.Conv_Ovf_I4:
                case Code.Conv_Ovf_I4_Un:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(int)), true, children));
                case Code.Conv_Ovf_I8:
                case Code.Conv_Ovf_I8_Un:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(long)), true, children));
                case Code.Conv_Ovf_U1:
                case Code.Conv_Ovf_U1_Un:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(byte)), true, children));
                case Code.Conv_Ovf_U2:
                case Code.Conv_Ovf_U2_Un:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(ushort)), true, children));
                case Code.Conv_Ovf_U4:
                case Code.Conv_Ovf_U4_Un:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(uint)), true, children));
                case Code.Conv_Ovf_U8:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(ulong)), true, children));
                case Code.Conv_R4:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(float)), true, children));
                case Code.Conv_R8:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(double)), true, children));
                case Code.Conv_R_Un:
                    if (parsingContext.Instruction.Next.OpCode == OpCodes.Conv_R4)
                    {
                        return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(float)), true, children), 2);
                    }
                    else if (parsingContext.Instruction.Next.OpCode == OpCodes.Conv_R8)
                    {
                        return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(double)), true, children), 2);
                    }
                    else
                    {
                        throw new ParsingException("Expected specific cast to either Single or Double.");
                    }
                case Code.Conv_U1:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(byte)), false, children));
                case Code.Conv_U2:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(ushort)), false, children));
                case Code.Conv_U4:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(uint)), false, children));
                case Code.Conv_U8:
                    return parsingContext.Success(new CastNode(value, parsingContext.Method.Module.ImportReference(typeof(ulong)), false, children));
                default:
                    throw new NotSupportedException("Internal Error: operation not parsed by parser.");
            }
        }
    }
}
