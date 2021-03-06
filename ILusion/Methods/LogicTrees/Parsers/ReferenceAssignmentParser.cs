﻿using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ReferenceAssignmentParser : IParser
    {
        public int Order => 0;

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Stobj,
            OpCodes.Stind_I1,
            OpCodes.Stind_I2,
            OpCodes.Stind_I4,
            OpCodes.Stind_I8,
            OpCodes.Stind_R4,
            OpCodes.Stind_R8,
            OpCodes.Stind_Ref
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var valueNodes = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 2, out var children);

            if (!(valueNodes[0] is ReferenceValueNode))
            {
                throw new ParsingException("Reference Assignment expected reference node on the stack.");
            }

            return parsingContext.Success(new ReferenceAssignmentNode((ReferenceValueNode)valueNodes[0], valueNodes[1], children));
        }
    }
}
