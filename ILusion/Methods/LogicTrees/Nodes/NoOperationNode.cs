﻿using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class NoOperationNode : LogicNode
    {
        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(OpCodes.Nop) };
        }
    }
}
