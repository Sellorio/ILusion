using Mono.Cecil.Cil;
using System;

namespace ILusion.Methods.LogicTrees.Parsers.ControlBlocks.Switch
{
    internal sealed class SwitchExpressionParser : IParser
    {
        public int Order => 0;

        //private static readonly string[] _switchableTypes =
        //{
        //    typeof(byte).FullName,
        //    typeof(sbyte).FullName,
        //    typeof(short).FullName,
        //    typeof(ushort).FullName,
        //    typeof(int).FullName,
        //    typeof(uint).FullName,
        //    typeof(long).FullName,
        //    typeof(ulong).FullName
        //};

        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Beq,
            OpCodes.Beq_S,
            OpCodes.Brtrue,
            OpCodes.Brtrue_S,
            OpCodes.Brfalse,
            OpCodes.Brfalse_S,
            OpCodes.Bgt,
            OpCodes.Bgt_S,
            OpCodes.Switch
        };

        public bool TryParse(ParsingContext parsingContext)
        {
            throw new NotImplementedException();
        }
    }
}
