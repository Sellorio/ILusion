using ILusion.Methods.LogicTrees.Nodes;
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
                var node = instructionToNodeMapping[instruction];

                if (node is BranchNode branchNode)
                {
                    var targetInstruction = instructionToNodeMapping.First(x => x.Value == branchNode.Target).Key;
                    UpdateBranchTarget(instruction, targetInstruction);
                }
                else if (node is ReturnNode)
                {
                    var isFunction = methodDefinition.ReturnType.FullName != typeof(void).FullName;
                    var targetInstruction = methodDefinition.Body.Instructions[methodDefinition.Body.Instructions.Count - (isFunction ? 2 : 1)];
                    UpdateBranchTarget(instruction, targetInstruction);
                }
            }
        }

        private static void UpdateBranchTarget(Instruction branch, Instruction target)
        {
            branch.Operand = target;

            if (target.Offset > 255)
            {
                branch.OpCode = ShortToLong[branch.OpCode];
            }
            else
            {
                branch.OpCode = LongToShort[branch.OpCode];
            }
        }
    }
}
