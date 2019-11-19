using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ParameterAssignmentNode : LogicNode
    {
        public ValueNode Value { get; }
        public ParameterDefinition Parameter { get; }

        internal ParameterAssignmentNode(ValueNode value, ParameterDefinition parameter, IEnumerable<LogicNode> children)
            : base(children)
        {
            Value = value;
            Parameter = parameter;
        }

        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(Parameter.Index > 255 ? OpCodes.Starg : OpCodes.Starg, Parameter.Index) };
        }
    }
}
