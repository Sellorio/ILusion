using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class AsTests : TestBase
    {
        [Fact]
        public void As()
        {
            var sampleMethod = GetSampleMethod(nameof(AsSamples), nameof(AsSamples.As));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var asNode =
                            CheckNode<AsNode>(y,
                                z => CheckNode<ParameterNode>(z));

                        Assert.Same(NthValueChild(y, 0), asNode.Value);
                        Assert.NotNull(asNode.TargetType);
                        Assert.Equal("ClassA", asNode.TargetType.Name);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
