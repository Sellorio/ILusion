using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class NotEmitter : EmitterBase<NotNode>
    {
        protected override void Emit(EmitterContext<NotNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Ldc_I4_0);
            emitterContext.Emit(OpCodes.Ceq);
        }
    }
}
