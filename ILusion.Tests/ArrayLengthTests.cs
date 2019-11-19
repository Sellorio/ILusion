using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ArrayLengthTests : TestBase
    {
        [Fact]
        public void AsInt()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayLengthSamples), nameof(ArrayLengthSamples.AsInt));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var variableAssignment =
                        CheckNode<VariableAssignmentNode>(
                            x,
                            y =>
                            {
                                var arrayLength =
                                    CheckNode<ArrayLengthNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z));

                                Assert.Same(NthValueChild(y, 0), arrayLength.Array);
                                Assert.Equal("System.Int32", arrayLength.GetValueType()?.FullName);
                                Assert.False(arrayLength.AsLong);
                            });
                },
                CheckReturn());
        }

        [Fact]
        public void AsLong()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayLengthSamples), nameof(ArrayLengthSamples.AsLong));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var variableAssignment =
                        CheckNode<VariableAssignmentNode>(
                            x,
                            y =>
                            {
                                var arrayLength =
                                    CheckNode<ArrayLengthNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z));

                                Assert.Same(NthValueChild(y, 0), arrayLength.Array);
                                Assert.Equal("System.Int32", arrayLength.GetValueType()?.FullName);
                                Assert.True(arrayLength.AsLong);
                            });
                },
                CheckReturn());
        }
    }
}
