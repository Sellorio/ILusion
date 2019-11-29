using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ConditionalOperatorTests : TestBase
    {
        [Fact]
        public void Simple()
        {
            var sampleMethod = GetSampleMethod(nameof(ConditionalOperatorSamples), nameof(ConditionalOperatorSamples.Simple));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var op =
                            CheckNode<ConditionalOperatorNode>(y,
                                z => CheckNode<VariableNode>(z));

                        Assert.Same(NthValueChild(y, 0), op.Condition);
                        Assert.Equal("System.Boolean", op.GetValueType()?.FullName);

                        CheckStatements(
                            op.TrueExpression,
                            z =>
                            {
                                var variable = CheckNode<VariableNode>(z);
                                Assert.Equal(1, variable.Variable.Index);
                            });

                        CheckStatements(
                            op.FalseExpression,
                            z =>
                            {
                                var variable = CheckNode<VariableNode>(z);
                                Assert.Equal(2, variable.Variable.Index);
                            });
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
