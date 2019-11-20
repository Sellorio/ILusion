using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class GoToEmitter : EmitterBase<GoToNode>
    {
        protected override void Emit(EmitterContext<GoToNode> emitterContext)
        {
            emitterContext.EmitBranch(OpCodes.Br);
        }
    }
}
