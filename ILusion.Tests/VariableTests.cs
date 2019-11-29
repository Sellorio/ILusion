using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class VariableTests : TestBase
    {
        [Fact]
        public void Struct()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.Struct));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.DateTime", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Class()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.Class));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.String", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Generic()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.Generic));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("T", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SByteByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.SByteByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.SByte", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ByteByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.ByteByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Byte", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ShortByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.ShortByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Int16", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void UShortByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.UShortByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.UInt16", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void IntByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.IntByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Int32", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void UIntByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.UIntByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.UInt32", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void LongByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.LongByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Int64", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ULongByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.ULongByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.UInt64", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void FloatByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.FloatByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Single", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void DoubleByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.DoubleByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.Double", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.StructByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.DateTime", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ClassByRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.ClassByRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.String", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ByRefNative()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableSamples), nameof(VariableSamples.ByRefNative));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ActionCallNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterReferenceNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.String*", parameter.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
