using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ReturnParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ret
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            if (method.ReturnType.FullName == typeof(void).FullName)
            {
                node = new ReturnNode(null, Enumerable.Empty<LogicNode>());
            }
            else
            {
                var returnValue = ParsingHelper.GetValueNodes(nodeStack, 1, out var children)[0];
                node = new ReturnNode(returnValue, children);
            }

            consumedInstructions = 1;
            return true;
        }
    }
}
