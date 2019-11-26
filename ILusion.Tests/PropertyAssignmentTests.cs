using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class PropertyAssignmentTests : TestBase
    {
        [Fact]
        public void SetInstanceAutoProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertyAssignmentSamples), nameof(PropertyAssignmentSamples.SetInstanceAutoProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var propertyAssignment =
                        CheckNode<PropertyAssignmentNode>(x,
                            y => CheckNode<ThisNode>(y),
                            y => CheckNode<LiteralNode>(y));

                    Assert.Same(NthValueChild(x, 0), propertyAssignment.Instance);
                    Assert.Same(NthValueChild(x, 1), propertyAssignment.Value);
                    Assert.False(propertyAssignment.IsBaseCall);
                    Assert.NotNull(propertyAssignment.Property);
                    Assert.Equal("InstanceAutoProperty", propertyAssignment.Property.Name);
                    Assert.Null(propertyAssignment.ConstrainedModifier);
                    Assert.NotNull(propertyAssignment.SetMethod);
                    Assert.Equal("set_InstanceAutoProperty", propertyAssignment.SetMethod.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetInstanceSetProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertyAssignmentSamples), nameof(PropertyAssignmentSamples.SetInstanceSetProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var propertyAssignment =
                        CheckNode<PropertyAssignmentNode>(x,
                            y => CheckNode<ThisNode>(y),
                            y => CheckNode<LiteralNode>(y));

                    Assert.Same(NthValueChild(x, 0), propertyAssignment.Instance);
                    Assert.Same(NthValueChild(x, 1), propertyAssignment.Value);
                    Assert.False(propertyAssignment.IsBaseCall);
                    Assert.NotNull(propertyAssignment.Property);
                    Assert.Equal("InstanceSetProperty", propertyAssignment.Property.Name);
                    Assert.Null(propertyAssignment.ConstrainedModifier);
                    Assert.NotNull(propertyAssignment.SetMethod);
                    Assert.Equal("set_InstanceSetProperty", propertyAssignment.SetMethod.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetInstanceVirtualAutoProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertyAssignmentSamples), nameof(PropertyAssignmentSamples.SetInstanceVirtualAutoProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var propertyAssignment =
                        CheckNode<PropertyAssignmentNode>(x,
                            y => CheckNode<ThisNode>(y),
                            y => CheckNode<LiteralNode>(y));

                    Assert.Same(NthValueChild(x, 0), propertyAssignment.Instance);
                    Assert.Same(NthValueChild(x, 1), propertyAssignment.Value);
                    Assert.False(propertyAssignment.IsBaseCall);
                    Assert.NotNull(propertyAssignment.Property);
                    Assert.Equal("InstanceVirtualAutoProperty", propertyAssignment.Property.Name);
                    Assert.Null(propertyAssignment.ConstrainedModifier);
                    Assert.NotNull(propertyAssignment.SetMethod);
                    Assert.Equal("set_InstanceVirtualAutoProperty", propertyAssignment.SetMethod.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetInstanceVirtualSetProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertyAssignmentSamples), nameof(PropertyAssignmentSamples.SetInstanceVirtualSetProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var propertyAssignment =
                        CheckNode<PropertyAssignmentNode>(x,
                            y => CheckNode<ThisNode>(y),
                            y => CheckNode<LiteralNode>(y));

                    Assert.Same(NthValueChild(x, 0), propertyAssignment.Instance);
                    Assert.Same(NthValueChild(x, 1), propertyAssignment.Value);
                    Assert.False(propertyAssignment.IsBaseCall);
                    Assert.NotNull(propertyAssignment.Property);
                    Assert.Equal("InstanceVirtualSetProperty", propertyAssignment.Property.Name);
                    Assert.Null(propertyAssignment.ConstrainedModifier);
                    Assert.NotNull(propertyAssignment.SetMethod);
                    Assert.Equal("set_InstanceVirtualSetProperty", propertyAssignment.SetMethod.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetStaticAutoProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertyAssignmentSamples), nameof(PropertyAssignmentSamples.SetStaticAutoProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var propertyAssignment =
                        CheckNode<PropertyAssignmentNode>(x,
                            y => CheckNode<LiteralNode>(y));

                    Assert.Null(propertyAssignment.Instance);
                    Assert.Same(NthValueChild(x, 0), propertyAssignment.Value);
                    Assert.False(propertyAssignment.IsBaseCall);
                    Assert.NotNull(propertyAssignment.Property);
                    Assert.Equal("StaticAutoProperty", propertyAssignment.Property.Name);
                    Assert.Null(propertyAssignment.ConstrainedModifier);
                    Assert.NotNull(propertyAssignment.SetMethod);
                    Assert.Equal("set_StaticAutoProperty", propertyAssignment.SetMethod.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetStaticSetProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertyAssignmentSamples), nameof(PropertyAssignmentSamples.SetStaticSetProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var propertyAssignment =
                        CheckNode<PropertyAssignmentNode>(x,
                            y => CheckNode<LiteralNode>(y));

                    Assert.Null(propertyAssignment.Instance);
                    Assert.Same(NthValueChild(x, 0), propertyAssignment.Value);
                    Assert.False(propertyAssignment.IsBaseCall);
                    Assert.NotNull(propertyAssignment.Property);
                    Assert.Equal("StaticSetProperty", propertyAssignment.Property.Name);
                    Assert.Null(propertyAssignment.ConstrainedModifier);
                    Assert.NotNull(propertyAssignment.SetMethod);
                    Assert.Equal("set_StaticSetProperty", propertyAssignment.SetMethod.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetBaseProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertyAssignmentSamples), "set_BaseProperty");
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var propertyAssignment =
                        CheckNode<PropertyAssignmentNode>(x,
                            y => CheckNode<ThisNode>(y),
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), propertyAssignment.Instance);
                    Assert.Same(NthValueChild(x, 1), propertyAssignment.Value);
                    Assert.True(propertyAssignment.IsBaseCall);
                    Assert.NotNull(propertyAssignment.Property);
                    Assert.Equal("BaseProperty", propertyAssignment.Property.Name);
                    Assert.Null(propertyAssignment.ConstrainedModifier);
                    Assert.NotNull(propertyAssignment.SetMethod);
                    Assert.Equal("set_BaseProperty", propertyAssignment.SetMethod.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ConstrainedSet()
        {
            var sampleMethod = GetSampleMethod("GenericPropertyAssignmentSamples", "ConstrainedSet");
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var propertyAssignment =
                        CheckNode<PropertyAssignmentNode>(x,
                            y => CheckNode<ParameterReferenceNode>(y),
                            y => CheckNode<LiteralNode>(y));

                    Assert.Same(NthValueChild(x, 0), propertyAssignment.Instance);
                    Assert.Same(NthValueChild(x, 1), propertyAssignment.Value);
                    Assert.False(propertyAssignment.IsBaseCall);
                    Assert.NotNull(propertyAssignment.Property);
                    Assert.Equal("Prop", propertyAssignment.Property.Name);
                    Assert.NotNull(propertyAssignment.ConstrainedModifier);
                    Assert.Equal("T", propertyAssignment.ConstrainedModifier.FullName);
                    Assert.NotNull(propertyAssignment.SetMethod);
                    Assert.Equal("set_Prop", propertyAssignment.SetMethod.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SetPropertyFromGeneric()
        {
            var sampleMethod = GetSampleMethod("GenericPropertyAssignmentSamples", "SetPropertyFromGeneric");
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var propertyAssignment =
                        CheckNode<PropertyAssignmentNode>(x,
                            y => CheckNode<LiteralNode>(y));

                    Assert.Null(propertyAssignment.Instance);
                    Assert.Same(NthValueChild(x, 0), propertyAssignment.Value);
                    Assert.False(propertyAssignment.IsBaseCall);
                    Assert.NotNull(propertyAssignment.Property);
                    Assert.Equal("Property", propertyAssignment.Property.Name);
                    Assert.Null(propertyAssignment.ConstrainedModifier);
                    Assert.NotNull(propertyAssignment.SetMethod);
                    Assert.Equal("set_Property", propertyAssignment.SetMethod.Name);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
