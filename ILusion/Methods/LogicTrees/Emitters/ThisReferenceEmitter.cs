using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ThisReferenceEmitter : EmitterBase<ThisReferenceNode>
    {
        protected override void Emit(EmitterContext<ThisReferenceNode> emitterContext)
        {
            if (emitterContext.Target.DeclaringType.IsValueType)
            {
                emitterContext.Emit(OpCodes.Ldarg_0);
            }
            else
            {
                emitterContext.Emit(OpCodes.Ldarga_S, 0);
            }
        }
    }
}
