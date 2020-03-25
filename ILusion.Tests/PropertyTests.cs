using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class PropertyTests : TestBase
    {
        [Fact]
        public void GetInstanceAutoProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertySamples), nameof(PropertySamples.GetInstanceAutoProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property =
                            CheckNode<PropertyNode>(y,
                                z => CheckNode<ThisNode>(z));

                        Assert.Same(NthValueChild(y, 0), property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("InstanceAutoProperty", property.Property.Name);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GetInstanceGetProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertySamples), nameof(PropertySamples.GetInstanceGetProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property =
                            CheckNode<PropertyNode>(y,
                                z => CheckNode<ThisNode>(z));

                        Assert.Same(NthValueChild(y, 0), property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("InstanceGetProperty", property.Property.Name);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GetInstanceVirtualAutoProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertySamples), nameof(PropertySamples.GetInstanceVirtualAutoProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property =
                            CheckNode<PropertyNode>(y,
                                z => CheckNode<ThisNode>(z));

                        Assert.Same(NthValueChild(y, 0), property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("InstanceVirtualAutoProperty", property.Property.Name);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GetInstanceVirtualGetProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertySamples), nameof(PropertySamples.GetInstanceVirtualGetProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property =
                            CheckNode<PropertyNode>(y,
                                z => CheckNode<ThisNode>(z));

                        Assert.Same(NthValueChild(y, 0), property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("InstanceVirtualGetProperty", property.Property.Name);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GetStaticAutoProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertySamples), nameof(PropertySamples.GetStaticAutoProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property = CheckNode<PropertyNode>(y);

                        Assert.Null(property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("StaticAutoProperty", property.Property.Name);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GetStaticGetProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertySamples), nameof(PropertySamples.GetStaticGetProperty));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property = CheckNode<PropertyNode>(y);

                        Assert.Null(property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("StaticGetProperty", property.Property.Name);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GetBaseProperty()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertySamples), "get_BaseProperty");
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var property =
                            CheckNode<PropertyNode>(y,
                                z => CheckNode<ThisNode>(z));

                        Assert.Same(NthValueChild(y, 0), property.Instance);
                        Assert.True(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("BaseProperty", property.Property.Name);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ConstrainedGet()
        {
            var sampleMethod = GetSampleMethod("GenericPropertySamples", "ConstrainedGet");
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property =
                            CheckNode<PropertyNode>(y,
                                z => CheckNode<ParameterReferenceNode>(z));

                        Assert.Same(NthValueChild(y, 0), property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Equal("Prop", property.Property.Name);
                        Assert.NotNull(property.ConstrainedModifier);
                        Assert.Equal("T", property.ConstrainedModifier.FullName);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GetPropertyFromGeneric()
        {
            var sampleMethod = GetSampleMethod("GenericPropertySamples", "GetPropertyFromGeneric");
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property = CheckNode<PropertyNode>(y);

                        Assert.Null(property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Equal("Property", property.Property.Name);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GetInstanceAutoPropertyStruct()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertySamplesStruct), nameof(PropertySamplesStruct.GetInstanceAutoPropertyStruct));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property =
                            CheckNode<PropertyNode>(y,
                                z => CheckNode<ThisReferenceNode>(z));

                        Assert.Same(NthValueChild(y, 0), property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("InstanceAutoProperty", property.Property.Name);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GetInstanceAutoPropertyOnObject()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertySamplesStruct), nameof(PropertySamplesStruct.GetInstanceAutoPropertyOnObject));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property =
                            CheckNode<PropertyNode>(y,
                                z => CheckNode<ParameterNode>(z));

                        Assert.Same(NthValueChild(y, 0), property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("InstanceAutoProperty", property.Property.Name);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void GetInstanceVirtualAutoPropertyOnObject()
        {
            var sampleMethod = GetSampleMethod(nameof(PropertySamplesStruct), nameof(PropertySamplesStruct.GetInstanceVirtualAutoPropertyOnObject));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var property =
                            CheckNode<PropertyNode>(y,
                                z => CheckNode<ParameterNode>(z));

                        Assert.Same(NthValueChild(y, 0), property.Instance);
                        Assert.False(property.IsBaseCall);
                        Assert.NotNull(property.Property);
                        Assert.Null(property.ConstrainedModifier);
                        Assert.Equal("InstanceVirtualAutoProperty", property.Property.Name);
                        Assert.Equal("System.String", property.GetValueType()?.FullName);
                    }));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
