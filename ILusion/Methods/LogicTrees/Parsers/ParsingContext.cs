using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal sealed class ParsingContext
    {
        internal MethodDefinition Method { get; }
        internal Stack<LogicNode> NodeStack { get; }
        internal Instruction Instruction { get; }
        internal Dictionary<Instruction, LogicNode> InstructionToNodeMapping { get; }

        internal bool Successful { get; private set; }
        internal int ConsumedInstructions { get; private set; }
        internal LogicNode Result { get; private set; }

        internal ParsingContext(MethodDefinition method, Stack<LogicNode> nodeStack, Instruction instruction, Dictionary<Instruction, LogicNode> instructionToNodeMapping)
        {
            Method = method;
            NodeStack = nodeStack;
            Instruction = instruction;
            InstructionToNodeMapping = instructionToNodeMapping;
        }

        internal bool Success(LogicNode result, int consumedInstructions = 1)
        {
            if (Result != null)
            {
                throw new InvalidOperationException("Can only set result once for a ParsingContext.");
            }

            Result = result;
            ConsumedInstructions = consumedInstructions;
            return true;
        }
    }
}
