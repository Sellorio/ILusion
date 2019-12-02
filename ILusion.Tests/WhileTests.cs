using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class WhileTests : TestBase
    {
        [Fact]
        public void Simple()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.Simple));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
