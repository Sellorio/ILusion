using ILusion.Exceptions;
using ILusion.Methods.LogicTrees;
using ILusion.Methods.LogicTrees.Emitters;
using ILusion.Methods.LogicTrees.Helpers;
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

        internal VariableDefinition ReturnVariable { get; }
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

            var returnVariable = VariableHelper.GetReturnVariable(methodDefinition);
            var instructionToNodeMapping = new Dictionary<Instruction, LogicNode>();

            methodDefinition.Body.Instructions.Clear();

            foreach (var statement in Statements)
            {
                EmitInstructions(instructionToNodeMapping, methodDefinition, statement, returnVariable);
            }

            if (returnVariable != null)
            {
                methodDefinition.Body.Instructions.Add(VariableHelper.CreateLoadVariableInstruction(returnVariable));
                methodDefinition.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
            }
            else if (methodDefinition.ReturnType.FullName == typeof(void).FullName)
            {
                methodDefinition.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
            }

            BranchHelper.UpdateBranchInstructions(instructionToNodeMapping, methodDefinition);
        }

        private static void EmitInstructions(
            Dictionary<Instruction, LogicNode> instructionToNodeMapping,
            MethodDefinition methodDefinition,
            LogicNode node,
            VariableDefinition returnVariable)
        {
            foreach (var child in node.Children)
            {
                EmitInstructions(instructionToNodeMapping, methodDefinition, child, returnVariable);
            }

            if (!_mappedEmitters.TryGetValue(node.GetType(), out var emitter))
            {
                throw new EmissionException($"No emitter found that supports {node.GetType().Name}.");
            }

            emitter.Emit(instructionToNodeMapping, methodDefinition, node, returnVariable);
        }

        public static SyntaxTree FromMethodDefinition(MethodDefinition methodDefinition)
        {
            if (methodDefinition.Body == null || methodDefinition.Body.Instructions.Count == 0)
            {
                throw new ParsingException("Method has no body.");
            }

            // most functions will use a variable to store the return value and then return but others may
            // return a value directly (notably, redirects to a base implementation in a virtual method).
            // this logic supports the 3 variations to return values
            var trimmedInstructions = methodDefinition.ReturnType.FullName == typeof(void).FullName ? 1 : 2;

            if (trimmedInstructions == 2 && VariableHelper.GetReturnVariable(methodDefinition) == null)
            {
                trimmedInstructions = 0;
            }

            var instructionToNodeMapping = new Dictionary<Instruction, LogicNode>();
            var nodeStack = new Stack<LogicNode>();
            var instructionIndex = 0;

            while (methodDefinition.Body.Instructions.Count - trimmedInstructions > instructionIndex)
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
                        instructionToNodeMapping.Add(instruction, node);
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

            foreach (var branch in instructionToNodeMapping.Values.OfType<BranchNode>())
            {
                if (!instructionToNodeMapping.TryGetValue(branch.OriginalTarget, out var target))
                {
                    throw new ParsingException("Failed to update branch node to point to a parsed node.");
                }

                branch.Target = target;
            }

            return new SyntaxTree(nodeStack.Reverse());
        }
    }
}
