using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class GoToEmitter : EmitterBase<GoToNode>
    {
        protected override void Emit(EmitterContext<GoToNode> emitterContext)
        {
            emitterContext.EmitBranch(OpCodes.Br);
        }

        protected override void UpdateBranches(EmitterContext<GoToNode> emitterContext)
        {
            var instruction = emitterContext.InstructionToNodeMapping.Single(x => x.Value == emitterContext.Node).Key;
            var targetInstruction = emitterContext.InstructionToNodeMapping.First(x => x.Value == emitterContext.Node.Target).Key;

            instruction.Operand = targetInstruction;
        }
    }
}
