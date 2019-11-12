using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees
{
    public abstract class ValueNode : LogicNode
    {
        protected ModuleDefinition Module { get; }

        internal ValueNode(IEnumerable<LogicNode> children = null)
            : base(children)
        {
        }

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
