using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class AsEmitter : EmitterBase<AsNode>
    {
        protected override void Emit(EmitterContext<AsNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Isinst, emitterContext.Node.TargetType);
        }
    }
}
