using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class NewTests : TestBase
    {
        [Fact]
        public void Generic()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.Generic));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var newNode = CheckNode<NewNode>(y);
                        Assert.Equal("T", newNode.Type?.FullName);
                        Assert.Null(newNode.Constructor);
                        Assert.Empty(newNode.Parameters);
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ClassGeneric()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.ClassGeneric));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var newNode = CheckNode<NewNode>(y);
                        Assert.Equal("T", newNode.Type?.FullName);
                        Assert.Null(newNode.Constructor);
                        Assert.Empty(newNode.Parameters);
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Array()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.Array));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var newNode =
                            CheckNode<NewNode>(
                                y,
                                z => CheckNode<LiteralNode>(z));

                        Assert.Equal("System.Boolean[]", newNode.Type?.FullName);
                        Assert.Null(newNode.Constructor);
                        Assert.Collection(
                            newNode.Parameters,
                            z => Assert.Equal(NthValueChild(y, 0), z));
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void EmptyConstructor()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.EmptyConstructor));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var newNode = CheckNode<NewNode>(y);
                        Assert.Equal("ILusion.Tests.Sample.NewSamples/Class", newNode.Type?.FullName);
                        Assert.NotNull(newNode.Constructor);
                        Assert.Empty(newNode.Parameters);
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ConstructorParameters()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.ConstructorParameters));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var newNode =
                            CheckNode<NewNode>(
                                y,
                                z => CheckNode<LiteralNode>(z));

                        Assert.Equal("ILusion.Tests.Sample.NewSamples/Class", newNode.Type?.FullName);
                        Assert.NotNull(newNode.Constructor);
                        Assert.Collection(
                            newNode.Parameters,
                            z => Assert.Equal(NthValueChild(y, 0), z));
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void NewStructAsParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.NewStructAsParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ActionCallNode>(x,
                    y =>
                    {
                        var newNode =
                            CheckNode<NewNode>(
                                y,
                                z => CheckNode<LiteralNode>(z),
                                z => CheckNode<LiteralNode>(z),
                                z => CheckNode<LiteralNode>(z));

                        Assert.Equal("System.DateTime", newNode.Type?.FullName);
                        Assert.NotNull(newNode.Constructor);
                        Assert.Collection(
                            newNode.Parameters,
                            z => Assert.Equal(NthValueChild(y, 0), z),
                            z => Assert.Equal(NthValueChild(y, 1), z),
                            z => Assert.Equal(NthValueChild(y, 2), z));
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void NewClassAsParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.NewClassAsParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<FunctionCallNode>(y,
                        z =>
                        {
                            var newNode =
                                CheckNode<NewNode>(
                                    z,
                                    a => CheckNode<LiteralNode>(a),
                                    a => CheckNode<LiteralNode>(a));

                            Assert.Equal("System.String", newNode.Type?.FullName);
                            Assert.NotNull(newNode.Constructor);
                            Assert.Collection(
                                newNode.Parameters,
                                a => Assert.Equal(NthValueChild(z, 0), a),
                                a => Assert.Equal(NthValueChild(z, 1), a));
                        })),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void NewClassToString()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.NewClassToString));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<FunctionCallNode>(y,
                        z =>
                        {
                            var newNode =
                                CheckNode<NewNode>(z);

                            Assert.Equal("ILusion.Tests.Sample.NewSamples/Class", newNode.Type?.FullName);
                            Assert.NotNull(newNode.Constructor);
                            Assert.Empty(newNode.Parameters);
                        })),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void CollectionInitializer()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.CollectionInitializer));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ActionCallNode>(x,
                    y =>
                    {
                        var newNode = CheckNode<NewNode>(y);
                        Assert.NotNull(newNode.Type);
                        Assert.Equal("System.Collections.Generic.List`1<System.String>", newNode.Type.FullName);
                        Assert.Empty(newNode.Parameters);
                    },
                    y => CheckNode<ActionCallNode>(y,
                        z => CheckNode<CloneNode>(z),
                        z => CheckNode<LiteralNode>(z)),
                    y => CheckNode<LiteralNode>(y)),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ArrayInitializer()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.ArrayInitializer));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var newNode =
                            CheckNode<NewNode>(
                                y,
                                z => CheckNode<LiteralNode>(z));
                        Assert.NotNull(newNode.Type);
                        Assert.Equal("System.String[]", newNode.Type.FullName);
                        Assert.Collection(
                            newNode.Parameters,
                            z => Assert.Same(NthValueChild(y, 0), z));
                    },
                    y => CheckNode<ArrayElementAssignmentNode>(y,
                        z => CheckNode<CloneNode>(z),
                        z => CheckNode<LiteralNode>(z),
                        z => CheckNode<LiteralNode>(z)),
                    y => CheckNode<ArrayElementAssignmentNode>(y,
                        z => CheckNode<CloneNode>(z),
                        z => CheckNode<LiteralNode>(z),
                        z => CheckNode<LiteralNode>(z))),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AnonymousClass()
        {
            var sampleMethod = GetSampleMethod(nameof(NewSamples), nameof(NewSamples.AnonymousClass));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y =>
                    {
                        var newNode =
                            CheckNode<NewNode>(
                                y,
                                z => CheckNode<LiteralNode>(z),
                                z => CheckNode<LiteralNode>(z));
                        Assert.NotNull(newNode.Type);
                        Assert.Equal("<>f__AnonymousType0`2<System.String,System.String>", newNode.Type.FullName);
                        Assert.Collection(
                            newNode.Parameters,
                            z => Assert.Same(NthValueChild(y, 0), z),
                            z => Assert.Same(NthValueChild(y, 1), z));
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
