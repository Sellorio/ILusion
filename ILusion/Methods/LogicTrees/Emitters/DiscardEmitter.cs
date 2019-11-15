using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class DiscardEmitter : EmitterBase<DiscardNode>
    {
        protected override void Emit(EmitterContext<DiscardNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Pop);
        }
    }
}
