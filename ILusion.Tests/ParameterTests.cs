using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ParameterTests : TestBase
    {
        [Fact]
        public void Struct()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.Struct));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.DateTime", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Class()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.Class));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.String", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Generic()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.Generic));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("T", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SByteByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.SByteByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.SByte", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ByteByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.ByteByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Byte", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ShortByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.ShortByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Int16", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void UShortByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.UShortByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.UInt16", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void IntByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.IntByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Int32", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void UIntByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.UIntByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.UInt32", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void LongByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.LongByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Int64", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ULongByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.ULongByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.UInt64", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void FloatByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.FloatByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Single", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void DoubleByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.DoubleByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Double", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.StructByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.DateTime", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ClassByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.ClassByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.String", parameter.GetValueType()?.FullName);
                    }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ByRefNative()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterSamples), nameof(ParameterSamples.ByRefNative));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ActionCallNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterReferenceNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.String*", parameter.GetValueType()?.FullName);
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
