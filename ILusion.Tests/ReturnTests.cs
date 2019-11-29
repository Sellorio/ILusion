using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ReturnTests : TestBase
    {
        [Fact]
        public void Action()
        {
            var sampleMethod = GetSampleMethod(nameof(ReturnSamples), nameof(ReturnSamples.Action));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(syntaxTree);

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Function()
        {
            var sampleMethod = GetSampleMethod(nameof(ReturnSamples), nameof(ReturnSamples.Function));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var returnNode =
                        CheckNode<ReturnNode>(x,
                            y => CheckNode<LiteralNode>(y));

                    Assert.Same(NthValueChild(x, 0), returnNode.ReturnValue);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
