using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using System.Collections.Generic;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Helpers
{
    internal static class ParsingHelper
    {
        internal static ValueNode[] GetValueNodes(Stack<LogicNode> nodeStack, int count, out LogicNode[] nodes, bool popNodes = true)
        {
            if (count == 0)
            {
                nodes = new LogicNode[0];
                return new ValueNode[0];
            }

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

            if (popNodes)
            {
                foreach (var node in gatheredNodes)
                {
                    nodeStack.Pop();
                }
            }

            nodes = Enumerable.Reverse(gatheredNodes).ToArray();

            return gatheredNodes.OfType<ValueNode>().Reverse().ToArray();
        }

        internal static void HandleBooleanLiteral(MethodDefinition method, ValueNode valueNode)
        {
            if (valueNode is LiteralNode literal && literal.Value is int integer && (integer == 0 || integer == 1))
            {
                literal.ChangeValue(method.Module.ImportReference(typeof(bool)), integer == 1);
            }
        }
    }
}
