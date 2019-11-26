using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class FieldAssignmentTests : TestBase
    {
        [Fact]
        public void InstanceClassFromParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldAssignmentSamples), nameof(FieldAssignmentSamples.InstanceClassFromParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var fieldAssignment =
                        CheckNode<FieldAssignmentNode>(x,
                            y => CheckNode<ThisNode>(y),
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), fieldAssignment.Instance);
                    Assert.Same(NthValueChild(x, 1), fieldAssignment.Value);
                    Assert.NotNull(fieldAssignment.Field);
                    Assert.Equal("_instanceClassField", fieldAssignment.Field.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void InstanceClassFromArray()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldAssignmentSamples), nameof(FieldAssignmentSamples.InstanceClassFromArray));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var fieldAssignment =
                        CheckNode<FieldAssignmentNode>(x,
                            y => CheckNode<ThisNode>(y),
                            y => CheckNode<ArrayElementNode>(y,
                                z => CheckNode<ParameterNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    Assert.Same(NthValueChild(x, 0), fieldAssignment.Instance);
                    Assert.Same(NthValueChild(x, 1), fieldAssignment.Value);
                    Assert.NotNull(fieldAssignment.Field);
                    Assert.Equal("_instanceClassField", fieldAssignment.Field.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void InstanceStructFromParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldAssignmentSamples), nameof(FieldAssignmentSamples.InstanceStructFromParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var fieldAssignment =
                        CheckNode<FieldAssignmentNode>(x,
                            y => CheckNode<ThisNode>(y),
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), fieldAssignment.Instance);
                    Assert.Same(NthValueChild(x, 1), fieldAssignment.Value);
                    Assert.NotNull(fieldAssignment.Field);
                    Assert.Equal("_instanceStructField", fieldAssignment.Field.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StaticClassFromParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldAssignmentSamples), nameof(FieldAssignmentSamples.StaticClassFromParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var fieldAssignment =
                        CheckNode<FieldAssignmentNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), fieldAssignment.Value);
                    Assert.NotNull(fieldAssignment.Field);
                    Assert.Equal("_staticClassField", fieldAssignment.Field.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StaticClassFromArray()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldAssignmentSamples), nameof(FieldAssignmentSamples.StaticClassFromArray));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var fieldAssignment =
                        CheckNode<FieldAssignmentNode>(x,
                            y => CheckNode<ArrayElementNode>(y,
                                z => CheckNode<ParameterNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    Assert.Same(NthValueChild(x, 0), fieldAssignment.Value);
                    Assert.NotNull(fieldAssignment.Field);
                    Assert.Equal("_staticClassField", fieldAssignment.Field.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StaticStructFromParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldAssignmentSamples), nameof(FieldAssignmentSamples.StaticStructFromParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var fieldAssignment =
                        CheckNode<FieldAssignmentNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), fieldAssignment.Value);
                    Assert.NotNull(fieldAssignment.Field);
                    Assert.Equal("_staticStructField", fieldAssignment.Field.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
