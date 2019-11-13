using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using System.Linq;
using Xunit;

namespace ILusion.Tests
{
    public class ActionCallTests : TestBase
    {
        [Fact]
        public void CallStaticParameterlessMethod()
        {
            var sampleMethod = GetSampleMethod(nameof(ActionCallSamples), nameof(CallStaticParameterlessMethod));
            var illusion = MethodBodyIllusion.FromMethodDefinition(sampleMethod);

            Assert.Collection(
                illusion.Statements.Where(x => !typeof(NoOperationNode).IsInstanceOfType(x)),
                x =>
                {
                    Assert.Empty(x.Children);
                    var actionCallNode = Assert.IsType<ActionCallNode>(x);
                    Assert.NotNull(actionCallNode.Method);
                    Assert.Equal("StaticParameterlessMethod", actionCallNode.Method.Name);
                    Assert.Null(actionCallNode.Instance);
                    Assert.Empty(actionCallNode.Parameters);
                    Assert.False(actionCallNode.IsBaseCall);
                },
                x =>
                {
                    Assert.Empty(x.Children);
                    var returnNode = Assert.IsType<ReturnNode>(x);
                    Assert.Null(returnNode.ReturnValue);
                });

            ValidateEmission(sampleMethod, illusion);
        }
    }
}
