using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class PropertyEmitter : EmitterBase<PropertyNode>
    {
        protected override void Emit(EmitterContext<PropertyNode> emitterContext)
        {
            if (emitterContext.Node.ConstrainedModifier != null)
            {
                emitterContext.Emit(OpCodes.Constrained, emitterContext.Node.ConstrainedModifier);
            }

            emitterContext.Emit(
                emitterContext.Node.Instance == null
                    || emitterContext.Node.IsBaseCall
                    || emitterContext.Node.Property.DeclaringType.IsValueType
                    || (!emitterContext.Node.Property.GetMethod.IsVirtual
                        && emitterContext.Node.Instance is ThisNode)
                    ? OpCodes.Call
                    : OpCodes.Callvirt,
                emitterContext.Node.GetMethod);
        }
    }
}
