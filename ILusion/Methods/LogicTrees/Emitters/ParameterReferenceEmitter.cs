using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ParameterReferenceEmitter : EmitterBase<ParameterReferenceNode>
    {
        protected override void Emit(EmitterContext<ParameterReferenceNode> emitterContext)
        {
            emitterContext.Emit(emitterContext.Node.Parameter.Index > 255 ? OpCodes.Ldarga : OpCodes.Ldarga_S, emitterContext.Node.Parameter);
        }
    }
}
