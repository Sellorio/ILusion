using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class VariableParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldloc,
            OpCodes.Ldloc_S,
            OpCodes.Ldloc_0,
            OpCodes.Ldloc_1,
            OpCodes.Ldloc_2,
            OpCodes.Ldloc_3
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            VariableDefinition variable;

            switch (parsingContext.Instruction.OpCode.Code)
            {
                case Code.Ldloc_0:
                    variable = parsingContext.Method.Body.Variables[0];
                    break;
                case Code.Ldloc_1:
                    variable = parsingContext.Method.Body.Variables[1];
                    break;
                case Code.Ldloc_2:
                    variable = parsingContext.Method.Body.Variables[2];
                    break;
                case Code.Ldloc_3:
                    variable = parsingContext.Method.Body.Variables[3];
                    break;
                default:
                    variable = (VariableDefinition)parsingContext.Instruction.Operand;
                    break;
            }

            return parsingContext.Success(new VariableNode(variable));
        }
    }
}
