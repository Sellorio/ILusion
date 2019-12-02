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

        internal static void UpdateBranchOpCode(Instruction branch)
        {
            if (((Instruction)branch.Operand).Offset > 255)
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
