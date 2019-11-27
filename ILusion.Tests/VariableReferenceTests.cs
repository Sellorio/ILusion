using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class VariableReferenceTests : TestBase
    {
        [Fact]
        public void AsRef()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableReferenceSamples), nameof(VariableReferenceSamples.AsRef));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<ActionCallNode>(x,
                    y =>
                    {
                        var variable = CheckNode<VariableReferenceNode>(y);
                        Assert.NotNull(variable.Variable);
                        Assert.Equal(0, variable.Variable.Index);
                        Assert.Equal("System.String*", variable.GetValueType()?.FullName);
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Initialize()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableReferenceSamples), nameof(VariableReferenceSamples.Initialize));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<InitializeNode>(x,
                    y =>
                    {
                        var variable = CheckNode<VariableReferenceNode>(y);
                        Assert.NotNull(variable.Variable);
                        Assert.Equal(0, variable.Variable.Index);
                        Assert.Equal("System.DateTime*", variable.GetValueType()?.FullName);
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructInstanceMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableReferenceSamples), nameof(VariableReferenceSamples.StructInstanceMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<ParameterNode>(y)),
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<FunctionCallNode>(y,
                        z =>
                        {
                            var variable = CheckNode<VariableReferenceNode>(z);
                            Assert.NotNull(variable.Variable);
                            Assert.Equal(0, variable.Variable.Index);
                            Assert.Equal("System.DateTime*", variable.GetValueType()?.FullName);
                        })),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GenericInstanceMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableReferenceSamples), nameof(VariableReferenceSamples.GenericInstanceMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<ParameterNode>(y)),
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<FunctionCallNode>(y,
                        z =>
                        {
                            var variable = CheckNode<VariableReferenceNode>(z);
                            Assert.NotNull(variable.Variable);
                            Assert.Equal(0, variable.Variable.Index);
                            Assert.Equal("T*", variable.GetValueType()?.FullName);
                        })),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructGenericInstanceMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableReferenceSamples), nameof(VariableReferenceSamples.StructGenericInstanceMethod));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<ParameterNode>(y)),
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<FunctionCallNode>(y,
                        z =>
                        {
                            var variable = CheckNode<VariableReferenceNode>(z);
                            Assert.NotNull(variable.Variable);
                            Assert.Equal(0, variable.Variable.Index);
                            Assert.Equal("T*", variable.GetValueType()?.FullName);
                        })),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
