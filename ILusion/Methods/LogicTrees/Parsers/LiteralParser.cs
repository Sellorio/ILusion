using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class LiteralParser : IParser
    {
        public int Order => 0;

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldc_I4,
            OpCodes.Ldc_I4_0,
            OpCodes.Ldc_I4_1,
            OpCodes.Ldc_I4_2,
            OpCodes.Ldc_I4_3,
            OpCodes.Ldc_I4_4,
            OpCodes.Ldc_I4_5,
            OpCodes.Ldc_I4_6,
            OpCodes.Ldc_I4_7,
            OpCodes.Ldc_I4_8,
            OpCodes.Ldc_I4_M1,
            OpCodes.Ldc_I4_S,
            OpCodes.Ldc_I8,
            OpCodes.Ldc_R4,
            OpCodes.Ldc_R8,
            OpCodes.Ldstr,
            OpCodes.Ldnull
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            switch (parsingContext.Instruction.OpCode.Code)
            {
                case Code.Ldc_I4_S:
                    return
                        parsingContext.Success(
                            new LiteralNode(
                                parsingContext.Method.Module.ImportReference(typeof(int)),
                                (int)(sbyte)parsingContext.Instruction.Operand));
                case Code.Ldc_I4:
                case Code.Ldc_I8:
                case Code.Ldc_R4:
                case Code.Ldc_R8:
                case Code.Ldstr:
                    return
                        parsingContext.Success(
                            new LiteralNode(
                                parsingContext.Method.Module.ImportReference(parsingContext.Instruction.Operand.GetType()),
                                parsingContext.Instruction.Operand));
                case Code.Ldc_I4_0:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(int)), 0));
                case Code.Ldc_I4_1:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(int)), 1));
                case Code.Ldc_I4_2:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(int)), 2));
                case Code.Ldc_I4_3:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(int)), 3));
                case Code.Ldc_I4_4:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(int)), 4));
                case Code.Ldc_I4_5:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(int)), 5));
                case Code.Ldc_I4_6:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(int)), 6));
                case Code.Ldc_I4_7:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(int)), 7));
                case Code.Ldc_I4_8:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(int)), 8));
                case Code.Ldc_I4_M1:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(int)), -1));
                case Code.Ldnull:
                    return parsingContext.Success(new LiteralNode(parsingContext.Method.Module.ImportReference(typeof(object)), null));
                default:
                    throw new NotSupportedException("Internal Error: unexpected OpCode in parser.");
            }
        }
    }
}
