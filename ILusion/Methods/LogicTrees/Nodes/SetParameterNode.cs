using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class SetParameterNode : LogicNode
    {
        public ParameterDefinition Parameter { get; }
        public LogicNode Value { get; }

        internal override Instruction ToInstruction()
        {
            return Instruction.Create(Parameter.Index > 255 ? OpCodes.Starg : OpCodes.Starg, Parameter.Index);
        }
    }
}
