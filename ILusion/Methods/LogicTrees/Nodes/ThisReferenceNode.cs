using Mono.Cecil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ThisReferenceNode : ReferenceValueNode
    {
        private readonly TypeReference _declaringType;

        internal ThisReferenceNode(TypeReference declaringType)
            : base(Enumerable.Empty<LogicNode>())
        {
            _declaringType = declaringType;
        }

        internal override TypeReference GetValueType()
        {
            return new PointerType(_declaringType);
        }
    }
}
