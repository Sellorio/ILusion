using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ThisReferenceTests : TestBase
    {
        [Fact]
        public void ClassToOut()
        {
            var sampleMethod = GetSampleMethod(nameof(ThisReferenceClassSamples), nameof(ThisReferenceClassSamples.ClassToOut));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReferenceAssignmentNode>(x,
                    y => CheckNode<ParameterReferenceNode>(y),
                    y => CheckNode<ThisNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructToOut()
        {
            var sampleMethod = GetSampleMethod(nameof(ThisReferenceStructSamples), nameof(ThisReferenceStructSamples.StructToOut));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ReferenceAssignmentNode>(x,
                    y => CheckNode<ParameterReferenceNode>(y),
                    y => CheckNode<ThisNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructMethodCall()
        {
            var sampleMethod = GetSampleMethod(nameof(ThisReferenceStructSamples), nameof(ThisReferenceStructSamples.StructMethodCall));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<FunctionCallNode>(y,
                        z => CheckNode<ThisReferenceNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
