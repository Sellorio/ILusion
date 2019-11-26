using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class FieldEmitter : EmitterBase<FieldNode>
    {
        protected override void Emit(EmitterContext<FieldNode> emitterContext)
        {
            emitterContext.Emit(emitterContext.Node.Instance == null ? OpCodes.Ldsfld : OpCodes.Ldfld, emitterContext.Node.Field);
        }
    }
}
