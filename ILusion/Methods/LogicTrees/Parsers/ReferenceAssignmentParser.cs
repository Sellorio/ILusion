using System.Collections.Generic;
using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ReferenceAssignmentParser : IParser
    {
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

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            var valueNodes = ParsingHelper.GetValueNodes(nodeStack, 2, out var children);

            if (!(valueNodes[0] is ReferenceValueNode))
            {
                throw new ParsingException("Reference Assignment expected reference node on the stack.");
            }

            node = new ReferenceAssignmentNode((ReferenceValueNode)valueNodes[0], valueNodes[1], children);
            consumedInstructions = 1;
            return true;
        }
    }
}
