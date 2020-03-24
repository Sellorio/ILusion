using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class LessThanEmitterEmitter : EmitterBase<LessThanNode>
    {
        private static readonly string[] _typesUsingUnsignedOpCode =
        {
            "System.UInt32",
            "System.UInt64"
        };

        protected override void Emit(EmitterContext<LessThanNode> emitterContext)
        {
            if (_typesUsingUnsignedOpCode.Contains(emitterContext.Node.LeftOperand.GetValueType().FullName))
            {
                emitterContext.Emit(OpCodes.Clt_Un);
            }
            else
            {
                emitterContext.Emit(OpCodes.Clt);
            }
        }
    }
}
