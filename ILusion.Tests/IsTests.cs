using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class IsTests : TestBase
    {
        [Fact]
        public void WithoutVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(IsSamples), nameof(IsSamples.WithoutVariable));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var isNode =
                            CheckNode<IsNode>(y,
                                z => CheckNode<ParameterNode>(z));

                        Assert.Same(NthValueChild(y, 0), isNode.Value);
                        Assert.NotNull(isNode.TargetType);
                        Assert.Equal("System.String", isNode.TargetType.FullName);
                        Assert.Null(isNode.CastedVariable);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void WithVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(IsSamples), nameof(IsSamples.WithVariable));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var isNode =
                            CheckNode<IsNode>(y,
                                z => CheckNode<ParameterNode>(z));

                        Assert.Same(NthValueChild(y, 0), isNode.Value);
                        Assert.NotNull(isNode.TargetType);
                        Assert.Equal("System.String", isNode.TargetType.FullName);
                        Assert.NotNull(isNode.CastedVariable);
                        Assert.Equal(0, isNode.CastedVariable.Index);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
