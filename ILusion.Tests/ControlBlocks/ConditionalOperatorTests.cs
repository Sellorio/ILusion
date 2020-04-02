using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Methods.LogicTrees.Nodes.ControlBlocks;
using ILusion.Tests.Sample.ControlBlocks;
using Xunit;

namespace ILusion.Tests.ControlBlocks
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

        [Fact]
        public void CommonValues()
        {
            var sampleMethod = GetSampleMethod(nameof(ConditionalOperatorSamples), nameof(ConditionalOperatorSamples.CommonValues));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var op =
                            CheckNode<ConditionalOperatorNode>(y,
                                z => CheckNode<ParameterNode>(z));

                        Assert.Same(NthValueChild(y, 0), op.Condition);
                        Assert.Equal("System.String", op.GetValueType()?.FullName);

                        CheckStatements(
                            op.TrueExpression,
                            z => CheckNode<FunctionCallNode>(z,
                                a => CheckNode<LiteralNode>(a),
                                a => CheckNode<LiteralNode>(a)));

                        CheckStatements(
                            op.FalseExpression,
                            z => CheckNode<FunctionCallNode>(z,
                                a => CheckNode<LiteralNode>(a),
                                a => CheckNode<LiteralNode>(a)));
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void NullTrueExpression()
        {
            var sampleMethod = GetSampleMethod(nameof(ConditionalOperatorSamples), nameof(ConditionalOperatorSamples.NullTrueExpression));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var op =
                            CheckNode<ConditionalOperatorNode>(y,
                                z => CheckNode<ParameterNode>(z));

                        Assert.Same(NthValueChild(y, 0), op.Condition);
                        Assert.Equal("System.String", op.GetValueType()?.FullName);

                        CheckStatements(
                            op.TrueExpression,
                            z => CheckNode<LiteralNode>(z));

                        CheckStatements(
                            op.FalseExpression,
                            z => CheckNode<FunctionCallNode>(z,
                                a => CheckNode<LiteralNode>(a),
                                a => CheckNode<LiteralNode>(a)));
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void NullFalseExpression()
        {
            var sampleMethod = GetSampleMethod(nameof(ConditionalOperatorSamples), nameof(ConditionalOperatorSamples.NullFalseExpression));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var op =
                            CheckNode<ConditionalOperatorNode>(y,
                                z => CheckNode<ParameterNode>(z));

                        Assert.Same(NthValueChild(y, 0), op.Condition);
                        Assert.Equal("System.String", op.GetValueType()?.FullName);

                        CheckStatements(
                            op.TrueExpression,
                            z => CheckNode<FunctionCallNode>(z,
                                a => CheckNode<LiteralNode>(a),
                                a => CheckNode<LiteralNode>(a)));

                        CheckStatements(
                            op.FalseExpression,
                            z => CheckNode<LiteralNode>(z));
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
