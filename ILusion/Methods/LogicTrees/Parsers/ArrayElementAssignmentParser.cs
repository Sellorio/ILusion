using System.Collections.Generic;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ArrayElementAssignmentParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Stelem_Any,
            OpCodes.Stelem_I,
            OpCodes.Stelem_I1,
            OpCodes.Stelem_I2,
            OpCodes.Stelem_I4,
            OpCodes.Stelem_I8,
            OpCodes.Stelem_R4,
            OpCodes.Stelem_R8,
            OpCodes.Stelem_Ref
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var valueNodes = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 3, out var children);

            if (((ArrayType)valueNodes[0].GetValueType()).ElementType.FullName == typeof(bool).FullName)
            {
                ParsingHelper.HandleBooleanLiteral(parsingContext.Method, valueNodes[2]);
            }

            return parsingContext.Success(new ArrayElementAssignmentNode(valueNodes[0], valueNodes[1], valueNodes[2], children));
        }
    }
}
