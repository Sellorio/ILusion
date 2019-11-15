using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class VariableAssignmentNode : LogicNode
    {
        public VariableDefinition Variable { get; }
        public ValueNode Value { get; }

        internal VariableAssignmentNode(VariableDefinition variable, ValueNode value, IEnumerable<LogicNode> children)
            : base(children)
        {
            Variable = variable;
            Value = value;
        }

        internal override Instruction[] ToInstructions()
        {
            OpCode opCode;
            var specifyIndex = false;

            switch (Variable.Index)
            {
                case 0:
                    opCode = OpCodes.Stloc_0;
                    break;
                case 1:
                    opCode = OpCodes.Stloc_1;
                    break;
                case 2:
                    opCode = OpCodes.Stloc_2;
                    break;
                case 3:
                    opCode = OpCodes.Stloc_3;
                    break;
                default:
                    specifyIndex = true;
                    opCode = Variable.Index > 255 ? OpCodes.Stloc : OpCodes.Stloc;
                    break;
            }

            return new[] { specifyIndex ? Instruction.Create(opCode, Variable.Index) : Instruction.Create(opCode) };
        }
    }
}
