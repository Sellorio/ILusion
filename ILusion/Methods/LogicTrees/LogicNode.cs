using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees
{
    public abstract class LogicNode
    {
        public IReadOnlyList<LogicNode> Children { get; }

        internal abstract Instruction ToInstruction();
    }
}
