using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ThisTests : TestBase
    {
        [Fact]
        public void ClassToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ThisClassSamples), nameof(ThisClassSamples.ClassToVariable));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<ThisNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ClassToParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(ThisClassSamples), nameof(ThisClassSamples.ClassToParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ActionCallNode>(x,
                    y => CheckNode<ThisNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructToVariable()
        {
            var sampleMethod = GetSampleMethod(nameof(ThisStructSamples), nameof(ThisStructSamples.StructToVariable));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<ThisNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void StructToParameter()
        {
            var sampleMethod = GetSampleMethod(nameof(ThisStructSamples), nameof(ThisStructSamples.StructToParameter));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ActionCallNode>(x,
                    y => CheckNode<ThisNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
