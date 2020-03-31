using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class SubtractEmitter : EmitterBase<SubtractNode>
    {
        private static readonly string[] _typesUsingUnsignedOpCode =
        {
            "System.UInt32",
            "System.UInt64"
        };

        protected override void Emit(EmitterContext<SubtractNode> emitterContext)
        {
            if (emitterContext.Node.ThrowOnOverflow)
            {
                if (_typesUsingUnsignedOpCode.Contains(emitterContext.Node.GetValueType().FullName))
                {
                    emitterContext.Emit(OpCodes.Sub_Ovf_Un);
                }
                else
                {
                    emitterContext.Emit(OpCodes.Sub_Ovf);
                }
            }
            else
            {
                emitterContext.Emit(OpCodes.Sub);
            }
        }
    }
}
