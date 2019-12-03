using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Methods.LogicTrees.Parsers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Helpers
{
    internal static class ParsingHelper
    {
        private static readonly IParser[] _parsers =
            typeof(IParser).Assembly.GetTypes()
                .Where(x => !x.IsInterface && !x.IsAbstract && x.Namespace == typeof(IParser).Namespace && typeof(IParser).IsAssignableFrom(x))
                .Select(x => (IParser)Activator.CreateInstance(x))
                .ToArray();

        private static readonly Dictionary<OpCode, IParser[]> _mappedParsers =
            _parsers
                .SelectMany(x => x.CanTryParse.Select(y => new KeyValuePair<OpCode, IParser>(y, x)))
                .GroupBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Select(y => y.Value).ToArray());

        internal static ValueNode[] GetValueNodes(Stack<LogicNode> nodeStack, int count, out IReadOnlyList<LogicNode> nodes, bool popNodes = true)
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

        internal static IEnumerable<LogicNode> ParseBlock(
            MethodDefinition methodDefinition,
            Dictionary<Instruction, LogicNode> instructionToNodeMapping,
            Instruction inclusiveStart,
            Instruction exclusiveEnd)
        {
            var nodeStack = new Stack<LogicNode>();
            var index = methodDefinition.Body.Instructions.IndexOf(inclusiveStart);

            while (methodDefinition.Body.Instructions[index] != exclusiveEnd)
            {
                ParseInstruction(methodDefinition, ref index, instructionToNodeMapping, nodeStack);
            }

            return nodeStack.Reverse();
        }

        internal static void ParseInstruction(
            MethodDefinition methodDefinition,
            ref int instructionIndex,
            Dictionary<Instruction, LogicNode> instructionToNodeMapping,
            Stack<LogicNode> nodeStack)
        {
            var instruction = methodDefinition.Body.Instructions[instructionIndex];

            if (!_mappedParsers.TryGetValue(instruction.OpCode, out var parsers))
            {
                throw new ParsingException("OpCode " + instruction.OpCode + " is not supported by any parsers.");
            }

            var parsingContext = new ParsingContext(methodDefinition, nodeStack, instruction, instructionToNodeMapping);
            var instructionParsed = false;

            foreach (var parser in parsers)
            {
                if (parser.TryParse(parsingContext))
                {
                    instructionToNodeMapping.Add(instruction, parsingContext.Result);
                    nodeStack.Push(parsingContext.Result);
                    instructionParsed = true;
                    instructionIndex += parsingContext.ConsumedInstructions;
                    break;
                }
            }

            if (!instructionParsed)
            {
                throw new ParsingException($"Failed to parse instruction ({instruction}).");
            }
        }

        internal static ValueNode ParseConditionalNodeCondition(
            Stack<LogicNode> nodeStack,
            out VariableDefinition conditionResultVariable,
            out IReadOnlyList<LogicNode> nodes)
        {
            // for While True loops - the syntax is a bit different
            if (nodeStack.Peek() is VariableAssignmentNode variableAssignment
                && variableAssignment.Value is LiteralNode literal
                && true.Equals(literal.Value))
            {
                nodeStack.Pop();
                conditionResultVariable = variableAssignment.Variable;
                nodes = new[] { literal };
                return literal;
            }

            var condition = GetValueNodes(nodeStack, 1, out nodes)[0];
            conditionResultVariable = null;

            if (nodeStack.Peek() is VariableAssignmentNode variableAssignment2
                && condition is VariableNode variable
                && variableAssignment2.Variable == variable.Variable)
            {
                condition = variableAssignment2.Value;
                conditionResultVariable = variable.Variable;
                nodes = variableAssignment2.Children;

                nodeStack.Pop();
            }

            return condition;
        }
    }
}
