using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ParameterAssignmentNode : LogicNode
    {
        public ParameterDefinition Parameter { get; }
        public LogicNode Value { get; }

        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(Parameter.Index > 255 ? OpCodes.Starg : OpCodes.Starg, Parameter.Index) };
        }
    }
}
