using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class SubtractParser : IParser
    {
        public int Order => 0;

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Sub,
            OpCodes.Sub_Ovf,
            OpCodes.Sub_Ovf_Un
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var values = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 2, out var children);
            return parsingContext.Success(new SubtractNode(values[0], values[1], parsingContext.Instruction.OpCode != OpCodes.Sub, children));
        }
    }
}
