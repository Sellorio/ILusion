using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class VariableAssignmentParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Stloc,
            OpCodes.Stloc_S,
            OpCodes.Stloc_0,
            OpCodes.Stloc_1,
            OpCodes.Stloc_2,
            OpCodes.Stloc_3
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            VariableDefinition variable;

            switch (parsingContext.Instruction.OpCode.Code)
            {
                case Code.Stloc_0:
                    variable = parsingContext.Method.Body.Variables.First(x => x.Index == 0);
                    break;
                case Code.Stloc_1:
                    variable = parsingContext.Method.Body.Variables.First(x => x.Index == 1);
                    break;
                case Code.Stloc_2:
                    variable = parsingContext.Method.Body.Variables.First(x => x.Index == 2);
                    break;
                case Code.Stloc_3:
                    variable = parsingContext.Method.Body.Variables.First(x => x.Index == 3);
                    break;
                default:
                    variable = (VariableDefinition)parsingContext.Instruction.Operand;
                    break;
            }

            var value = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children)[0];

            if (variable.VariableType.FullName == typeof(bool).FullName)
            {
                ParsingHelper.HandleBooleanLiteral(parsingContext.Method, value);
            }

            return parsingContext.Success(new VariableAssignmentNode(variable, value, children));
        }
    }
}
