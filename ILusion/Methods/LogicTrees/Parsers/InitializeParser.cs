using System.Collections.Generic;
using System.Linq;
using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class InitializeParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Initobj,
            OpCodes.Call
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            MethodDefinition constructor = null;
            var parameterCount = 0;

            if (instruction.OpCode == OpCodes.Call)
            {
                constructor = ((MethodReference)instruction.Operand).Resolve();

                if (constructor == null || !constructor.IsConstructor)
                {
                    node = null;
                    consumedInstructions = 0;
                    return false;
                }

                parameterCount = constructor.Parameters.Count;
            }

            var valueNodes = ParsingHelper.GetValueNodes(nodeStack, parameterCount + 1, out var children);
            var target = valueNodes[0];

            if (!(target is ReferenceValueNode))
            {
                throw new ParsingException("Initialize target was expected to be an address/reference.");
            }

            node = new InitializeNode((ReferenceValueNode)target, valueNodes.Skip(1), constructor, children);
            consumedInstructions = 1;
            return true;
        }
    }
}
