using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ThisEmitter : EmitterBase<ThisNode>
    {
        protected override void Emit(EmitterContext<ThisNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Ldarg_0);

            if (emitterContext.Target.DeclaringType.IsValueType)
            {
                emitterContext.Emit(OpCodes.Ldobj, emitterContext.Target.DeclaringType);
            }
        }
    }
}
