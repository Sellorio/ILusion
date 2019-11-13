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

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            node = default;
            consumedInstructions = default;

            var calledMethod = ((MethodReference)instruction.Operand).Resolve();

            if (calledMethod == null || calledMethod.IsConstructor || calledMethod.ReturnType.FullName != "System.Void")
            {
                return false;
            }

            var expectedStackValues = calledMethod.IsStatic ? calledMethod.Parameters.Count : calledMethod.Parameters.Count + 1;
            var valueNodes = ParsingHelper.GetValueNodes(nodeStack, expectedStackValues, out var nodes);

            // Callvirt is used for all instance method calls, not just virtual ones. See here for reason:
            // https://blogs.msdn.microsoft.com/ericgu/2008/07/02/why-does-c-always-use-callvirt/
            var isBaseCall = instruction.OpCode == OpCodes.Call && !calledMethod.IsStatic;

            node = new ActionCallNode(calledMethod, calledMethod.IsStatic ? null : valueNodes[0], valueNodes.Skip(1), isBaseCall, nodes);
            consumedInstructions = 1;

            return true;
        }
    }
}
