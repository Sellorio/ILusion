using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class DiscardTests : TestBase
    {
        [Fact]
        public void FunctionReturn()
        {
            var sampleMethod = GetSampleMethod(nameof(DiscardSamples), nameof(DiscardSamples.FunctionResult));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            x,
                            y => CheckNode<FunctionCallNode>(y));

                    Assert.Same(NthValueChild(x, 0), discard.DiscardedValue);
                },
                CheckReturn());
        }
    }
}
