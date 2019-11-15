using ILusion.Methods;
using ILusion.Methods.LogicTrees;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using System.Linq;
using Xunit;

namespace ILusion.Tests
{
    public class ActionCallTests : TestBase
    {
        [Fact]
        public void CallStaticParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallStaticParameterlessMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode = CheckNode<ActionCallNode>(x);
                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("StaticParameterlessMethod", actionCallNode.Method.Name);
                    Assert.Null(actionCallNode.Instance);
                    Assert.Empty(actionCallNode.Parameters);
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallStaticParameterisedMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallStaticParameterisedMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var literalNode = CheckNode<LiteralNode>(y);
                                var intValue = Assert.IsType<int>(literalNode.Value);
                                Assert.Equal(5, intValue);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("StaticParameterisedMethod", actionCallNode.Method.Name);
                    Assert.Null(actionCallNode.Instance);
                    Assert.Collection(actionCallNode.Parameters, y => Assert.Same(NthValueChild(x, 0), y));
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallInstanceParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallInstanceParameterlessMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var propertyNode = CheckNode<PropertyNode>(y);
                                Assert.Null(propertyNode.Instance);
                                Assert.False(propertyNode.IsBaseCall);
                                Assert.NotNull(propertyNode.Property);
                                Assert.Equal("Instance", propertyNode.Property.Name);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("InstanceParameterlessMethod", actionCallNode.Method.Name);
                    Assert.Same(NthValueChild(x, 0), actionCallNode.Instance);
                    Assert.Empty(actionCallNode.Parameters);
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallInstanceParameterisedMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallInstanceParameterisedMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var propertyNode = CheckNode<PropertyNode>(y);
                                Assert.Null(propertyNode.Instance);
                                Assert.False(propertyNode.IsBaseCall);
                                Assert.NotNull(propertyNode.Property);
                                Assert.Equal("Instance", propertyNode.Property.Name);
                            },
                            y =>
                            {
                                var literalNode = CheckNode<LiteralNode>(y);
                                var intValue = Assert.IsType<int>(literalNode.Value);
                                Assert.Equal(5, intValue);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("InstanceParameterisedMethod", actionCallNode.Method.Name);
                    Assert.Same(NthValueChild(x, 0), actionCallNode.Instance);
                    Assert.Collection(actionCallNode.Parameters, y => Assert.Same(NthValueChild(x, 1), y));
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallBaseParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallBaseParameterlessMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y => CheckNode<ThisNode>(y));

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("CallBaseParameterlessMethod", actionCallNode.Method.Name);
                    Assert.Equal(NthValueChild(x, 0), actionCallNode.Instance);
                    Assert.Empty(actionCallNode.Parameters);
                    Assert.True(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallStructParameterlessMethodFromProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallStructParameterlessMethodFromProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var variableAssignmentNode =
                        CheckNode<VariableAssignmentNode>(
                            x,
                            y =>
                            {
                                var propertyNode = CheckNode<PropertyNode>(y);
                                Assert.Null(propertyNode.Instance);
                                Assert.False(propertyNode.IsBaseCall);
                                Assert.NotNull(propertyNode.Property);
                                Assert.Equal("Instance", propertyNode.Property.Name);
                            });

                    Assert.NotNull(variableAssignmentNode.Variable);
                    Assert.Equal(0, variableAssignmentNode.Variable.Index);
                    Assert.Same(NthValueChild(x, 0), variableAssignmentNode.Value);
                },
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var variableReferenceNode = CheckNode<VariableReferenceNode>(y);
                                Assert.NotNull(variableReferenceNode.Variable);
                                Assert.Equal(0, variableReferenceNode.Variable.Index);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("InstanceParameterlessMethod", actionCallNode.Method.Name);
                    Assert.Equal(NthValueChild(x, 0), actionCallNode.Instance);
                    Assert.Empty(actionCallNode.Parameters);
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallStructParameterlessMethodFromField()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallStructParameterlessMethodFromField));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var fieldReferenceNode = CheckNode<FieldReferenceNode>(y);
                                Assert.Null(fieldReferenceNode.Instance);
                                Assert.NotNull(fieldReferenceNode.Field);
                                Assert.Equal("StructInstance", fieldReferenceNode.Field.Name);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("InstanceParameterlessMethod", actionCallNode.Method.Name);
                    Assert.Equal(NthValueChild(x, 0), actionCallNode.Instance);
                    Assert.Empty(actionCallNode.Parameters);
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallGenericParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallGenericParameterlessMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode = CheckNode<ActionCallNode>(x);

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("StaticGenericMethod", actionCallNode.Method.Name);
                    Assert.Null(actionCallNode.Instance);
                    Assert.Empty(actionCallNode.Parameters);
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallGenericClassParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallGenericClassParameterlessMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode = CheckNode<ActionCallNode>(x);

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("StaticGenericMethod", actionCallNode.Method.Name);
                    Assert.Null(actionCallNode.Instance);
                    Assert.Empty(actionCallNode.Parameters);
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallMethodWithRefParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallMethodWithRefParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var variableAssignmentNode =
                        CheckNode<VariableAssignmentNode>(
                            x,
                            y =>
                            {
                                var literalNode = CheckNode<LiteralNode>(y);
                                Assert.Equal(1, (int)literalNode.Value);
                            });

                    Assert.NotNull(variableAssignmentNode.Variable);
                    Assert.Equal(0, variableAssignmentNode.Variable.Index);
                    Assert.Same(NthValueChild(x, 0), variableAssignmentNode.Value);
                },
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var variableReferenceNode = CheckNode<VariableReferenceNode>(y);
                                Assert.NotNull(variableReferenceNode.Variable);
                                Assert.Equal(0, variableReferenceNode.Variable.Index);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("StaticMethodWithRef", actionCallNode.Method.Name);
                    Assert.Null(actionCallNode.Instance);
                    Assert.Collection(
                        actionCallNode.Parameters,
                        y => Assert.Same(NthValueChild(x, 0), y));
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallMethodWithOutParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallMethodWithOutParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var variableReferenceNode = CheckNode<VariableReferenceNode>(y);
                                Assert.NotNull(variableReferenceNode.Variable);
                                Assert.Equal(0, variableReferenceNode.Variable.Index);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("StaticMethodWithOut", actionCallNode.Method.Name);
                    Assert.Null(actionCallNode.Instance);
                    Assert.Collection(
                        actionCallNode.Parameters,
                        y => Assert.Same(NthValueChild(x, 0), y));
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallMethodWithDiscardedOutParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallMethodWithDiscardedOutParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var variableReferenceNode = CheckNode<VariableReferenceNode>(y);
                                Assert.NotNull(variableReferenceNode.Variable);
                                Assert.Equal(0, variableReferenceNode.Variable.Index);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("StaticMethodWithOut", actionCallNode.Method.Name);
                    Assert.Null(actionCallNode.Instance);
                    Assert.Collection(
                        actionCallNode.Parameters,
                        y => Assert.Same(NthValueChild(x, 0), y));
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallMethodWithGenericParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallMethodWithGenericParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var literalNode = CheckNode<LiteralNode>(y);
                                Assert.Equal(2, (int)literalNode.Value);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("StaticMethodWithGenericParameter", actionCallNode.Method.Name);
                    Assert.Null(actionCallNode.Instance);
                    Assert.Collection(
                        actionCallNode.Parameters,
                        y => Assert.Same(NthValueChild(x, 0), y));
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallMethodWithGenericRefParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallMethodWithGenericRefParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var variableAssignmentNode =
                        CheckNode<VariableAssignmentNode>(
                            x,
                            y =>
                            {
                                var literalNode = CheckNode<LiteralNode>(y);
                                Assert.Equal(2, (int)literalNode.Value);
                            });

                    Assert.NotNull(variableAssignmentNode.Variable);
                    Assert.Equal(0, variableAssignmentNode.Variable.Index);
                    Assert.Same(NthValueChild(x, 0), variableAssignmentNode.Value);
                },
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var variableReferenceNode = CheckNode<VariableReferenceNode>(y);
                                Assert.NotNull(variableReferenceNode.Variable);
                                Assert.Equal(0, variableReferenceNode.Variable.Index);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("StaticMethodWithGenericRefParameter", actionCallNode.Method.Name);
                    Assert.Null(actionCallNode.Instance);
                    Assert.Collection(
                        actionCallNode.Parameters,
                        y => Assert.Same(NthValueChild(x, 0), y));
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallGenericMethodUsingGenericParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallGenericMethodUsingGenericParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCallNode =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var parameterReferenceNode = CheckNode<ParameterReferenceNode>(y);
                                Assert.NotNull(parameterReferenceNode.Parameter);
                                Assert.Equal(0, parameterReferenceNode.Parameter.Index);
                            });

                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("Execute", actionCallNode.Method.Name);
                    Assert.Same(NthValueChild(x, 0), actionCallNode.Instance);
                    Assert.Empty(actionCallNode.Parameters);
                    Assert.False(actionCallNode.IsBaseCall);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
