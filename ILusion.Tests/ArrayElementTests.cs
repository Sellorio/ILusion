using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ArrayElementTests : TestBase
    {
        [Fact]
        public void CopyInt8ToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyInt8ToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.SByte", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyInt16ToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyInt16ToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.Int16", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyInt32ToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyInt32ToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.Int32", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyInt64ToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyInt64ToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.Int64", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyUInt8ToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyUInt8ToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.Byte", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyUInt16ToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyUInt16ToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.UInt16", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyUInt32ToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyUInt32ToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.UInt32", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyUInt64ToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyUInt64ToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.UInt64", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyFloatToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyFloatToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.Single", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyDoubleToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyDoubleToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.Double", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyStringToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyStringToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.String", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyDateTimeToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyDateTimeToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("System.DateTime", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyGenericToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyGenericToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("T", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyClassGenericToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyClassGenericToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("T", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CopyStructGenericToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementSamples), nameof(ArrayElementSamples.CopyStructGenericToVariable));
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
                                var arrayElement =
                                    CheckNode<ArrayElementNode>(
                                        y,
                                        z => CheckNode<ParameterNode>(z),
                                        z => CheckNode<LiteralNode>(z));

                                Assert.Same(NthValueChild(arrayElement, 0), arrayElement.Array);
                                Assert.Same(NthValueChild(arrayElement, 1), arrayElement.Index);
                                Assert.Equal("T", arrayElement.GetValueType()?.FullName);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
