using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class SubtractTests : TestBase
    {
        [Fact]
        public void SubtractInt8()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractInt8));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractUInt8()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractUInt8));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractInt16()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractInt16));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractUInt16()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractUInt16));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractInt32()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractInt32));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractUInt32()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractUInt32));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractInt64()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractInt64));
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
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractUInt64()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractUInt64));
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
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractFloat()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractFloat));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractDouble()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractDouble));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractDecimal()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractDecimal));
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

        [Fact]
        public void SubtractInt8Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractInt8Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractUInt8Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractUInt8Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractInt16Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractInt16Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractUInt16Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractUInt16Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractInt32Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractInt32Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractUInt32Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractUInt32Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractInt64Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractInt64Checked));
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
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractUInt64Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractUInt64Checked));
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
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractFloatChecked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractFloatChecked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractDoubleChecked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractDoubleChecked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<SubtractNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void SubtractDecimalChecked()
        {
            var sampleMethod = GetSampleMethod(nameof(SubtractSamples), nameof(SubtractSamples.SubtractDecimalChecked));
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
