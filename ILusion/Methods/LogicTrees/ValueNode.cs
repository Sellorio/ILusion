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

        internal abstract TypeReference GetValueType();
    }
}
