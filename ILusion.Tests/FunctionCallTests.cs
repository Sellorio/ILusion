using ILusion.Methods;
using ILusion.Methods.LogicTrees;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using System.Linq;
using Xunit;

namespace ILusion.Tests
{
    public class FunctionCallTests : TestBase
    {
        [Fact]
        public void CallStaticParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallStaticParameterlessMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode = CheckNode<FunctionCallNode>(x);
                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("StaticParameterlessMethod", functionCallNode.Method.Name);
                                Assert.Null(functionCallNode.Instance);
                                Assert.Empty(functionCallNode.Parameters);
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallStaticParameterisedMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallStaticParameterisedMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
                                        x,
                                        y =>
                                        {
                                            var literalNode = CheckNode<LiteralNode>(y);
                                            var intValue = Assert.IsType<int>(literalNode.Value);
                                            Assert.Equal(5, intValue);
                                        });

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("StaticParameterisedMethod", functionCallNode.Method.Name);
                                Assert.Null(functionCallNode.Instance);
                                Assert.Collection(functionCallNode.Parameters, y => Assert.Same(NthValueChild(x, 0), y));
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallInstanceParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallInstanceParameterlessMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
                                        x,
                                        y =>
                                        {
                                            var propertyNode = CheckNode<PropertyNode>(y);
                                            Assert.Null(propertyNode.Instance);
                                            Assert.False(propertyNode.IsBaseCall);
                                            Assert.NotNull(propertyNode.Property);
                                            Assert.Equal("Instance", propertyNode.Property.Name);
                                        });

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("InstanceParameterlessMethod", functionCallNode.Method.Name);
                                Assert.Same(NthValueChild(x, 0), functionCallNode.Instance);
                                Assert.Empty(functionCallNode.Parameters);
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallInstanceParameterisedMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallInstanceParameterisedMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
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

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("InstanceParameterisedMethod", functionCallNode.Method.Name);
                                Assert.Same(NthValueChild(x, 0), functionCallNode.Instance);
                                Assert.Collection(functionCallNode.Parameters, y => Assert.Same(NthValueChild(x, 1), y));
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallBaseParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallBaseParameterlessMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    CheckNode<VariableAssignmentNode>(
                        d,
                        x =>
                        {
                            var functionCallNode =
                                CheckNode<FunctionCallNode>(
                                    x,
                                    y => CheckNode<ThisNode>(y));

                            Assert.NotNull(functionCallNode.Method);
                            Assert.Equal("CallBaseParameterlessMethod", functionCallNode.Method.Name);
                            Assert.Equal(NthValueChild(x, 0), functionCallNode.Instance);
                            Assert.Empty(functionCallNode.Parameters);
                            Assert.True(functionCallNode.IsBaseCall);
                        });
                },
                x =>
                {
                    CheckNode<GoToNode>(x);
                },
                x =>
                {
                    var returnNode =
                        CheckNode<ReturnNode>(
                            x,
                            y => CheckNode<VariableNode>(y));

                    Assert.Same(NthValueChild(x, 0), returnNode.ReturnValue);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallStructParameterlessMethodFromProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallStructParameterlessMethodFromProperty));
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
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
                                        x,
                                        y =>
                                        {
                                            var variableReferenceNode = CheckNode<VariableReferenceNode>(y);
                                            Assert.NotNull(variableReferenceNode.Variable);
                                            Assert.Equal(0, variableReferenceNode.Variable.Index);
                                        });

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("InstanceParameterlessMethod", functionCallNode.Method.Name);
                                Assert.Equal(NthValueChild(x, 0), functionCallNode.Instance);
                                Assert.Empty(functionCallNode.Parameters);
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallStructParameterlessMethodFromField()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallStructParameterlessMethodFromField));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
                                        x,
                                        y =>
                                        {
                                            var fieldReferenceNode = CheckNode<FieldReferenceNode>(y);
                                            Assert.Null(fieldReferenceNode.Instance);
                                            Assert.NotNull(fieldReferenceNode.Field);
                                            Assert.Equal("StructInstance", fieldReferenceNode.Field.Name);
                                        });

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("InstanceParameterlessMethod", functionCallNode.Method.Name);
                                Assert.Equal(NthValueChild(x, 0), functionCallNode.Instance);
                                Assert.Empty(functionCallNode.Parameters);
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallGenericParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallGenericParameterlessMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode = CheckNode<FunctionCallNode>(x);

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("StaticGenericMethod", functionCallNode.Method.Name);
                                Assert.Null(functionCallNode.Instance);
                                Assert.Empty(functionCallNode.Parameters);
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallGenericClassParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallGenericClassParameterlessMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode = CheckNode<FunctionCallNode>(x);

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("StaticGenericMethod", functionCallNode.Method.Name);
                                Assert.Null(functionCallNode.Instance);
                                Assert.Empty(functionCallNode.Parameters);
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallMethodWithRefParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallMethodWithRefParameter));
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
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
                                        x,
                                        y =>
                                        {
                                            var variableReferenceNode = CheckNode<VariableReferenceNode>(y);
                                            Assert.NotNull(variableReferenceNode.Variable);
                                            Assert.Equal(0, variableReferenceNode.Variable.Index);
                                        });

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("StaticMethodWithRef", functionCallNode.Method.Name);
                                Assert.Null(functionCallNode.Instance);
                                Assert.Collection(
                                    functionCallNode.Parameters,
                                    y => Assert.Same(NthValueChild(x, 0), y));
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallMethodWithOutParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallMethodWithOutParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
                                        x,
                                        y =>
                                        {
                                            var variableReferenceNode = CheckNode<VariableReferenceNode>(y);
                                            Assert.NotNull(variableReferenceNode.Variable);
                                            Assert.Equal(0, variableReferenceNode.Variable.Index);
                                        });

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("StaticMethodWithOut", functionCallNode.Method.Name);
                                Assert.Null(functionCallNode.Instance);
                                Assert.Collection(
                                    functionCallNode.Parameters,
                                    y => Assert.Same(NthValueChild(x, 0), y));
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallMethodWithDiscardedOutParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallMethodWithDiscardedOutParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
                                        x,
                                        y =>
                                        {
                                            var variableReferenceNode = CheckNode<VariableReferenceNode>(y);
                                            Assert.NotNull(variableReferenceNode.Variable);
                                            Assert.Equal(0, variableReferenceNode.Variable.Index);
                                        });

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("StaticMethodWithOut", functionCallNode.Method.Name);
                                Assert.Null(functionCallNode.Instance);
                                Assert.Collection(
                                    functionCallNode.Parameters,
                                    y => Assert.Same(NthValueChild(x, 0), y));
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallMethodWithGenericParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallMethodWithGenericParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
                                        x,
                                        y =>
                                        {
                                            var literalNode = CheckNode<LiteralNode>(y);
                                            Assert.Equal(2, (int)literalNode.Value);
                                        });

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("StaticMethodWithGenericParameter", functionCallNode.Method.Name);
                                Assert.Null(functionCallNode.Instance);
                                Assert.Collection(
                                    functionCallNode.Parameters,
                                    y => Assert.Same(NthValueChild(x, 0), y));
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallMethodWithGenericRefParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallMethodWithGenericRefParameter));
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
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
                                        x,
                                        y =>
                                        {
                                            var variableReferenceNode = CheckNode<VariableReferenceNode>(y);
                                            Assert.NotNull(variableReferenceNode.Variable);
                                            Assert.Equal(0, variableReferenceNode.Variable.Index);
                                        });

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("StaticMethodWithGenericRefParameter", functionCallNode.Method.Name);
                                Assert.Null(functionCallNode.Instance);
                                Assert.Collection(
                                    functionCallNode.Parameters,
                                    y => Assert.Same(NthValueChild(x, 0), y));
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CallGenericMethodUsingGenericParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FunctionCallSamples), nameof(FunctionCallSamples.CallGenericMethodUsingGenericParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                d =>
                {
                    var discard =
                        CheckNode<DiscardNode>(
                            d,
                            x =>
                            {
                                var functionCallNode =
                                    CheckNode<FunctionCallNode>(
                                        x,
                                        y =>
                                        {
                                            var parameterReferenceNode = CheckNode<ParameterReferenceNode>(y);
                                            Assert.NotNull(parameterReferenceNode.Parameter);
                                            Assert.Equal(0, parameterReferenceNode.Parameter.Index);
                                        });

                                Assert.NotNull(functionCallNode.Method);
                                Assert.Equal("Execute", functionCallNode.Method.Name);
                                Assert.Same(NthValueChild(x, 0), functionCallNode.Instance);
                                Assert.Empty(functionCallNode.Parameters);
                                Assert.False(functionCallNode.IsBaseCall);
                            });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
