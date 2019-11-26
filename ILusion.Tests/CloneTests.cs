using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class CloneTests : TestBase
    {
        [Fact]
        public void ArrayInitializer()
        {
            var sampleMethod = GetSampleMethod(nameof(CloneSamples), nameof(CloneSamples.ArrayInitializer));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var newNode =
                            CheckNode<NewNode>(
                                y,
                                z => CheckNode<LiteralNode>(z));
                        Assert.NotNull(newNode.Type);
                        Assert.Equal("System.String[]", newNode.Type.FullName);
                        Assert.Collection(
                            newNode.Parameters,
                            z => Assert.Same(NthValueChild(y, 0), z));
                    },
                    y => CheckNode<ArrayElementAssignmentNode>(y,
                        z => CheckNode<CloneNode>(z),
                        z => CheckNode<LiteralNode>(z),
                        z => CheckNode<LiteralNode>(z)),
                    y => CheckNode<ArrayElementAssignmentNode>(y,
                        z => CheckNode<CloneNode>(z),
                        z => CheckNode<LiteralNode>(z),
                        z => CheckNode<LiteralNode>(z))),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
