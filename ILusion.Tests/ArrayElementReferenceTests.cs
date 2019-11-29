using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Mono.Cecil;
using Xunit;

namespace ILusion.Tests
{
    public class ArrayElementReferenceTests : TestBase
    {
        [Fact]
        public void FromVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementReferenceSamples), nameof(ArrayElementReferenceSamples.FromVariable));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialise =
                        CheckNode<InitializeNode>(
                            x,
                            y =>
                            {
                                var elementReference =
                                    CheckNode<ArrayElementReferenceNode>(
                                        y,
                                        z =>
                                        {
                                            var parameter = CheckNode<ParameterNode>(z);
                                            Assert.Equal(0, parameter.Parameter.Index);
                                        },
                                        z =>
                                        {
                                            var parameter = CheckNode<LiteralNode>(z);
                                            Assert.Equal(0, parameter.Value);
                                        });

                                Assert.Equal(NthValueChild(y, 0), elementReference.Array);
                                Assert.Equal(NthValueChild(y, 1), elementReference.Index);
                                var pointer = Assert.IsType<PointerType>(elementReference.GetValueType());
                                Assert.Equal("System.DateTime", pointer.ElementType.FullName);
                            });

                    Assert.Null(initialise.Constructor);
                    Assert.Empty(initialise.Parameters);
                    Assert.Same(NthValueChild(x, 0), initialise.Target);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void FromNew()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementReferenceSamples), nameof(ArrayElementReferenceSamples.FromNew));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialise =
                        CheckNode<InitializeNode>(
                            x,
                            y =>
                            {
                                var elementReference =
                                    CheckNode<ArrayElementReferenceNode>(
                                        y,
                                        z =>
                                        {
                                            var newNode =
                                                CheckNode<NewNode>(
                                                    z,
                                                    a => CheckNode<LiteralNode>(a));

                                            var arrayType = Assert.IsType<ArrayType>(newNode.Type);
                                            Assert.Equal("System.DateTime", arrayType.ElementType.FullName);
                                        },
                                        z =>
                                        {
                                            var parameter = CheckNode<LiteralNode>(z);
                                            Assert.Equal(0, parameter.Value);
                                        });

                                Assert.Equal(NthValueChild(y, 0), elementReference.Array);
                                Assert.Equal(NthValueChild(y, 1), elementReference.Index);
                                var pointer = Assert.IsType<PointerType>(elementReference.GetValueType());
                                Assert.Equal("System.DateTime", pointer.ElementType.FullName);
                            });

                    Assert.Null(initialise.Constructor);
                    Assert.Empty(initialise.Parameters);
                    Assert.Same(NthValueChild(x, 0), initialise.Target);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AsRefParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(ArrayElementReferenceSamples), nameof(ArrayElementReferenceSamples.AsRefParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var actionCall =
                        CheckNode<ActionCallNode>(
                            x,
                            y =>
                            {
                                var elementReference =
                                    CheckNode<ArrayElementReferenceNode>(
                                        y,
                                        z =>
                                        {
                                            var parameter = CheckNode<ParameterNode>(z);
                                            Assert.Equal(0, parameter.Parameter.Index);
                                        },
                                        z =>
                                        {
                                            var parameter = CheckNode<LiteralNode>(z);
                                            Assert.Equal(0, parameter.Value);
                                        });

                                Assert.Equal(NthValueChild(y, 0), elementReference.Array);
                                Assert.Equal(NthValueChild(y, 1), elementReference.Index);
                                var pointer = Assert.IsType<PointerType>(elementReference.GetValueType());
                                Assert.Equal("System.String", pointer.ElementType.FullName);
                            });

                    Assert.Equal("RefAction", actionCall.Method.Name);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
