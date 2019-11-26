using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ParameterReferenceEmitter : EmitterBase<ParameterReferenceNode>
    {
        protected override void Emit(EmitterContext<ParameterReferenceNode> emitterContext)
        {
            if (emitterContext.Node.Parameter.ParameterType is ByReferenceType)
            {
                switch (emitterContext.Node.Parameter.Index)
                {
                    case 0:
                        emitterContext.Emit(emitterContext.Target.IsStatic ? OpCodes.Ldarg_0 : OpCodes.Ldarg_1);
                        break;
                    case 1:
                        emitterContext.Emit(emitterContext.Target.IsStatic ? OpCodes.Ldarg_1 : OpCodes.Ldarg_2);
                        break;
                    case 2:
                        emitterContext.Emit(emitterContext.Target.IsStatic ? OpCodes.Ldarg_2 : OpCodes.Ldarg_3);
                        break;
                    case 3:
                        if (emitterContext.Target.IsStatic)
                        {
                            emitterContext.Emit(OpCodes.Ldarg_3);
                        }
                        else
                        {
                            emitterContext.Emit(OpCodes.Ldarg_S, 4);
                        }
                        break;
                    default:
                        emitterContext.Emit(
                            emitterContext.Node.Parameter.Index > 255 ? OpCodes.Ldarg : OpCodes.Ldarg_S,
                            emitterContext.Node.Parameter);
                        break;
                }
            }
            else
            {
                emitterContext.Emit(emitterContext.Node.Parameter.Index > 255 ? OpCodes.Ldarga : OpCodes.Ldarga_S, emitterContext.Node.Parameter);
            }
        }
    }
}
