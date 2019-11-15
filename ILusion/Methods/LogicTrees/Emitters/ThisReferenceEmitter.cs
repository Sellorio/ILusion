using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ThisReferenceEmitter : EmitterBase<ThisReferenceNode>
    {
        protected override void Emit(EmitterContext<ThisReferenceNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Ldarga_S, 0);
        }
    }
}
