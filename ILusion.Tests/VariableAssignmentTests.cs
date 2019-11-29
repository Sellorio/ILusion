using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class VariableAssignmentTests : TestBase
    {
        [Fact]
        public void Class()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableAssignmentSamples), nameof(VariableAssignmentSamples.Class));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var variableAssignment = CheckNode<VariableAssignmentNode>(x, y => CheckNode<LiteralNode>(y));
                    Assert.NotNull(variableAssignment.Variable);
                    Assert.Equal(0, variableAssignment.Variable.Index);
                    Assert.Equal(NthValueChild(x, 0), variableAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Struct()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableAssignmentSamples), nameof(VariableAssignmentSamples.Struct));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var variableAssignment = CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y));
                    Assert.NotNull(variableAssignment.Variable);
                    Assert.Equal(0, variableAssignment.Variable.Index);
                    Assert.Equal(NthValueChild(x, 0), variableAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Generic()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableAssignmentSamples), nameof(VariableAssignmentSamples.Generic));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var variableAssignment = CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y));
                    Assert.NotNull(variableAssignment.Variable);
                    Assert.Equal(0, variableAssignment.Variable.Index);
                    Assert.Equal(NthValueChild(x, 0), variableAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GenericNew()
        {
            var sampleMethod = GetSampleMethod(nameof(VariableAssignmentSamples), nameof(VariableAssignmentSamples.GenericNew));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var variableAssignment = CheckNode<VariableAssignmentNode>(x, y => CheckNode<NewNode>(y));
                    Assert.NotNull(variableAssignment.Variable);
                    Assert.Equal(0, variableAssignment.Variable.Index);
                    Assert.Equal(NthValueChild(x, 0), variableAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
