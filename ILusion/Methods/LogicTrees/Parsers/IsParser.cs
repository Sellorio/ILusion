using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class IsParser : IParser
    {
        public int Order => 0;

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Isinst
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var nextInstruction = parsingContext.Instruction.Next;
            var nextNextInstruction = nextInstruction?.Next;
            VariableDefinition castVariable = null;
            var consumedInstructions = 1;

            // Is with variable stores and then loads the variable value, if the next op codes are a condition then
            // it is an Is, otherwise it is an As.
            if (nextInstruction?.OpCode.ToString().StartsWith("stloc") ?? false)
            {
                if (!nextNextInstruction?.OpCode.ToString().StartsWith("ldloc") ?? false)
                {
                    return false;
                }

                castVariable = VariableHelper.GetVariableFromInstruction(parsingContext.Method, nextInstruction);

                if (castVariable == VariableHelper.GetVariableFromInstruction(parsingContext.Method, nextNextInstruction))
                {
                    nextInstruction = nextNextInstruction.Next;
                    nextNextInstruction = nextInstruction?.Next;
                    consumedInstructions += 2;
                }
                else
                {
                    return false;
                }
            }

            // Brtrue means ?: expression using a boolean value, this it is an Is expression
            if (nextInstruction?.OpCode == OpCodes.Brtrue || nextInstruction?.OpCode == OpCodes.Brtrue_S)
            {
            }
            // Ldnull and Cgt.un means checking against null which could be an as with null check but more correct source code is to use an Is expression
            else if (nextInstruction?.OpCode == OpCodes.Ldnull && nextNextInstruction?.OpCode == OpCodes.Cgt_Un)
            {
                consumedInstructions += 2;
            }
            else
            {
                return false;
            }

            var value = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children)[0];

            return
                parsingContext.Success(
                    new IsNode(
                        value,
                        (TypeReference)parsingContext.Instruction.Operand,
                        castVariable,
                        (TypeReference)parsingContext.Instruction.Operand,
                        children),
                    consumedInstructions);
        }
    }
}
