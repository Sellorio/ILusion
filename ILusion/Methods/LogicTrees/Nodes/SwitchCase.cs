using System.Collections.Generic;
using System.Collections.Immutable;

namespace ILusion.Methods.LogicTrees.Nodes
{
    public class SwitchCase
    {
        public object Value { get; }
        public IReadOnlyList<LogicNode> Statements { get; internal set; }

        internal SwitchCase(object value, IEnumerable<LogicNode> statements)
        {
            Value = value;
            Statements = ImmutableArray.CreateRange(statements);
        }
    }
}
