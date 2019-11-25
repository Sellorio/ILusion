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

                for (var i = 0; i < parameters.Length; i++)
                {
                    if (constructor.Parameters[i].ParameterType.FullName == typeof(bool).FullName)
                    {
                        ParsingHelper.HandleBooleanLiteral(method, parameters[i]);
                    }
                }

                node = new NewNode(parameters, constructor.DeclaringType, constructor, children);
            }
            else // generic type initialization using `new T()`
            {
                var createInstanceInstance = (MethodReference)instruction.Operand;
                var createInstanceMethod = createInstanceInstance.Resolve();

                if (createInstanceMethod.DeclaringType.FullName != typeof(Activator).FullName)
                {
                    node = null;
                    consumedInstructions = 0;
                    return false;
                }
                else if (createInstanceMethod.Name != nameof(Activator.CreateInstance))
                {
                    node = null;
                    consumedInstructions = 0;
                    return false;
                }
                else if (!createInstanceMethod.HasGenericParameters)
                {
                    node = null;
                    consumedInstructions = 0;
                    return false;
                }

                var parameters = ParsingHelper.GetValueNodes(nodeStack, createInstanceMethod.Parameters.Count, out var children);

                node =
                    new NewNode(
                        parameters,
                        ((GenericInstanceMethod)createInstanceInstance).GenericArguments[0],
                        null,
                        children);
            }

            return true;
        }
    }
}
