using System;
using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class LiteralParser : IParser
    {
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

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            consumedInstructions = 1;

            switch (instruction.OpCode.Code)
            {
                case Code.Ldc_I4:
                case Code.Ldc_I4_S:
                case Code.Ldc_I8:
                case Code.Ldc_R4:
                case Code.Ldc_R8:
                case Code.Ldstr:
                    node = new LiteralNode(instruction.Operand);
                    break;
                case Code.Ldc_I4_0:
                    node = new LiteralNode(0);
                    break;
                case Code.Ldc_I4_1:
                    node = new LiteralNode(1);
                    break;
                case Code.Ldc_I4_2:
                    node = new LiteralNode(2);
                    break;
                case Code.Ldc_I4_3:
                    node = new LiteralNode(3);
                    break;
                case Code.Ldc_I4_4:
                    node = new LiteralNode(4);
                    break;
                case Code.Ldc_I4_5:
                    node = new LiteralNode(5);
                    break;
                case Code.Ldc_I4_6:
                    node = new LiteralNode(6);
                    break;
                case Code.Ldc_I4_7:
                    node = new LiteralNode(7);
                    break;
                case Code.Ldc_I4_8:
                    node = new LiteralNode(8);
                    break;
                case Code.Ldc_I4_M1:
                    node = new LiteralNode(-1);
                    break;
                case Code.Ldnull:
                    node = new LiteralNode(null);
                    break;
                default:
                    throw new NotSupportedException("Internal Error: unexpected OpCode in parser.");
            }

            return true;
        }
    }
}
