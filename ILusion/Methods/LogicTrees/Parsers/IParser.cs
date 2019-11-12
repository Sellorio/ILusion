﻿using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal interface IParser
    {
        OpCode[] CanTryParse { get; }
        bool TryParse(Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions);
    }
}
