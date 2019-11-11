using Mono.Cecil;

namespace ILusion.Methods.LogicTrees
{
    public abstract class ValueNode : LogicNode
    {
        protected ModuleDefinition Module { get; }

        internal virtual TypeReference GetValueType()
        {
            return null;
        }

        internal virtual object GetValue()
        {
            return null;
        }
    }
}
