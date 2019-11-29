using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class InitializeTests : TestBase
    {
        [Fact]
        public void Variable_Default()
        {
            var sampleMethod = GetSampleMethod(nameof(InitializeSamples), nameof(InitializeSamples.Variable_Default));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y => CheckNode<VariableReferenceNode>(y));

                    Assert.Same(NthValueChild(initialize, 0), initialize.Target);
                    Assert.Null(initialize.Constructor);
                    Assert.Empty(initialize.Parameters);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Variable_NewStruct()
        {
            var sampleMethod = GetSampleMethod(nameof(InitializeSamples), nameof(InitializeSamples.Variable_NewStruct));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y => CheckNode<VariableReferenceNode>(y));

                    Assert.Same(NthValueChild(initialize, 0), initialize.Target);
                    Assert.Null(initialize.Constructor);
                    Assert.Empty(initialize.Parameters);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Parameter_Default()
        {
            var sampleMethod = GetSampleMethod(nameof(InitializeSamples), nameof(InitializeSamples.Parameter_Default));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y => CheckNode<ParameterReferenceNode>(y));

                    Assert.Same(NthValueChild(initialize, 0), initialize.Target);
                    Assert.Null(initialize.Constructor);
                    Assert.Empty(initialize.Parameters);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Parameter_NewStruct()
        {
            var sampleMethod = GetSampleMethod(nameof(InitializeSamples), nameof(InitializeSamples.Parameter_NewStruct));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y => CheckNode<ParameterReferenceNode>(y));

                    Assert.Same(NthValueChild(initialize, 0), initialize.Target);
                    Assert.Null(initialize.Constructor);
                    Assert.Empty(initialize.Parameters);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void RefParameter_Default()
        {
            var sampleMethod = GetSampleMethod(nameof(InitializeSamples), nameof(InitializeSamples.RefParameter_Default));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y => CheckNode<ParameterReferenceNode>(y));

                    Assert.Same(NthValueChild(initialize, 0), initialize.Target);
                    Assert.Null(initialize.Constructor);
                    Assert.Empty(initialize.Parameters);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void RefParameter_NewStruct()
        {
            var sampleMethod = GetSampleMethod(nameof(InitializeSamples), nameof(InitializeSamples.RefParameter_NewStruct));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y => CheckNode<ParameterReferenceNode>(y));

                    Assert.Same(NthValueChild(initialize, 0), initialize.Target);
                    Assert.Null(initialize.Constructor);
                    Assert.Empty(initialize.Parameters);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructGeneric_Default()
        {
            var sampleMethod = GetSampleMethod(nameof(InitializeSamples), nameof(InitializeSamples.StructGeneric_Default));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y => CheckNode<VariableReferenceNode>(y));

                    Assert.Same(NthValueChild(initialize, 0), initialize.Target);
                    Assert.Null(initialize.Constructor);
                    Assert.Empty(initialize.Parameters);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructGeneric_NewStruct()
        {
            var sampleMethod = GetSampleMethod(nameof(InitializeSamples), nameof(InitializeSamples.StructGeneric_Default));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y => CheckNode<VariableReferenceNode>(y));

                    Assert.Same(NthValueChild(initialize, 0), initialize.Target);
                    Assert.Null(initialize.Constructor);
                    Assert.Empty(initialize.Parameters);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void WithConstructor()
        {
            var sampleMethod = GetSampleMethod(nameof(InitializeSamples), nameof(InitializeSamples.WithConstructor));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y => CheckNode<VariableReferenceNode>(y),
                            y => CheckNode<LiteralNode>(y),
                            y => CheckNode<LiteralNode>(y),
                            y => CheckNode<LiteralNode>(y));

                    Assert.Same(NthValueChild(initialize, 0), initialize.Target);
                    Assert.NotNull(initialize.Constructor);
                    Assert.Collection(
                        initialize.Parameters,
                        y => Assert.Same(NthValueChild(x, 1), y),
                        y => Assert.Same(NthValueChild(x, 2), y),
                        y => Assert.Same(NthValueChild(x, 3), y));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void NewStructToString()
        {
            var sampleMethod = GetSampleMethod(nameof(InitializeSamples), nameof(InitializeSamples.NewStructToString));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<NewNode>(y,
                        z => CheckNode<LiteralNode>(z),
                        z => CheckNode<LiteralNode>(z),
                        z => CheckNode<LiteralNode>(z))),
                x => CheckNode<DiscardNode>(x, y => CheckNode<FunctionCallNode>(y, z => CheckNode<VariableReferenceNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
