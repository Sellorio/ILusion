using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class FieldTests : TestBase
    {
        [Fact]
        public void InstanceClassParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldSamples), nameof(FieldSamples.InstanceClassParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ActionCallNode>(x,
                    y =>
                    {
                        var field = CheckNode<FieldNode>(y, z => CheckNode<ThisNode>(z));
                        Assert.Same(NthValueChild(y, 0), field.Instance);
                        Assert.NotNull(field.Field);
                        Assert.Equal("_instanceClassField", field.Field.Name);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void InstanceClassToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldSamples), nameof(FieldSamples.InstanceClassToVariable));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var field = CheckNode<FieldNode>(y, z => CheckNode<ThisNode>(z));
                        Assert.Same(NthValueChild(y, 0), field.Instance);
                        Assert.NotNull(field.Field);
                        Assert.Equal("_instanceClassField", field.Field.Name);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void InstanceStructToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldSamples), nameof(FieldSamples.InstanceStructToVariable));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var field = CheckNode<FieldNode>(y, z => CheckNode<ThisNode>(z));
                        Assert.Same(NthValueChild(y, 0), field.Instance);
                        Assert.NotNull(field.Field);
                        Assert.Equal("_instanceStructField", field.Field.Name);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StaticClassParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldSamples), nameof(FieldSamples.StaticClassParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ActionCallNode>(x,
                    y =>
                    {
                        var field = CheckNode<FieldNode>(y);
                        Assert.Null(field.Instance);
                        Assert.NotNull(field.Field);
                        Assert.Equal("_staticClassField", field.Field.Name);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StaticClassToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldSamples), nameof(FieldSamples.StaticClassToVariable));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var field = CheckNode<FieldNode>(y);
                        Assert.Null(field.Instance);
                        Assert.NotNull(field.Field);
                        Assert.Equal("_staticClassField", field.Field.Name);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StaticStructToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldSamples), nameof(FieldSamples.StaticStructToVariable));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var field = CheckNode<FieldNode>(y);
                        Assert.Null(field.Instance);
                        Assert.NotNull(field.Field);
                        Assert.Equal("_staticStructField", field.Field.Name);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
