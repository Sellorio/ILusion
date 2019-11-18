using System;
using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class VariableParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldloc,
            OpCodes.Ldloc_S,
            OpCodes.Ldloc_0,
            OpCodes.Ldloc_1,
            OpCodes.Ldloc_2,
            OpCodes.Ldloc_3
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            consumedInstructions = 1;

            VariableDefinition variable;

            switch (instruction.OpCode.Code)
            {
                case Code.Ldloc_0:
                    variable = method.Body.Variables[0];
                    break;
                case Code.Ldloc_1:
                    variable = method.Body.Variables[1];
                    break;
                case Code.Ldloc_2:
                    variable = method.Body.Variables[2];
                    break;
                case Code.Ldloc_3:
                    variable = method.Body.Variables[3];
                    break;
                default:
                    variable = (VariableDefinition)instruction.Operand;
                    break;
            }

            node = new VariableNode(variable);
            return true;
        }
    }
}
