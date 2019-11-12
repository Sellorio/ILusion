using ILusion.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Helpers
{
    internal static class ParsingHelper
    {
        internal static ValueNode[] GetValueNodes(Stack<LogicNode> nodeStack, int count, out LogicNode[] nodes)
        {
            var gatheredNodes = new List<LogicNode>();
            var valueNodeCount = 0;

            foreach (var node in nodeStack)
            {
                gatheredNodes.Add(node);

                if (node is ValueNode)
                {
                    valueNodeCount++;

                    if (valueNodeCount == count)
                    {
                        break;
                    }
                }
            }

            if (valueNodeCount < count)
            {
                throw new ParsingException("Insufficient values on the evaluation stack.");
            }

            foreach (var node in gatheredNodes)
            {
                nodeStack.Pop();
            }

            nodes = gatheredNodes.ToArray();

            return gatheredNodes.OfType<ValueNode>().Reverse().ToArray();
        }
    }
}
