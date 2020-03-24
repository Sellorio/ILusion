using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class AddTests : TestBase
    {
        [Fact]
        public void AddInt8()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddInt8));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddUInt8()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddUInt8));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddInt16()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddInt16));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddUInt16()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddUInt16));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddInt32()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddInt32));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddUInt32()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddUInt32));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddInt64()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddInt64));
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
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddUInt64()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddUInt64));
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
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddFloat()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddFloat));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddDouble()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddDouble));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddDecimal()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddDecimal));
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
        public void AddInt8Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddInt8Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddUInt8Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddUInt8Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddInt16Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddInt16Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddUInt16Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddUInt16Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddInt32Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddInt32Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddUInt32Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddUInt32Checked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddInt64Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddInt64Checked));
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
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddUInt64Checked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddUInt64Checked));
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
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddFloatChecked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddFloatChecked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddDoubleChecked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddDoubleChecked));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<AddNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<VariableNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AddDecimalChecked()
        {
            var sampleMethod = GetSampleMethod(nameof(AddSamples), nameof(AddSamples.AddDecimalChecked));
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
