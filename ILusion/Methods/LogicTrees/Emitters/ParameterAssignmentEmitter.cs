using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class ParameterAssignmentEmitter : EmitterBase<ParameterAssignmentNode>
    {
        protected override void Emit(EmitterContext<ParameterAssignmentNode> emitterContext)
        {
            emitterContext.Emit(emitterContext.Node.Parameter.Index > 255 ? OpCodes.Starg : OpCodes.Starg_S, emitterContext.Node.Parameter);
        }
    }
}
