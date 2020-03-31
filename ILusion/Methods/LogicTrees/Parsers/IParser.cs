using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal interface IParser
    {
        int Order { get; }
        OpCode[] CanTryParse { get; }
        bool TryParse(ParsingContext parsingContext);
    }
}
