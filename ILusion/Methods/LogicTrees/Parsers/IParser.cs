using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal interface IParser
    {
        OpCode[] CanTryParse { get; }
        bool TryParse(ParsingContext parsingContext);
    }
}
