using System;
using System.Collections.Generic;
using System.Text;
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

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var value = ParsingHelper.GetValueNodes(nodeStack, 1, out var children)[0];
            consumedInstructions = 1;

            switch (instruction.OpCode.Code)
            {
                case Code.Box:
                    if (((TypeReference)instruction.Operand).FullName == typeof(bool).FullName)
                    {
                        ParsingHelper.HandleBooleanLiteral(method, value);
                    }

                    node = new CastNode(value, method.Module.ImportReference(typeof(object)), false, children);
                    break;
                case Code.Unbox_Any:
                    node = new CastNode(value, (TypeReference)instruction.Operand, false, children);
                    break;
                case Code.Castclass:
                    node = new CastNode(value, (TypeReference)instruction.Operand, false, children);
                    break;
                case Code.Conv_I1:
                    node = new CastNode(value, method.Module.ImportReference(typeof(sbyte)), false, children);
                    break;
                case Code.Conv_I2:
                    node = new CastNode(value, method.Module.ImportReference(typeof(short)), false, children);
                    break;
                case Code.Conv_I4:
                    node = new CastNode(value, method.Module.ImportReference(typeof(int)), false, children);
                    break;
                case Code.Conv_I8:
                    node = new CastNode(value, method.Module.ImportReference(typeof(long)), false, children);
                    break;
                case Code.Conv_Ovf_I1:
                case Code.Conv_Ovf_I1_Un:
                    node = new CastNode(value, method.Module.ImportReference(typeof(sbyte)), true, children);
                    break;
                case Code.Conv_Ovf_I2:
                case Code.Conv_Ovf_I2_Un:
                    node = new CastNode(value, method.Module.ImportReference(typeof(short)), true, children);
                    break;
                case Code.Conv_Ovf_I4:
                case Code.Conv_Ovf_I4_Un:
                    node = new CastNode(value, method.Module.ImportReference(typeof(int)), true, children);
                    break;
                case Code.Conv_Ovf_I8:
                case Code.Conv_Ovf_I8_Un:
                    node = new CastNode(value, method.Module.ImportReference(typeof(long)), true, children);
                    break;
                case Code.Conv_Ovf_U1:
                case Code.Conv_Ovf_U1_Un:
                    node = new CastNode(value, method.Module.ImportReference(typeof(byte)), true, children);
                    break;
                case Code.Conv_Ovf_U2:
                case Code.Conv_Ovf_U2_Un:
                    node = new CastNode(value, method.Module.ImportReference(typeof(ushort)), true, children);
                    break;
                case Code.Conv_Ovf_U4:
                case Code.Conv_Ovf_U4_Un:
                    node = new CastNode(value, method.Module.ImportReference(typeof(uint)), true, children);
                    break;
                case Code.Conv_Ovf_U8:
                    node = new CastNode(value, method.Module.ImportReference(typeof(ulong)), true, children);
                    break;
                case Code.Conv_R4:
                    node = new CastNode(value, method.Module.ImportReference(typeof(float)), true, children);
                    break;
                case Code.Conv_R8:
                    node = new CastNode(value, method.Module.ImportReference(typeof(double)), true, children);
                    break;
                case Code.Conv_R_Un:
                    consumedInstructions = 2;

                    if (instruction.Next.OpCode == OpCodes.Conv_R4)
                    {
                        node = new CastNode(value, method.Module.ImportReference(typeof(float)), true, children);
                    }
                    else if (instruction.Next.OpCode == OpCodes.Conv_R8)
                    {
                        node = new CastNode(value, method.Module.ImportReference(typeof(double)), true, children);
                    }
                    else
                    {
                        throw new ParsingException("Expected specific cast to either Single or Double.");
                    }

                    break;
                case Code.Conv_U1:
                    node = new CastNode(value, method.Module.ImportReference(typeof(byte)), false, children);
                    break;
                case Code.Conv_U2:
                    node = new CastNode(value, method.Module.ImportReference(typeof(ushort)), false, children);
                    break;
                case Code.Conv_U4:
                    node = new CastNode(value, method.Module.ImportReference(typeof(uint)), false, children);
                    break;
                case Code.Conv_U8:
                    node = new CastNode(value, method.Module.ImportReference(typeof(ulong)), false, children);
                    break;
                default:
                    throw new NotSupportedException("Internal Error: operation not parsed by parser.");
            }

            return true;
        }
    }
}
