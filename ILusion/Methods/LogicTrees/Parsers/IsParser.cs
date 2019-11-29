using System;
using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class IsParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Isinst
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var nextInstruction = instruction.Next;
            var nextNextInstruction = nextInstruction?.Next;
            VariableDefinition castVariable = null;
            consumedInstructions = 1;

            // Is with variable stores and then loads the variable value, if the next op codes are a condition then
            // it is an Is, otherwise it is an As.
            if (nextInstruction?.OpCode.ToString().StartsWith("stloc") ?? false)
            {
                if (!nextNextInstruction?.OpCode.ToString().StartsWith("ldloc") ?? false)
                {
                    node = null;
                    consumedInstructions = 0;
                    return false;
                }

                castVariable = VariableHelper.GetVariableFromInstruction(method, nextInstruction);

                if (castVariable == VariableHelper.GetVariableFromInstruction(method, nextNextInstruction))
                {
                    nextInstruction = nextNextInstruction.Next;
                    nextNextInstruction = nextInstruction?.Next;
                    consumedInstructions += 2;
                }
                else
                {
                    node = null;
                    consumedInstructions = 0;
                    return false;
                }
            }

            // Brtrue means ?: expression using a boolean value, this it is an Is expression
            if (nextInstruction?.OpCode == OpCodes.Brtrue || nextInstruction?.OpCode == OpCodes.Brtrue_S)
            {
            }
            // Ldnull and Cgt.un means checking against null which could be an as with null check but more correct source code is to use an Is expression
            else if (nextInstruction?.OpCode == OpCodes.Ldnull && nextNextInstruction?.OpCode == OpCodes.Cgt_Un)
            {
                consumedInstructions += 2;
            }
            else
            {
                node = null;
                consumedInstructions = 0;
                return false;
            }

            var value = ParsingHelper.GetValueNodes(nodeStack, 1, out var children)[0];
            node = new IsNode(value, (TypeReference)instruction.Operand, castVariable, (TypeReference)instruction.Operand, children);
            return true;
        }
    }
}
