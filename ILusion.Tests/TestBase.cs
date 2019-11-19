using ILusion.Methods;
using ILusion.Methods.LogicTrees;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Mono.Cecil;
using System;
using System.Linq;
using Xunit;

// The collection object used by Mono.Cecil is not thread safe and triggers IndexOutOfRangeException at random.
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace ILusion.Tests
{
    public abstract class TestBase
    {
        private static readonly AssemblyDefinition _sampleAssembly = AssemblyDefinition.ReadAssembly(typeof(ActionCallSamples).Assembly.Location);

        protected MethodDefinition GetSampleMethod(string className, string methodName)
        {
            return _sampleAssembly.MainModule.Types.First(x => x.Name == className).Methods.First(x => x.Name == methodName);
        }

        protected void EmitAndValidateUnchanged(MethodDefinition method, SyntaxTree syntaxTree)
        {
            var oldInstructions = method.Body.Instructions.ToArray();
            syntaxTree.AppyTo(method);
            var newInstructions = method.Body.Instructions;

            Assert.Equal(oldInstructions.Length, newInstructions.Count);
            
            for (var i = 0; i < oldInstructions.Length; i++)
            {
                Assert.Equal(oldInstructions[i].OpCode, newInstructions[i].OpCode);
                Assert.Equal(oldInstructions[i].Operand?.ToString(), newInstructions[i].Operand?.ToString());
            }
        }

        protected void CheckStatements(SyntaxTree syntaxTree, params Action<LogicNode>[] checks)
        {
            Assert.Collection(syntaxTree.Statements.Where(x => !(x is NoOperationNode)), checks);
        }

        protected TNode CheckNode<TNode>(LogicNode node, params Action<LogicNode>[] childrenChecks)
        {
            var result = Assert.IsType<TNode>(node);
            Assert.NotNull(node.Children);
            Assert.Collection(node.Children.Where(x => !(x is NoOperationNode)), childrenChecks);
            return result;
        }

        protected Action<LogicNode> CheckReturn(Action<ValueNode> returnValueCheck = null)
        {
            return x =>
            {
                var returnNode =
                    returnValueCheck == null
                        ? CheckNode<ReturnNode>(x)
                        : CheckNode<ReturnNode>(x, y => returnValueCheck.Invoke(y as ValueNode));

                if (returnValueCheck == null)
                {
                    Assert.Null(returnNode.ReturnValue);
                }
                else
                {
                    Assert.Same(returnNode.Children.OfType<ValueNode>().First(), returnNode.ReturnValue);
                }
            };
        }

        protected ValueNode NthValueChild(LogicNode node, int index)
        {
            return node.Children.OfType<ValueNode>().ElementAt(index);
        }
    }
}
