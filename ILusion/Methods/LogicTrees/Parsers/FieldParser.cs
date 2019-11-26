using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class FieldParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldfld,
            OpCodes.Ldsfld
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var children = new LogicNode[0];
            var instance = instruction.OpCode == OpCodes.Ldsfld ? null : ParsingHelper.GetValueNodes(nodeStack, 1, out children)[0];
            node = new FieldNode(instance, (FieldReference)instruction.Operand, children);
            consumedInstructions = 1;
            return true;
        }
    }
}
