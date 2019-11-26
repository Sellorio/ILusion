using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class FieldAssignmentEmitter : EmitterBase<FieldAssignmentNode>
    {
        protected override void Emit(EmitterContext<FieldAssignmentNode> emitterContext)
        {
            emitterContext.Emit(emitterContext.Node.Instance == null ? OpCodes.Stsfld : OpCodes.Stfld, emitterContext.Node.Field);
        }
    }
}
