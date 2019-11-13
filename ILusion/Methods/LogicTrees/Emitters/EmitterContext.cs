using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class EmitterContext<TNode>
        where TNode : LogicNode
    {
        public MethodDefinition Target { get; }
        public TNode Node { get; }

        public EmitterContext<TNode> Emit(OpCode opCode)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, ParameterDefinition operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, VariableDefinition operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, Instruction[] operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, Instruction operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, double operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, float operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, long operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, byte operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, sbyte operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, string operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, FieldReference operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, MethodReference operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, CallSite operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, TypeReference operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }

        public EmitterContext<TNode> Emit(OpCode opCode, int operand)
        {
            Target.Body.Instructions.Add(Instruction.Create(opCode, operand));
            return this;
        }
    }
}
