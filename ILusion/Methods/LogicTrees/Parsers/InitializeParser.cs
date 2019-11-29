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

        public bool TryParse(ParsingContext parsingContext)
        {
            MethodDefinition constructor = null;
            var parameterCount = 0;

            if (parsingContext.Instruction.OpCode == OpCodes.Call)
            {
                constructor = ((MethodReference)parsingContext.Instruction.Operand).Resolve();

                if (constructor == null || !constructor.IsConstructor)
                {
                    return false;
                }

                parameterCount = constructor.Parameters.Count;
            }

            var valueNodes = ParsingHelper.GetValueNodes(parsingContext.NodeStack, parameterCount + 1, out var children);
            var target = valueNodes[0];

            if (!(target is ReferenceValueNode))
            {
                throw new ParsingException("Initialize target was expected to be an address/reference.");
            }

            return parsingContext.Success(new InitializeNode((ReferenceValueNode)target, valueNodes.Skip(1), constructor, children));
        }
    }
}
