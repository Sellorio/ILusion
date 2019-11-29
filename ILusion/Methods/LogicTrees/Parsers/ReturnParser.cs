using System.Collections.Generic;
using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers
{
    internal class ReturnParser : IParser
    {
        public OpCode[] CanTryParse { get; } =
        {
            OpCodes.Stloc,
            OpCodes.Stloc_0,
            OpCodes.Stloc_1,
            OpCodes.Stloc_2,
            OpCodes.Stloc_3,
            OpCodes.Stloc_S,
            OpCodes.Br,
            OpCodes.Br_S,
            OpCodes.Ret
        };

        public bool TryParse(MethodDefinition method, Instruction instruction, Stack<LogicNode> nodeStack, out LogicNode node, out int consumedInstructions)
        {
            // SyntaxTree.FromMethodDefintion will only allow this to happen if a genuine return (i.e. value followed by OpCode.Ret) is present.
            if (instruction.OpCode == OpCodes.Ret)
            {
                var returnValue = ParsingHelper.GetValueNodes(nodeStack, 1, out var children)[0];
                node = new ReturnNode(returnValue, children);
                consumedInstructions = 1;
                return true;
            }
            else if (instruction.OpCode == OpCodes.Br || instruction.OpCode == OpCodes.Br_S)
            {
                // no return type
                // branch is targetting the last (OpCode.Ret) instruction
                if (method.ReturnType.FullName == typeof(void).FullName
                    && instruction.Operand == method.Body.Instructions.Last())
                {
                    node = new ReturnNode(null, Enumerable.Empty<LogicNode>());
                    consumedInstructions = 1;
                    return true;
                }
            }
            else
            {
                if (method.ReturnType.FullName != typeof(void).FullName)
                {
                    var loadReturnValueInstruction = method.Body.Instructions[method.Body.Instructions.Count - 2];

                    // branch after setting local
                    // branch is targeting the return part of the method
                    // the local loaded in the return part is the same as the one that was set
                    if (instruction.Next.OpCode.ToString().StartsWith("br")
                        && instruction.Next.Operand == loadReturnValueInstruction
                        && loadReturnValueInstruction.OpCode.ToString() == "ld" + instruction.OpCode.ToString().Substring(2)
                        && loadReturnValueInstruction.Operand == instruction.Operand)
                    {
                        var returnValue = ParsingHelper.GetValueNodes(nodeStack, 1, out var children)[0];

                        if (method.ReturnType.FullName == typeof(bool).FullName)
                        {
                            ParsingHelper.HandleBooleanLiteral(method, returnValue);
                        }

                        node = new ReturnNode(returnValue, children);
                        consumedInstructions = 2;
                        return true;
                    }
                }
            }

            node = null;
            consumedInstructions = 0;
            return false;
        }
    }
}
