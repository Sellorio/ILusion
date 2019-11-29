using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ParameterAssignmentTests : TestBase
    {
        [Fact]
        public void Class()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterAssignmentSamples), nameof(ParameterAssignmentSamples.Class));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var parameterAssignment = CheckNode<ParameterAssignmentNode>(x, y => CheckNode<LiteralNode>(y));
                    Assert.NotNull(parameterAssignment.Parameter);
                    Assert.Equal(0, parameterAssignment.Parameter.Index);
                    Assert.Equal(NthValueChild(x, 0), parameterAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Struct()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterAssignmentSamples), nameof(ParameterAssignmentSamples.Struct));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var parameterAssignment = CheckNode<ParameterAssignmentNode>(x, y => CheckNode<PropertyNode>(y));
                    Assert.NotNull(parameterAssignment.Parameter);
                    Assert.Equal(0, parameterAssignment.Parameter.Index);
                    Assert.Equal(NthValueChild(x, 0), parameterAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Generic()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterAssignmentSamples), nameof(ParameterAssignmentSamples.Generic));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var parameterAssignment = CheckNode<ParameterAssignmentNode>(x, y => CheckNode<ParameterNode>(y));
                    Assert.NotNull(parameterAssignment.Parameter);
                    Assert.Equal(0, parameterAssignment.Parameter.Index);
                    Assert.Equal(NthValueChild(x, 0), parameterAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GenericNew()
        {
            var sampleMethod = GetSampleMethod(nameof(ParameterAssignmentSamples), nameof(ParameterAssignmentSamples.GenericNew));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var parameterAssignment = CheckNode<ParameterAssignmentNode>(x, y => CheckNode<NewNode>(y));
                    Assert.NotNull(parameterAssignment.Parameter);
                    Assert.Equal(0, parameterAssignment.Parameter.Index);
                    Assert.Equal(NthValueChild(x, 0), parameterAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
