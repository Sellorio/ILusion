using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class DiscardParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Pop
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var value = ParsingHelper.GetValueNodes(nodeStack, 1, out var children)[0];
            node = new DiscardNode(value, children);
            consumedInstructions = 1;
            return true;
        }
    }
}
