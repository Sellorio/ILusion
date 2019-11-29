using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class AsParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Isinst
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var nextInstruction = instruction.Next;
            var nextNextInstruction = nextInstruction?.Next;

            // skip set-load which may be for an Is expression with variable or it may be used in an If statement
            if ((nextInstruction?.OpCode.ToString().StartsWith("stloc") ?? false)
                && (nextNextInstruction?.OpCode.ToString().StartsWith("ldloc") ?? false)
                && VariableHelper.GetVariableFromInstruction(method, nextInstruction) == VariableHelper.GetVariableFromInstruction(method, nextNextInstruction))
            {
                nextInstruction = nextNextInstruction.Next;
                nextNextInstruction = nextInstruction?.Next;
            }

            // Brtrue means ?: expression using a boolean value, this it is an Is expression
            // Ldnull and Cgt.un means checking against null which could be an as with null check but more correct source code is to use an Is expression
            if (nextInstruction?.OpCode == OpCodes.Brtrue
                || nextInstruction?.OpCode == OpCodes.Brtrue_S
                || nextInstruction?.OpCode == OpCodes.Ldnull && nextNextInstruction?.OpCode == OpCodes.Cgt_Un)
            {
                node = null;
                consumedInstructions = 0;
                return false;
            }

            var value = ParsingHelper.GetValueNodes(nodeStack, 1, out var children)[0];
            node = new AsNode(value, (TypeReference)instruction.Operand, children);
            consumedInstructions = 1;
            return true;
        }
    }
}
