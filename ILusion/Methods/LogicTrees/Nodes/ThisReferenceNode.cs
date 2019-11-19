using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ThisReferenceNode : ReferenceValueNode
    {
        internal ThisReferenceNode()
            : base(Enumerable.Empty<LogicNode>())
        {
        }

        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(OpCodes.Ldarga_S, 0) };
        }
    }
}
