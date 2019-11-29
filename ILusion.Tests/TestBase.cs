using ILusion.Methods;
using ILusion.Methods.LogicTrees;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Linq;
using System.Text.RegularExpressions;
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
            return _sampleAssembly.MainModule.Types.First(x => Regex.Match(x.Name, "(^[a-zA-Z0-9_]+).*").Groups[1].Value == className).Methods.First(x => x.Name == methodName);
        }

        protected void EmitAndValidateUnchanged(MethodDefinition method, SyntaxTree syntaxTree)
        {
            var oldInstructions = method.Body.Instructions.ToArray();
            syntaxTree.AppyTo(method);
            var newInstructions = method.Body.Instructions;

            Assert.Equal(oldInstructions.Length, newInstructions.Count);
            
            for (var i = 0; i < oldInstructions.Length; i++)
            {
                AssertInstructions(oldInstructions[i], newInstructions[i]);
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

        protected ValueNode NthValueChild(LogicNode node, int index)
        {
            return node.Children.OfType<ValueNode>().ElementAt(index);
        }

        private static void AssertInstructions(Instruction expected, Instruction actual)
        {
            Assert.Equal(expected.OpCode, actual.OpCode);

            if (expected.Operand is Instruction expectedInstruction && actual.Operand is Instruction actualInstruction)
            {
                AssertInstructions(expectedInstruction, actualInstruction);
            }
            else
            {
                Assert.Equal(expected.Operand?.ToString(), actual.Operand?.ToString());
            }
        }
    }
}
