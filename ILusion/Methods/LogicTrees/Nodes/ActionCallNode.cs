using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class ActionCallNode : LogicNode
    {
        public MethodReference Method { get; }
        public ValueNode Instance { get; }
        public IReadOnlyList<ValueNode> Parameters { get; }
        public bool IsBaseCall { get; }

        internal ActionCallNode(MethodReference method, ValueNode instance, IEnumerable<ValueNode> parameters, bool isBaseCall, IEnumerable<LogicNode> children)
            : base(children)
        {
            Method = method;
            Instance = instance;
            Parameters = ImmutableArray.CreateRange(parameters);
            IsBaseCall = isBaseCall;
        }

        internal override Instruction[] ToInstructions()
        {
            return new[] { Instruction.Create(Instance == null || IsBaseCall ? OpCodes.Call : OpCodes.Callvirt, Method) };
        }
    }
}
