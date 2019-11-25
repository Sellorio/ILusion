using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ParameterAssignmentParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Starg,
            OpCodes.Starg_S
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var value = ParsingHelper.GetValueNodes(nodeStack, 1, out var children)[0];
            node = new ParameterAssignmentNode(value, (ParameterDefinition)instruction.Operand, children);
            consumedInstructions = 1;
            return true;
        }
    }
}
