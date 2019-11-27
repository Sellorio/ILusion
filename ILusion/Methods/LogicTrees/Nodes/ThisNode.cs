using System.Linq;
using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ThisNode : ValueNode
    {
        private readonly TypeReference _declaringType;

        internal ThisNode(TypeReference declaringType)
            : base(Enumerable.Empty<LogicNode>())
        {
            _declaringType = declaringType;
        }

        internal override TypeReference GetValueType()
        {
            return _declaringType;
        }
    }
}
