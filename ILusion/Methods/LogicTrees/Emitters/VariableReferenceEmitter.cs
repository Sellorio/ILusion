using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class VariableReferenceEmitter : EmitterBase<VariableReferenceNode>
    {
        protected override void Emit(EmitterContext<VariableReferenceNode> emitterContext)
        {
            emitterContext.Emit(emitterContext.Node.Variable.Index > 255 ? OpCodes.Ldloca : OpCodes.Ldloca_S, emitterContext.Node.Variable);
        }
    }
}
