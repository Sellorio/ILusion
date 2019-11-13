using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class NoOperationEmitter : EmitterBase<NoOperationNode>
    {
        protected override void Emit(EmitterContext<NoOperationNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Nop);
        }
    }
}
