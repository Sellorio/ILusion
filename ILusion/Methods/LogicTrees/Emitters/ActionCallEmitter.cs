using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ActionCallEmitter : EmitterBase<ActionCallNode>
    {
        protected override void Emit(EmitterContext<ActionCallNode> emitterContext)
        {
            emitterContext.Emit(
                emitterContext.Node.Instance == null || emitterContext.Node.IsBaseCall ? OpCodes.Call : OpCodes.Callvirt,
                emitterContext.Node.Method);
        }
    }
}
