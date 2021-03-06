﻿using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Methods.LogicTrees.Nodes.ControlBlocks;
using ILusion.Methods.LogicTrees.Parsers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
                .ToDictionary(x => x.Key, x => x.Select(y => y.Value).OrderBy(y => y.Order).ToArray());

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

        internal static bool ParseConditionalNodeCondition(
            Stack<LogicNode> nodeStack,
            out ValueNode condition,
            out VariableDefinition conditionResultVariable,
            out IReadOnlyList<LogicNode> nodes)
        {
            condition = null;
            conditionResultVariable = null;
            nodes = null;

            try
            {
                condition = GetValueNodes(nodeStack, 1, out nodes)[0];
            }
            catch
            {
                return false;
            }

            // setting then getting the same variable (a pattern used in conditionals)
            if (nodeStack.Peek() is VariableAssignmentNode variableAssignment2
                && condition is VariableNode variable
                && variableAssignment2.Variable == variable.Variable)
            {
                condition = variableAssignment2.Value;
                conditionResultVariable = variable.Variable;
                nodes = variableAssignment2.Children;

                nodeStack.Pop();
            }

            return true;
        }

        internal static IReadOnlyList<LogicNode> HandleElseBlocks(IReadOnlyList<LogicNode> statements, Dictionary<Instruction, LogicNode> instructionToNodeMapping)
        {
            if (!statements.Any(x => x is IfNode || x is LoopNode))
            {
                return statements;
            }

            var result = new List<LogicNode>();

            var goToTargetsSuggestingPresenceOfElse = statements.Select(x => instructionToNodeMapping.First(y => y.Value == NodeHelper.GetFirstRecursively(x)).Key).ToList();

            for (var i = 0; i < statements.Count; i++)
            {
                result.Add(statements[i]);

                if (statements[i] is IfNode ifNode)
                {
                    ifNode.TrueStatements = HandleElseBlocks(ifNode.TrueStatements, instructionToNodeMapping);

                    if (ifNode.TrueStatements.LastOrDefault() is GoToNode goTo)
                        if (goTo.OriginalTarget.Offset > instructionToNodeMapping.First(x => x.Value == goTo).Key.Offset)
                            if (goToTargetsSuggestingPresenceOfElse.Contains(goTo.OriginalTarget))
                            {
                                ifNode.TrueStatements = ImmutableArray.CreateRange(ifNode.TrueStatements.Take(ifNode.TrueStatements.Count - 1));
                                var afterElseStatement = statements.First(x => instructionToNodeMapping.First(y => y.Value == NodeHelper.GetFirstRecursively(x)).Key == goTo.OriginalTarget);
                                var elseStatements = new List<LogicNode>();

                                var j = i + 1;

                                for (; statements[j] != afterElseStatement; j++)
                                {
                                    elseStatements.Add(statements[j]);
                                }

                                i = j - 1;
                                ifNode.FalseStatements = HandleElseBlocks(elseStatements, instructionToNodeMapping);
                            }
                }
                else if (statements[i] is LoopNode loop)
                {
                    loop.Statements = HandleElseBlocks(loop.Statements, instructionToNodeMapping);
                }
            }

            return ImmutableArray.CreateRange(result);
        }
    }
}
