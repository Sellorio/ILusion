using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Helpers
{
    internal static class BranchHelper
    {
        private static readonly Dictionary<OpCode, OpCode> ShortToLong = new Dictionary<OpCode, OpCode>
        {
            { OpCodes.Br_S, OpCodes.Br },
            { OpCodes.Br, OpCodes.Br },
            { OpCodes.Brfalse_S, OpCodes.Brfalse },
            { OpCodes.Brfalse, OpCodes.Brfalse },
            { OpCodes.Brtrue_S, OpCodes.Brtrue },
            { OpCodes.Brtrue, OpCodes.Brtrue }
        };

        private static readonly Dictionary<OpCode, OpCode> LongToShort = new Dictionary<OpCode, OpCode>
        {
            { OpCodes.Br, OpCodes.Br_S },
            { OpCodes.Br_S, OpCodes.Br_S },
            { OpCodes.Brfalse, OpCodes.Brfalse_S },
            { OpCodes.Brfalse_S, OpCodes.Brfalse_S },
            { OpCodes.Brtrue, OpCodes.Brtrue_S },
            { OpCodes.Brtrue_S, OpCodes.Brtrue_S }
        };

        internal static void UpdateBranchInstructions(Dictionary<Instruction, LogicNode> instructionToNodeMapping, MethodDefinition methodDefinition)
        {
            var firstInstruction = methodDefinition.Body.Instructions[0];

            foreach (var instruction in methodDefinition.Body.Instructions.Where(x => x.Operand == firstInstruction))
            {
                var branchNode = (BranchNode)instructionToNodeMapping[instruction];
                var targetInstruction = instructionToNodeMapping.First(x => x.Value == branchNode.Target).Key;
                instruction.Operand = targetInstruction;

                if (targetInstruction.Offset > 255)
                {
                    instruction.OpCode = ShortToLong[instruction.OpCode];
                }
                else
                {
                    instruction.OpCode = LongToShort[instruction.OpCode];
                }
            }
        }
    }
}
