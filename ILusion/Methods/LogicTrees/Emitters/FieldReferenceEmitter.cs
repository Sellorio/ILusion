using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class FieldReferenceEmitter : EmitterBase<FieldReferenceNode>
    {
        protected override void Emit(EmitterContext<FieldReferenceNode> emitterContext)
        {
            emitterContext.Emit(
                emitterContext.Node.Instance == null ? OpCodes.Ldsflda : OpCodes.Ldflda,
                emitterContext.Node.Field);
        }
    }
}
