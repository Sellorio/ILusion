using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class LessThanTests : TestBase
    {
        [Fact]
        public void Int8()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.Int8));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void UInt8()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.UInt8));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int16()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.Int16));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void UInt16()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.UInt16));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int32()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.Int32));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void UInt32()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.UInt32));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int64()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.Int64));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<CastNode>(y,
                        z => CheckNode<LiteralNode>(z))),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<CastNode>(y,
                        z => CheckNode<LiteralNode>(z))),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void UInt64()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.UInt64));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<CastNode>(y,
                        z => CheckNode<LiteralNode>(z))),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<CastNode>(y,
                        z => CheckNode<LiteralNode>(z))),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Float()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.Float));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Double()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.Double));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Decimal()
        {
            var sampleMethod = GetSampleMethod(nameof(LessThanSamples), nameof(LessThanSamples.Decimal));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<InitializeNode>(x,
                    y => CheckNode<VariableReferenceNode>(y),
                    y => CheckNode<LiteralNode>(y),
                    y => CheckNode<LiteralNode>(y),
                    y => CheckNode<LiteralNode>(y),
                    y => CheckNode<LiteralNode>(y),
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<InitializeNode>(x,
                    y => CheckNode<VariableReferenceNode>(y),
                    y => CheckNode<LiteralNode>(y),
                    y => CheckNode<LiteralNode>(y),
                    y => CheckNode<LiteralNode>(y),
                    y => CheckNode<LiteralNode>(y),
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<FunctionCallNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));
            
            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
