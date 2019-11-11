using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ActionCallNode : LogicNode
    {
        public MethodReference Method { get; }
        public ValueNode ThisNode { get; }
        public ValueNode[] ParameterNodes { get; }
        public bool IsBaseCall { get; }

        internal override Instruction ToInstruction()
        {
            return Instruction.Create(ThisNode == null || IsBaseCall ? OpCodes.Call : OpCodes.Callvirt, Method);
        }
    }
}
