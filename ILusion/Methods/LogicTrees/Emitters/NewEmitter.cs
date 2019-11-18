using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class NewEmitter : EmitterBase<NewNode>
    {
        protected override void Emit(EmitterContext<NewNode> emitterContext)
        {
            if (emitterContext.Node.Constructor == null)
            {
                if (emitterContext.Node.Type is ArrayType arrayType)
                {
                    emitterContext.Emit(OpCodes.Newarr, arrayType.ElementType);
                }
                else
                {
                    emitterContext.Emit(OpCodes.Call, emitterContext.Node.Type);
                }
            }
            else
            {
                emitterContext.Emit(OpCodes.Newobj, emitterContext.Node.Constructor);
            }
        }
    }
}
