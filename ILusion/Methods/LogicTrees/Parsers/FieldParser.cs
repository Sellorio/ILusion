using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class FieldParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldfld,
            OpCodes.Ldsfld
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            IReadOnlyList<LogicNode> children = new LogicNode[0];
            var instance = parsingContext.Instruction.OpCode == OpCodes.Ldsfld ? null : ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out children)[0];
            return parsingContext.Success(new FieldNode(instance, (FieldReference)parsingContext.Instruction.Operand, children));
        }
    }
}
