using Mono.Cecil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees
{
    public abstract class ReferenceValueNode : ValueNode
    {
        internal ReferenceValueNode(IEnumerable<LogicNode> children)
            : base(children)
        {
        }

        public TypeReference GetReferencedType()
        {
            var valueType = GetValueType();

            if (valueType != null)
            {
                valueType = ((PointerType)valueType).ElementType;
            }

            return valueType;
        }
    }
}
