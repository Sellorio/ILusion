using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class VariableEmitter : EmitterBase<VariableNode>
    {
        protected override void Emit(EmitterContext<VariableNode> emitterContext)
        {
            switch (emitterContext.Node.Variable.Index)
            {
                case 0:
                    emitterContext.Emit(OpCodes.Ldloc_0);
                    break;
                case 1:
                    emitterContext.Emit(OpCodes.Ldloc_1);
                    break;
                case 2:
                    emitterContext.Emit(OpCodes.Ldloc_2);
                    break;
                case 3:
                    emitterContext.Emit(OpCodes.Ldloc_3);
                    break;
                default:
                    emitterContext.Emit(
                        emitterContext.Node.Variable.Index > 255 ? OpCodes.Ldloc : OpCodes.Ldloc_S,
                        emitterContext.Node.Variable);
                    break;
            }
        }
    }
}
