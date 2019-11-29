using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ReferenceAssignmentTests : TestBase
    {
        [Fact]
        public void Int8()
        {
            TestBody(nameof(ReferenceAssignmentSamples.Int8));
        }

        [Fact]
        public void UInt8()
        {
            TestBody(nameof(ReferenceAssignmentSamples.UInt8));
        }

        [Fact]
        public void Int16()
        {
            TestBody(nameof(ReferenceAssignmentSamples.Int16));
        }

        [Fact]
        public void UInt16()
        {
            TestBody(nameof(ReferenceAssignmentSamples.UInt16));
        }

        [Fact]
        public void Int32()
        {
            TestBody(nameof(ReferenceAssignmentSamples.Int32));
        }

        [Fact]
        public void UInt32()
        {
            TestBody(nameof(ReferenceAssignmentSamples.UInt32));
        }

        [Fact]
        public void Int64()
        {
            TestBody(nameof(ReferenceAssignmentSamples.Int64));
        }

        [Fact]
        public void UInt64()
        {
            TestBody(nameof(ReferenceAssignmentSamples.UInt64));
        }

        [Fact]
        public void Float()
        {
            TestBody(nameof(ReferenceAssignmentSamples.Float));
        }

        [Fact]
        public void Double()
        {
            TestBody(nameof(ReferenceAssignmentSamples.Double));
        }

        [Fact]
        public void Struct()
        {
            var sampleMethod = GetSampleMethod(nameof(ReferenceAssignmentSamples), nameof(ReferenceAssignmentSamples.Struct));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var referenceAssignment =
                        CheckNode<ReferenceAssignmentNode>(x,
                            y => CheckNode<ParameterReferenceNode>(y),
                            y => CheckNode<NewNode>(y,
                                z => CheckNode<LiteralNode>(z),
                                z => CheckNode<LiteralNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    Assert.Same(NthValueChild(x, 0), referenceAssignment.Reference);
                    Assert.Same(NthValueChild(x, 1), referenceAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Class()
        {
            TestBody(nameof(ReferenceAssignmentSamples.Class));
        }

        private void TestBody(string methodName)
        {
            var sampleMethod = GetSampleMethod(nameof(ReferenceAssignmentSamples), methodName);
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var referenceAssignment =
                        CheckNode<ReferenceAssignmentNode>(x,
                            y => CheckNode<ParameterReferenceNode>(y),
                            y => CheckNode<LiteralNode>(y));

                    Assert.Same(NthValueChild(x, 0), referenceAssignment.Reference);
                    Assert.Same(NthValueChild(x, 1), referenceAssignment.Value);
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
