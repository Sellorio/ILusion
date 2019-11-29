using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class FieldReferenceTests : TestBase
    {
        [Fact]
        public void InitializeInstance()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldReferenceSamples<string, string, int>), nameof(FieldReferenceSamples<string, string, int>.InitializeInstance));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y =>
                            {
                                var fieldReference =
                                    CheckNode<FieldReferenceNode>(
                                        y,
                                        z => CheckNode<ThisNode>(z));

                                Assert.Same(NthValueChild(y, 0), fieldReference.Instance);
                                Assert.Equal("_instance", fieldReference.Field.Name);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void InitializeStatic()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldReferenceSamples<string, string, int>), nameof(FieldReferenceSamples<string, string, int>.InitializeStatic));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var initialize =
                        CheckNode<InitializeNode>(
                            x,
                            y =>
                            {
                                var fieldReference = CheckNode<FieldReferenceNode>(y);
                                Assert.Null(fieldReference.Instance);
                                Assert.Equal("_static", fieldReference.Field.Name);
                            });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructToString()
        {
            var sampleMethod = GetSampleMethod(nameof(FieldReferenceSamples<string, string, int>), nameof(FieldReferenceSamples<string, string, int>.StructToString));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<DiscardNode>(
                        x,
                        y =>
                        {
                            CheckNode<FunctionCallNode>(
                                y,
                                z =>
                                {
                                    var fieldReference = CheckNode<FieldReferenceNode>(z);
                                    Assert.Null(fieldReference.Instance);
                                    Assert.Equal("_static", fieldReference.Field.Name);
                                });
                        });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
