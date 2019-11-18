using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ArrayElementReferenceParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldelema
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var valueNodes = ParsingHelper.GetValueNodes(nodeStack, 2, out var children);
            node = new ArrayElementReferenceNode(valueNodes[0], valueNodes[1], children);
            consumedInstructions = 1;
            return true;
        }
    }
}
