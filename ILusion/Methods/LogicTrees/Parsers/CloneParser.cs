using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class CloneParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Dup
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            node = new CloneNode(ParsingHelper.GetValueNodes(nodeStack, 1, out _, popNodes: false)[0]);
            consumedInstructions = 1;
            return true;
        }
    }
}
