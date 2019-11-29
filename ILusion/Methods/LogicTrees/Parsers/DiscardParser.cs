﻿using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class DiscardParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Pop
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var value = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children)[0];
            return parsingContext.Success(new DiscardNode(value, children));
        }
    }
}
