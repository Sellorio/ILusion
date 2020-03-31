using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public sealed class SwitchTypeCase : SwitchCase
    {
        public new TypeReference Value => (TypeReference)base.Value;
        public VariableDefinition Variable { get; }

        internal SwitchTypeCase(TypeReference type, VariableDefinition variable, IEnumerable<LogicNode> statements)
            : base(type, statements)
        {
            Variable = variable;
        }
    }
}
