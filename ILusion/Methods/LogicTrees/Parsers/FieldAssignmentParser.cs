using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class FieldAssignmentParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Stfld,
            OpCodes.Stsfld
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var isStatic = instruction.OpCode == OpCodes.Stsfld;
            var valueNodes = ParsingHelper.GetValueNodes(nodeStack, isStatic ? 1 : 2, out var children);
            node = new FieldAssignmentNode(isStatic ? null : valueNodes[0], valueNodes[isStatic ? 0 : 1], (FieldReference)instruction.Operand, children);
            consumedInstructions = 1;
            return true;
        }
    }
}
