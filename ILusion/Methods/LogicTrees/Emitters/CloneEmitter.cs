using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class CloneEmitter : EmitterBase<CloneNode>
    {
        protected override void Emit(EmitterContext<CloneNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Dup);
        }
    }
}
