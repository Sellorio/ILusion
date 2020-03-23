using ILusion.Exceptions;
using ILusion.Methods.LogicTrees;
using ILusion.Methods.LogicTrees.Helpers;
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
                EmissionHelper.EmitInstructions(instructionToNodeMapping, methodDefinition, statement, returnVariable, null, null);
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

            foreach (var statement in Statements)
            {
                EmissionHelper.UpdateBranches(instructionToNodeMapping, methodDefinition, statement, returnVariable, null, null);
            }

            EmissionHelper.ComputeOffsets(methodDefinition);
            EmissionHelper.TrimReturnIfUnused(methodDefinition);
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

            if (trimmedInstructions == 2 && VariableHelper.GetReturnVariable(methodDefinition) == null
                || methodDefinition.Body.Instructions.LastOrDefault()?.OpCode != OpCodes.Ret)
            {
                trimmedInstructions = 0;
            }

            var instructionToNodeMapping = new Dictionary<Instruction, LogicNode>();
            var nodeStack = new Stack<LogicNode>();
            var instructionIndex = 0;

            while (methodDefinition.Body.Instructions.Count - trimmedInstructions > instructionIndex)
            {
                ParsingHelper.ParseInstruction(methodDefinition, ref instructionIndex, instructionToNodeMapping, nodeStack);
            }

            foreach (var branch in instructionToNodeMapping.Values.OfType<BranchNode>())
            {
                if (branch.OriginalTarget == null)
                {
                    continue;
                }

                if (!instructionToNodeMapping.TryGetValue(branch.OriginalTarget, out var target))
                {
                    throw new ParsingException("Failed to update branch node to point to a parsed node.");
                }

                branch.Target = target;
            }

            var statements = ParsingHelper.HandleElseBlocks(nodeStack.Reverse().ToList(), instructionToNodeMapping);

            return new SyntaxTree(statements);
        }
    }
}
