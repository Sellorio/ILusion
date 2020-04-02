using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Methods.LogicTrees.Nodes.ControlBlocks;
using Mono.Cecil.Cil;
using System.Linq;

namespace ILusion.Methods.LogicTrees.Emitters.ControlBlocks
{
    internal class LoopEmitter : EmitterBase<LoopNode>
    {
        internal static LoopEmitter Instance { get; } = new LoopEmitter();

        protected override void Emit(EmitterContext<LoopNode> emitterContext)
        {
            var firstConditionNode = NodeHelper.GetFirstRecursively(emitterContext.Node);
            var firstConditionInstruction = emitterContext.InstructionToNodeMapping.First(x => x.Value == firstConditionNode).Key;
            var indexOfCondition = emitterContext.Target.Body.Instructions.IndexOf(firstConditionInstruction);
            var conditionInstructions = emitterContext.Target.Body.Instructions.Skip(indexOfCondition).ToList();

            for (var i = emitterContext.Target.Body.Instructions.Count - 1; i >= indexOfCondition; i--)
            {
                emitterContext.Target.Body.Instructions.RemoveAt(i);
            }

            if (emitterContext.Node is WhileNode || emitterContext.Node is ForLoopNode)
            {
                emitterContext.Emit(OpCodes.Br, firstConditionInstruction);
            }

            foreach (var node in emitterContext.Node.Statements)
            {
                emitterContext.EmitChildInstructions(node, emitterContext.Node, emitterContext.Node);
            }

            if (emitterContext.Node is ForLoopNode forLoop)
            {
                emitterContext.EmitChildInstructions(forLoop.IteratorAssignment);
            }

            var firstStatementNode = NodeHelper.GetFirstRecursively(emitterContext.Node.Statements.First());
            var firstStatementInstruction = emitterContext.InstructionToNodeMapping.First(x => x.Value == firstStatementNode).Key;

            foreach (var instruction in conditionInstructions)
            {
                emitterContext.Target.Body.Instructions.Add(instruction);
            }

            if (emitterContext.Node.ConditionResultVariable != null)
            {
                emitterContext.Target.Body.Instructions.Add(
                    VariableHelper.CreateSetVariableInstruction(emitterContext.Node.ConditionResultVariable));

                if (emitterContext.Node.Condition is LiteralNode literal)
                {
                    if (true.Equals(literal.Value))
                    {
                        emitterContext.Emit(OpCodes.Br, firstStatementInstruction);
                    }
                    else if (false.Equals(literal.Value))
                    {
                        emitterContext.Emit(OpCodes.Brtrue, firstStatementInstruction);
                    }
                    else
                    {
                        emitterContext.Emit(OpCodes.Brtrue, firstStatementInstruction);
                    }
                }
                else
                {
                    emitterContext.Target.Body.Instructions.Add(
                        VariableHelper.CreateLoadVariableInstruction(emitterContext.Node.ConditionResultVariable));
                    emitterContext.Emit(OpCodes.Brtrue, firstStatementInstruction);
                }
            }
            else
            {
                emitterContext.Emit(OpCodes.Brtrue, firstStatementInstruction);
            }
        }

        protected override void UpdateBranches(EmitterContext<LoopNode> emitterContext)
        {
            foreach (var node in emitterContext.Node.Statements)
            {
                emitterContext.UpdateChildBranches(node, emitterContext.Node, emitterContext.Node);
            }
        }
    }
}

/*
While Loop:
    br->condition
    statements
    condition
    brtrue->statements

Do Loop:
    statements
    condition
    brtrue->statements
 */
