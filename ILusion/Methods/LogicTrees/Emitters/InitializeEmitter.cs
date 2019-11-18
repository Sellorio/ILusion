using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class InitializeEmitter : EmitterBase<InitializeNode>
    {
        protected override void Emit(EmitterContext<InitializeNode> emitterContext)
        {
            if (emitterContext.Node.Constructor == null)
            {
                var pointerType = (PointerType)emitterContext.Node.Target.GetValueType();
                emitterContext.Emit(OpCodes.Initobj, pointerType.ElementType);
            }
            else
            {
                emitterContext.Emit(OpCodes.Call, emitterContext.Node.Constructor);
            }
        }
    }
}
