using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ArrayLengthEmitter : EmitterBase<ArrayLengthNode>
    {
        protected override void Emit(EmitterContext<ArrayLengthNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Ldlen);

            if (emitterContext.Node.AsLong)
            {
                emitterContext.Emit(OpCodes.Conv_I8);
            }
            else
            {
                emitterContext.Emit(OpCodes.Conv_I4);
            }
        }
    }
}
