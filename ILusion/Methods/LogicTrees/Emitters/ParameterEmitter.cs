using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ParameterEmitter : EmitterBase<ParameterNode>
    {
        protected override void Emit(EmitterContext<ParameterNode> emitterContext)
        {
            switch (emitterContext.Node.Parameter.Index)
            {
                case 0:
                    emitterContext.Emit(OpCodes.Ldarg_0);
                    break;
                case 1:
                    emitterContext.Emit(OpCodes.Ldarg_1);
                    break;
                case 2:
                    emitterContext.Emit(OpCodes.Ldarg_2);
                    break;
                case 3:
                    emitterContext.Emit(OpCodes.Ldarg_3);
                    break;
                default:
                    emitterContext.Emit(
                        emitterContext.Node.Parameter.Index > 255 ? OpCodes.Ldarg : OpCodes.Ldarg_S,
                        emitterContext.Node.Parameter);
                    break;
            }
        }
    }
}
