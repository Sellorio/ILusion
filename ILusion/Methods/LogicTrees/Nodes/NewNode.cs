using ILusion.Methods.LogicTrees.Helpers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace ILusion.Methods.LogicTrees.Nodes
{
    /// <remarks>
    /// This is used when constructing values.
    ///  - Struct new(...) as parameter
    ///    Parameter values are loaded onto the value stack
    ///    OpCode newobj is used with the constructor and puts the result on the stack
    ///  - Generic new()
    ///    OpCode call is used with Activator.CreateInstance{T}() and puts the result on the stack
    ///  - Class
    ///    Any required parameter values are loaded onto the stack
    ///    OpCode newobj is used with the constructor and puts the result on the stack
    ///  - Array
    ///    OpCode newarr is used with the element type and puts the result onto the stack
    ///  - Delegate
    ///    ???
    /// </remarks>
    public sealed class NewNode : ValueNode
    {
        private static readonly MethodInfo _createInstanceMethod = typeof(Activator).GetMethod(nameof(Activator.CreateInstance), new Type[0]);

        public IReadOnlyList<ValueNode> Parameters { get; }
        public TypeReference Type { get; }
        public MethodReference Constructor { get; }

        internal NewNode(IEnumerable<ValueNode> parameters, TypeReference type, MethodReference constructor, IEnumerable<LogicNode> children)
            : base(children)
        {
            Parameters = ImmutableArray.CreateRange(parameters);
            Type = type;
            Constructor = constructor;
        }

        internal override TypeReference GetValueType()
        {
            return Type;
        }
    }
}
