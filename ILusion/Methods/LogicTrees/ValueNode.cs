using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees
{
    public abstract class ValueNode : LogicNode
    {
        internal ValueNode(IEnumerable<LogicNode> children)
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
