using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class FunctionCallNode : ValueNode
    {
        public MethodReference Method { get; }
        public ValueNode ThisNode { get; }
        public ValueNode[] ParameterNodes { get; }
        public bool IsBaseCall { get; }

        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(ThisNode == null || IsBaseCall ? OpCodes.Call : OpCodes.Callvirt, Method) };
        }

        internal override TypeReference GetValueType()
        {
            return Method.ReturnType;
        }
    }
}
