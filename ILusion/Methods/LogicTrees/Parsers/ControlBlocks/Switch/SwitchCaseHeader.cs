using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Parsers.ControlBlocks.Switch
{
    internal sealed class SwitchCaseHeader
    {
        public object Value { get; set; }
        public VariableDefinition Variable { get; set; }
        public Instruction BodyStartInstruction { get; set; }
    }
}
