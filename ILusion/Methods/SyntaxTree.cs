using ILusion.Exceptions;
using ILusion.Methods.LogicTrees;
using ILusion.Methods.LogicTrees.Emitters;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Methods.LogicTrees.Parsers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ILusion.Tests")]

namespace ILusion.Methods
{
    public sealed class SyntaxTree
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

        private static readonly Dictionary<Type, IEmitter> _mappedEmitters =
            typeof(IEmitter).Assembly.GetTypes()
                .Where(x => !x.IsInterface && !x.IsAbstract && x.Namespace == typeof(IEmitter).Namespace && typeof(IEmitter).IsAssignableFrom(x))
                .Select(x => (IEmitter)Activator.CreateInstance(x))
                .ToDictionary(x => x.SupportedNode, x => x);

        public IReadOnlyList<LogicNode> Statements { get; }

        private SyntaxTree(IEnumerable<LogicNode> statements)
        {
            Statements = ImmutableArray.CreateRange(statements);
        }

        public void AppyTo(MethodDefinition methodDefinition)
        {
            if (methodDefinition.Body == null)
            {
                throw new ParsingException("Method does not support a body.");
            }

            var generatedVariables = new Dictionary<TypeReference, VariableDefinition>();

            methodDefinition.Body.Instructions.Clear();

            foreach (var statement in Statements)
            {
                EmitInstructions(methodDefinition, statement, generatedVariables);
            }
        }

        private static void EmitInstructions(
            MethodDefinition methodDefinition,
            LogicNode node,
            Dictionary<TypeReference, VariableDefinition> generatedVariables)
        {
            foreach (var child in node.Children)
            {
                EmitInstructions(methodDefinition, child, generatedVariables);
            }

            if (!_mappedEmitters.TryGetValue(node.GetType(), out var emitter))
            {
                throw new EmissionException($"No emitter found that supports {node.GetType().Name}.");
            }

            emitter.Emit(methodDefinition, node);
        }

        public static SyntaxTree FromMethodDefinition(MethodDefinition methodDefinition)
        {
            if (methodDefinition.Body == null || methodDefinition.Body.Instructions.Count == 0)
            {
                throw new ParsingException("Method has no body.");
            }

            var nodeStack = new Stack<LogicNode>();
            var instructionIndex = 0;

            while (methodDefinition.Body.Instructions.Count > instructionIndex)
            {
                var instruction = methodDefinition.Body.Instructions[instructionIndex];

                if (!_mappedParsers.TryGetValue(instruction.OpCode, out var parsers))
                {
                    throw new ParsingException("OpCode " + instruction.OpCode + " is not supported by any parsers.");
                }

                var instructionParsed = false;

                foreach (var parser in parsers)
                {
                    var successful = parser.TryParse(methodDefinition, instruction, nodeStack, out var node, out var consumedInstructions);
                    
                    if (successful)
                    {
                        nodeStack.Push(node);
                        instructionParsed = true;
                        instructionIndex += consumedInstructions;
                        break;
                    }
                }

                if (!instructionParsed)
                {
                    throw new ParsingException($"Failed to parse instruction ({instruction}).");
                }
            }

            return new SyntaxTree(nodeStack.Reverse());
        }
    }
}
