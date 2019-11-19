using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees
{
    public abstract class ReferenceValueNode : ValueNode
    {
        internal ReferenceValueNode(IEnumerable<LogicNode> children)
            : base(children)
        {
        }
    }
}
