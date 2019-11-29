using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ArrayLengthParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Ldlen
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var array = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children)[0];

            bool asLong;

            switch (parsingContext.Instruction.Next.OpCode.Code)
            {
                case Code.Conv_I4:
                    asLong = false;
                    break;
                case Code.Conv_I8:
                    asLong = true;
                    break;
                default:
                    throw new ParsingException("Expected a cast/conversion immediately following ldlen operation.");
            }

            return parsingContext.Success(new ArrayLengthNode(parsingContext.Method.Module.ImportReference(typeof(int)), array, asLong, children), 2);
        }
    }
}
