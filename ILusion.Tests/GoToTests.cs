using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using System.Linq;
using Xunit;

namespace ILusion.Tests
{
    public class GoToTests : TestBase
    {
        [Fact]
        public void GoTo()
        {
            var sampleMethod = GetSampleMethod(nameof(GoToSamples), nameof(GoToSamples.GoTo));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var goTo = CheckNode<GoToNode>(x);
                    Assert.Same(syntaxTree.Statements.Last(), goTo.Target);
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
