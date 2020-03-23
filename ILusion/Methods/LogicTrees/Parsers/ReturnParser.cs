using System.Linq;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
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

        public bool TryParse(ParsingContext parsingContext)
        {
            // SyntaxTree.FromMethodDefintion will only allow this to happen if a genuine return (i.e. value followed by OpCode.Ret) is present.
            if (parsingContext.Instruction.OpCode == OpCodes.Ret)
            {
                var returnValue = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children)[0];
                return parsingContext.Success(new ReturnNode(returnValue, children));
            }
            else if (parsingContext.Instruction.OpCode == OpCodes.Br || parsingContext.Instruction.OpCode == OpCodes.Br_S)
            {
                // no return type
                // branch is targetting the last (OpCode.Ret) instruction
                if (parsingContext.Method.ReturnType.FullName == typeof(void).FullName
                    && parsingContext.Instruction.Operand == parsingContext.Method.Body.Instructions.Last())
                {
                    return parsingContext.Success(new ReturnNode(null, Enumerable.Empty<LogicNode>()));
                }
            }
            else
            {
                if (parsingContext.Method.ReturnType.FullName != typeof(void).FullName)
                {
                    var loadReturnValueInstruction = parsingContext.Method.Body.Instructions[parsingContext.Method.Body.Instructions.Count - 2];

                    // branch after setting local
                    // branch is targeting the return part of the method
                    // the local loaded in the return part is the same as the one that was set
                    if (parsingContext.Instruction.Next.OpCode.ToString().StartsWith("br")
                        && parsingContext.Instruction.Next.Operand == loadReturnValueInstruction
                        && loadReturnValueInstruction.OpCode.ToString() == "ld" + parsingContext.Instruction.OpCode.ToString().Substring(2)
                        && loadReturnValueInstruction.Operand == parsingContext.Instruction.Operand)
                    {
                        var returnValue = ParsingHelper.GetValueNodes(parsingContext.NodeStack, 1, out var children)[0];

                        if (parsingContext.Method.ReturnType.FullName == typeof(bool).FullName)
                        {
                            ParsingHelper.HandleBooleanLiteral(parsingContext.Method, returnValue);
                        }

                        return parsingContext.Success(new ReturnNode(returnValue, children), 2);
                    }
                }
            }

            return false;
        }
    }
}
