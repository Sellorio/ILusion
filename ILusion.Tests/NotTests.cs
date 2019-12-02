using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class NotTests : TestBase
    {
        [Fact]
        public void Simple()
        {
            var sampleMethod = GetSampleMethod(nameof(NotSamples), nameof(NotSamples.Simple));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var not =
                            CheckNode<NotNode>(y,
                                z => CheckNode<ParameterNode>(z));

                        Assert.Same(NthValueChild(y, 0), not.Value);
                        Assert.Equal("System.Boolean", not.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void NotTrue()
        {
            var sampleMethod = GetSampleMethod(nameof(NotSamples), nameof(NotSamples.NotTrue));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
