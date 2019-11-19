using System.Collections.Generic;
using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ArrayLengthParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldlen
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var array = ParsingHelper.GetValueNodes(nodeStack, 1, out var children)[0];

            bool asLong;

            switch (instruction.Next.OpCode.Code)
            {
                case Code.Conv_I4:
                    asLong = false;
                    break;
                case Code.Conv_I8:
                    asLong = true;
                    break;
                default:
                    throw new ParsingException("Expected a cast/conversion immediately following ldlen operation.");
            }

            node = new ArrayLengthNode(method.Module.ImportReference(typeof(int)), array, asLong, children);
            consumedInstructions = 2;
            return true;
        }
    }
}
