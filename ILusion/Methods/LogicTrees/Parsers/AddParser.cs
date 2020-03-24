using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class AddParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Add,
            OpCodes.Add_Ovf,
            OpCodes.Add_Ovf_Un
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            var values = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 2, out var children);
            return parsingContext.Success(new AddNode(values[0], values[1], parsingContext.Instruction.OpCode != OpCodes.Add, children));
        }
    }
}
