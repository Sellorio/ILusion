using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ReturnEmitter : EmitterBase<ReturnNode>
    {
        protected override void Emit(EmitterContext<ReturnNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Ret);
        }
    }
}
