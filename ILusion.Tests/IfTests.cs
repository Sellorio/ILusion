using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class IfTests : TestBase
    {
        [Fact]
        public void WithoutElse()
        {
            var sampleMethod = GetSampleMethod(nameof(IfSamples), nameof(IfSamples.WithoutElse));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var ifNode =
                        CheckNode<IfNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Null(ifNode.FalseStatements);
                    Assert.Same(NthValueChild(x, 0), ifNode.Condition);
                    CheckStatements(
                        ifNode.TrueStatements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<LiteralNode>(z)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void WithElse()
        {
            var sampleMethod = GetSampleMethod(nameof(IfSamples), nameof(IfSamples.WithElse));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var ifNode =
                        CheckNode<IfNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), ifNode.Condition);
                    CheckStatements(
                        ifNode.TrueStatements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<LiteralNode>(z)));
                    CheckStatements(
                        ifNode.FalseStatements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<LiteralNode>(z)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void InvertedCondition()
        {
            var sampleMethod = GetSampleMethod(nameof(IfSamples), nameof(IfSamples.InvertedCondition));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var ifNode =
                        CheckNode<IfNode>(x,
                            y => CheckNode<NotNode>(y,
                                z => CheckNode<ParameterNode>(z)));

                    Assert.Same(NthValueChild(x, 0), ifNode.Condition);
                    CheckStatements(
                        ifNode.TrueStatements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<LiteralNode>(z)));
                    CheckStatements(
                        ifNode.FalseStatements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<LiteralNode>(z)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
