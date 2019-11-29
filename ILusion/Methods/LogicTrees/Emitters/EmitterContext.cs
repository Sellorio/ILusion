using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class EmitterContext<TNode>
        where TNode : LogicNode
    {
        private readonly Dictionary<Instruction, LogicNode> _instructionToNodeMapping;

        public MethodDefinition Target { get; }
        public TNode Node { get; }
        public VariableDefinition ReturnVariable { get; }

        internal EmitterContext(Dictionary<Instruction, LogicNode> instructionToNodeMapping, MethodDefinition target, TNode node, VariableDefinition returnVariable)
        {
            _instructionToNodeMapping = instructionToNodeMapping;
            Target = target;
            Node = node;
            ReturnVariable = returnVariable;
        }

        public EmitterContext<TNode> Emit(OpCode opCode)
        {
            return Add(Instruction.Create(opCode));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, ParameterDefinition operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, VariableDefinition operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, Instruction[] operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, Instruction operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, double operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, float operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, long operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, byte operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, sbyte operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, string operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, FieldReference operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, MethodReference operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, CallSite operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, TypeReference operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        public EmitterContext<TNode> Emit(OpCode opCode, int operand)
        {
            return Add(Instruction.Create(opCode, operand));
        }

        /// <summary>
        /// Emits a temporary branch instruction. After all instructions for the method have been
        /// emitted, the links between branches and their targets will be updated using <see cref="BranchNode.Target"/>.
        /// </summary>
        /// <param name="opCode">
        ///     The branch op code to use. Only <see cref="OpCodes.Br"/>, <see cref="OpCodes.Br_S"/>,
        ///     <see cref="OpCodes.Brfalse"/>, <see cref="OpCodes.Brfalse_S"/>, <see cref="OpCodes.Brtrue"/> and
        ///     <see cref="OpCodes.Brtrue_S"/> are permitted.
        /// </param>
        /// <returns></returns>
        public EmitterContext<TNode> EmitBranch(OpCode opCode)
        {
            if (!typeof(BranchNode).IsAssignableFrom(typeof(TNode)) && typeof(TNode) != typeof(ReturnNode))
            {
                throw new EmissionException("Can only emit branch instruction from a BranchNode and ReturnNode.");
            }

            if (Target.Body.Instructions.Count == 0)
            {
                throw new EmissionException("A branch cannot be the first instruction in a method.");
            }

            return Add(Instruction.Create(opCode, Target.Body.Instructions[0]));
        }

        private EmitterContext<TNode> Add(Instruction instruction)
        {
            Target.Body.Instructions.Add(instruction);
            _instructionToNodeMapping.Add(instruction, Node);
            return this;
        }
    }
}
