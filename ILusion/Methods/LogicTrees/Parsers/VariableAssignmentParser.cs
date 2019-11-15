using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class VariableAssignmentParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Stloc,
            OpCodes.Stloc_S,
            OpCodes.Stloc_0,
            OpCodes.Stloc_1,
            OpCodes.Stloc_2,
            OpCodes.Stloc_3
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            VariableDefinition variable;

            switch (instruction.OpCode.Code)
            {
                case Code.Stloc_0:
                    variable = method.Body.Variables.First(x => x.Index == 0);
                    break;
                case Code.Stloc_1:
                    variable = method.Body.Variables.First(x => x.Index == 1);
                    break;
                case Code.Stloc_2:
                    variable = method.Body.Variables.First(x => x.Index == 2);
                    break;
                case Code.Stloc_3:
                    variable = method.Body.Variables.First(x => x.Index == 3);
                    break;
                default:
                    variable = (VariableDefinition)instruction.Operand;
                    break;
            }

            var value = ParsingHelper.GetValueNodes(nodeStack, 1, out var children)[0];

            node = new VariableAssignmentNode(variable, value, children);
            consumedInstructions = 1;
            return true;
        }
    }
}
