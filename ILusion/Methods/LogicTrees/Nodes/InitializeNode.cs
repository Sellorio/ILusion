using Mono.Cecil;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ILusion.Methods.LogicTrees.Nodes
{
    /// <remarks>
    /// This is used when constructing/initalizing struct values.
    ///  - new() or default(T)
    ///    Reference to variable, parameter or array element is loaded on the value stack
    ///    OpCode initobj is used and pushes no value
    ///  - new(...)
    ///    Reference to variable, parameter or array element is loaded on the value stack
    ///    OpCode call is used with the called constructor and pushes no value
    /// </remarks>
    public sealed class InitializeNode : LogicNode
    {
        public ReferenceValueNode Target { get; }
        public IReadOnlyList<ValueNode> Parameters { get; }
        public MethodReference Constructor { get; }

        internal InitializeNode(ReferenceValueNode target, IEnumerable<ValueNode> parameters, MethodReference constructor, IEnumerable<LogicNode> children)
            : base(children)
        {
            Target = target;
            Parameters = ImmutableArray.CreateRange(parameters);
            Constructor = constructor;
        }
    }
}
