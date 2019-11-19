using System;
using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class NewParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Newobj,
            OpCodes.Newarr,
            OpCodes.Call
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            consumedInstructions = 1;

            if (instruction.OpCode == OpCodes.Newarr)
            {
                var sizeParameter = ParsingHelper.GetValueNodes(nodeStack, 1, out var children);
                node = new NewNode(sizeParameter, new ArrayType((TypeReference)instruction.Operand), null, children);
            }
            else if (instruction.OpCode == OpCodes.Newobj)
            {
                var constructor = ((MethodReference)instruction.Operand).Resolve();
                var parameters = ParsingHelper.GetValueNodes(nodeStack, constructor.Parameters.Count, out var children);
                node = new NewNode(parameters, constructor.DeclaringType, constructor, children);
            }
            else // generic type initialization using `new T()`
            {
                var createInstanceMethod = ((MethodReference)instruction.Operand).Resolve();

                if (createInstanceMethod.DeclaringType.FullName != typeof(Activator).FullName
                    || createInstanceMethod.Name != nameof(Activator.CreateInstance)
                    || !createInstanceMethod.HasGenericParameters)
                {
                    node = null;
                    consumedInstructions = 0;
                    return false;
                }

                var parameters = ParsingHelper.GetValueNodes(nodeStack, createInstanceMethod.Parameters.Count, out var children);
                node = new NewNode(parameters, createInstanceMethod.DeclaringType, null, children);
            }

            return true;
        }
    }
}
