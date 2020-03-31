using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class NewParser : IParser
    {
        public int Order => 0;

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Newobj,
            OpCodes.Newarr,
            OpCodes.Call
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            if (parsingContext.Instruction.OpCode == OpCodes.Newarr)
            {
                var sizeParameter = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children);
                return parsingContext.Success(new NewNode(sizeParameter, new ArrayType((TypeReference)parsingContext.Instruction.Operand), null, children));
            }
            else if (parsingContext.Instruction.OpCode == OpCodes.Newobj)
            {
                var constructor = (MethodReference)parsingContext.Instruction.Operand;
                var parameters = ParsingHelper.GetValueNodes(parsingContext.NodeStack, constructor.Parameters.Count, out var children);

                for (var i = 0; i < parameters.Length; i++)
                {
                    if (constructor.Parameters[i].ParameterType.FullName == typeof(bool).FullName)
                    {
                        ParsingHelper.HandleBooleanLiteral(parsingContext.Method, parameters[i]);
                    }
                }

                return parsingContext.Success(new NewNode(parameters, constructor.DeclaringType, constructor, children));
            }
            else // generic type initialization using `new T()`
            {
                var createInstanceInstance = (MethodReference)parsingContext.Instruction.Operand;
                var createInstanceMethod = createInstanceInstance.Resolve();

                if (createInstanceMethod.DeclaringType.FullName != typeof(Activator).FullName)
                {
                    return false;
                }
                else if (createInstanceMethod.Name != nameof(Activator.CreateInstance))
                {
                    return false;
                }
                else if (!createInstanceMethod.HasGenericParameters)
                {
                    return false;
                }

                var parameters = ParsingHelper.GetValueNodes(parsingContext.NodeStack, createInstanceMethod.Parameters.Count, out var children);

                return
                    parsingContext.Success(
                        new NewNode(
                            parameters,
                            ((GenericInstanceMethod)createInstanceInstance).GenericArguments[0],
                            null,
                            children));
            }
        }
    }
}
