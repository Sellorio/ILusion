using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ForTests : TestBase
    {
        [Fact]
        public void Simple()
        {
            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.Simple));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var forNode = CheckNode<ForNode>(x);
                    
                    var forLoopNode =
                        CheckNode<ForLoopNode>(forNode.Loop,
                            y => CheckNode<LessThanNode>(y,
                                z => CheckNode<VariableNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forNode.InitialAssignments,
                        y => CheckNode<VariableAssignmentNode>(y,
                            z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forLoopNode.Statements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<VariableNode>(z)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
