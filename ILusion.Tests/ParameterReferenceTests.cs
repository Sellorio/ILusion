using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ParameterReferenceTests : TestBase
    {
        [Fact]
        public void AsRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterReferenceSamples), nameof(ParameterReferenceSamples.AsRef));
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

        [Fact]
        public void RefAsRef()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterReferenceSamples), nameof(ParameterReferenceSamples.RefAsRef));
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

        [Fact]
        public void Initialize()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterReferenceSamples), nameof(ParameterReferenceSamples.Initialize));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<InitializeNode>(x,
                    y =>
                    {
                        var parameter = CheckNode<ParameterReferenceNode>(y);
                        Assert.Equal(0, parameter.Parameter?.Index);
                        Assert.Equal("System.DateTime*", parameter.GetValueType()?.FullName);
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructInstanceMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterReferenceSamples), nameof(ParameterReferenceSamples.StructInstanceMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<FunctionCallNode>(y,
                        z =>
                        {
                            var parameter = CheckNode<ParameterReferenceNode>(z);
                            Assert.Equal(0, parameter.Parameter?.Index);
                            Assert.Equal("System.DateTime*", parameter.GetValueType()?.FullName);
                        })),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GenericInstanceMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterReferenceSamples), nameof(ParameterReferenceSamples.GenericInstanceMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<FunctionCallNode>(y,
                        z =>
                        {
                            var parameter = CheckNode<ParameterReferenceNode>(z);
                            Assert.Equal(0, parameter.Parameter?.Index);
                            Assert.Equal("T*", parameter.GetValueType()?.FullName);
                        })),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructGenericInstanceMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterReferenceSamples), nameof(ParameterReferenceSamples.StructGenericInstanceMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<FunctionCallNode>(y,
                        z =>
                        {
                            var parameter = CheckNode<ParameterReferenceNode>(z);
                            Assert.Equal(0, parameter.Parameter?.Index);
                            Assert.Equal("T*", parameter.GetValueType()?.FullName);
                        })),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
