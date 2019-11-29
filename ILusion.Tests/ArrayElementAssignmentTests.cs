using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ArrayElementAssignmentTests : TestBase
    {
        [Fact]
        public void SetClassElement()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementAssignmentSamples), nameof(SetClassElement));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var elementAssignment =
                        CheckNode<ArrayElementAssignmentNode>(
                            x,
                            y => CheckNode<ParameterNode>(y),
                            y => CheckNode<LiteralNode>(y),
                            y => CheckNode<LiteralNode>(y));

                    Assert.Same(NthValueChild(x, 0), elementAssignment.Array);
                    Assert.Same(NthValueChild(x, 1), elementAssignment.Index);
                    Assert.Same(NthValueChild(x, 2), elementAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetStructElement()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementAssignmentSamples), nameof(SetStructElement));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var elementAssignment =
                        CheckNode<ArrayElementAssignmentNode>(
                            x,
                            y => CheckNode<ParameterNode>(y),
                            y => CheckNode<LiteralNode>(y),
                            y => CheckNode<PropertyNode>(y));

                    Assert.Same(NthValueChild(x, 0), elementAssignment.Array);
                    Assert.Same(NthValueChild(x, 1), elementAssignment.Index);
                    Assert.Same(NthValueChild(x, 2), elementAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetStructElementWithVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementAssignmentSamples), nameof(SetStructElementWithVariable));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var variableAssignment =
                        CheckNode<VariableAssignmentNode>(
                            x,
                            y => CheckNode<PropertyNode>(y));

                    Assert.Equal(0, variableAssignment.Variable.Index);
                    Assert.Same(NthValueChild(x, 0), variableAssignment.Value);
                },
                x =>
                {
                    var elementAssignment =
                        CheckNode<ArrayElementAssignmentNode>(
                            x,
                            y => CheckNode<ParameterNode>(y),
                            y => CheckNode<LiteralNode>(y),
                            y => CheckNode<VariableNode>(y));

                    Assert.Same(NthValueChild(x, 0), elementAssignment.Array);
                    Assert.Same(NthValueChild(x, 1), elementAssignment.Index);
                    Assert.Same(NthValueChild(x, 2), elementAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetStructElementDefault()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementAssignmentSamples), nameof(SetStructElementDefault));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialise =
                        CheckNode<InitializeNode>(
                            x,
                            y =>
                            {
                                var variableReference =
                                    CheckNode<ArrayElementReferenceNode>(
                                        y,
                                        z =>
                                        {
                                            var parameter = CheckNode<ParameterNode>(z);
                                            Assert.Equal(0, parameter.Parameter.Index);
                                        },
                                        z =>
                                        {
                                            var parameter = CheckNode<LiteralNode>(z);
                                            Assert.Equal(0, parameter.Value);
                                        });

                                Assert.Equal(NthValueChild(y, 0), variableReference.Array);
                                Assert.Equal(NthValueChild(y, 1), variableReference.Index);
                            });

                    Assert.Null(initialise.Constructor);
                    Assert.Empty(initialise.Parameters);
                    Assert.Same(NthValueChild(x, 0), initialise.Target);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetNull()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementAssignmentSamples), nameof(SetNull));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var elementAssignment =
                        CheckNode<ArrayElementAssignmentNode>(
                            x,
                            y =>
                            {
                                var parameter = CheckNode<ParameterNode>(y);
                                Assert.Equal(0, parameter.Parameter.Index);
                            },
                            y =>
                            {
                                var literal = CheckNode<LiteralNode>(y);
                                Assert.Equal(0, literal.Value);
                            },
                            y =>
                            {
                                var literal = CheckNode<LiteralNode>(y);
                                Assert.Null(literal.Value);
                            });

                    Assert.Same(NthValueChild(x, 0), elementAssignment.Array);
                    Assert.Same(NthValueChild(x, 1), elementAssignment.Index);
                    Assert.Same(NthValueChild(x, 2), elementAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetGenericElement()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementAssignmentSamples), nameof(SetGenericElement));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var elementAssignment =
                        CheckNode<ArrayElementAssignmentNode>(
                            x,
                            y =>
                            {
                                var parameter = CheckNode<ParameterNode>(y);
                                Assert.Equal(0, parameter.Parameter.Index);
                            },
                            y =>
                            {
                                var literal = CheckNode<LiteralNode>(y);
                                Assert.Equal(0, literal.Value);
                            },
                            y =>
                            {
                                var literal = CheckNode<ParameterNode>(y);
                                Assert.Equal(1, literal.Parameter.Index);
                            });

                    Assert.Same(NthValueChild(x, 0), elementAssignment.Array);
                    Assert.Same(NthValueChild(x, 1), elementAssignment.Index);
                    Assert.Same(NthValueChild(x, 2), elementAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
