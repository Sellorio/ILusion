using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ArrayElementReferenceEmitter : EmitterBase<ArrayElementReferenceNode>
    {
        protected override void Emit(EmitterContext<ArrayElementReferenceNode> emitterContext)
        {
            emitterContext.Emit(OpCodes.Ldelema, ((ArrayType)emitterContext.Node.Array.GetValueType()).ElementType);
        }
    }
}
