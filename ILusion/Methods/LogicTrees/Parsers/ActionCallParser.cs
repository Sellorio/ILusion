using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ActionCallParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Call,
            OpCodes.Callvirt
        };

        public bool TryParse(Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            node = default;
            consumedInstructions = default;

            var method = ((MethodReference)instruction.Operand).Resolve();

            if (method == null || method.IsConstructor || method.ReturnType != null)
            {
                return false;
            }

            var expectedStackValues = method.IsStatic ? method.Parameters.Count : method.Parameters.Count + 1;
            var valueNodes = ParsingHelper.GetValueNodes(nodeStack, expectedStackValues, out var nodes);

            // Callvirt is used for all instance method calls, not just virtual ones. See here for reason:
            // https://blogs.msdn.microsoft.com/ericgu/2008/07/02/why-does-c-always-use-callvirt/
            var isBaseCall = instruction.OpCode == OpCodes.Call && !method.IsStatic;

            node = new ActionCallNode(method, method.IsStatic ? null : valueNodes[0], valueNodes.Skip(1), isBaseCall, nodes);
            consumedInstructions = 1;

            return true;
        }
    }
}
