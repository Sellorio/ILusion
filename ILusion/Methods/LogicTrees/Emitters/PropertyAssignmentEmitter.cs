using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class PropertyAssignmentEmitter : EmitterBase<PropertyAssignmentNode>
    {
        protected override void Emit(EmitterContext<PropertyAssignmentNode> emitterContext)
        {
            if (emitterContext.Node.ConstrainedModifier != null)
            {
                emitterContext.Emit(OpCodes.Constrained, emitterContext.Node.ConstrainedModifier);
            }

            emitterContext.Emit(
                emitterContext.Node.Instance == null
                    || emitterContext.Node.IsBaseCall
                    || emitterContext.Node.Property.DeclaringType.IsValueType
                    || !emitterContext.Node.Property.SetMethod.IsVirtual ? OpCodes.Call : OpCodes.Callvirt,
                emitterContext.Node.SetMethod);
        }
    }
}
