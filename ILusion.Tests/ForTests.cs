using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class ForTests : TestBase
    {
        [Fact]
        public void Simple()
        {
            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.Simple));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var forNode = CheckNode<ForNode>(x);

                    var forLoopNode =
                        CheckNode<ForLoopNode>(forNode.Loop,
                            y => CheckNode<LessThanNode>(y,
                                z => CheckNode<VariableNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forNode.InitialAssignments,
                        y => CheckNode<VariableAssignmentNode>(y,
                            z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forLoopNode.Statements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<VariableNode>(z)));

                    CheckNode<VariableAssignmentNode>(
                        forLoopNode.IteratorAssignment,
                        x => CheckNode<AddNode>(x,
                            y => CheckNode<VariableNode>(y),
                            y => CheckNode<LiteralNode>(y)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void WithoutVariableDeclaration()
        {
            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.WithoutVariableDeclaration));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var forNode = CheckNode<ForNode>(x);

                    var forLoopNode =
                        CheckNode<ForLoopNode>(forNode.Loop,
                            y => CheckNode<LessThanNode>(y,
                                z => CheckNode<ParameterNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    CheckStatements(forNode.InitialAssignments);

                    CheckStatements(
                        forLoopNode.Statements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<ParameterNode>(z)));

                    CheckNode<ParameterAssignmentNode>(
                        forLoopNode.IteratorAssignment,
                        x => CheckNode<AddNode>(x,
                            y => CheckNode<ParameterNode>(y),
                            y => CheckNode<LiteralNode>(y)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ComplexIterator()
        {
            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.ComplexIterator));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var forNode = CheckNode<ForNode>(x);

                    var forLoopNode =
                        CheckNode<ForLoopNode>(forNode.Loop,
                            y => CheckNode<LessThanNode>(y,
                                z => CheckNode<PropertyNode>(z,
                                    a => CheckNode<VariableNode>(a)),
                                z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forNode.InitialAssignments,
                        x => CheckNode<VariableAssignmentNode>(x,
                            y => CheckNode<LiteralNode>(y)));

                    CheckStatements(
                        forLoopNode.Statements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<VariableNode>(z)));

                    CheckNode<VariableAssignmentNode>(
                        forLoopNode.IteratorAssignment,
                        x => CheckNode<FunctionCallNode>(x,
                            y => CheckNode<VariableNode>(y)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AlwaysBreakAtEnd()
        {
            // C# compiler optimized out the iterator so this is correctly identified as a while loop

            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.AlwaysBreakAtEnd));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<WhileNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<LiteralNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AlwaysContinueAtEnd()
        {
            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.AlwaysContinueAtEnd));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var forNode = CheckNode<ForNode>(x);

                    var forLoopNode =
                        CheckNode<ForLoopNode>(forNode.Loop,
                            y => CheckNode<LessThanNode>(y,
                                z => CheckNode<VariableNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forNode.InitialAssignments,
                        y => CheckNode<VariableAssignmentNode>(y,
                            z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forLoopNode.Statements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<VariableNode>(z)),
                        y => CheckNode<ContinueNode>(y));

                    CheckNode<VariableAssignmentNode>(
                        forLoopNode.IteratorAssignment,
                        y => CheckNode<AddNode>(y,
                            z => CheckNode<VariableNode>(z),
                            z => CheckNode<LiteralNode>(z)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AlwaysReturnAtEnd()
        {
            // C# compiler optimized out the iterator so this is correctly identified as a while loop

            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.AlwaysReturnAtEnd));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x,
                    y => CheckNode<LiteralNode>(y)),
                x => CheckNode<WhileNode>(x,
                    y => CheckNode<LessThanNode>(y,
                        z => CheckNode<VariableNode>(z),
                        z => CheckNode<LiteralNode>(z))));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void BreakFromIf()
        {
            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.BreakFromIf));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var forNode = CheckNode<ForNode>(x);

                    var forLoopNode =
                        CheckNode<ForLoopNode>(forNode.Loop,
                            y => CheckNode<LessThanNode>(y,
                                z => CheckNode<VariableNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forNode.InitialAssignments,
                        y => CheckNode<VariableAssignmentNode>(y,
                            z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forLoopNode.Statements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<VariableNode>(z)),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));

                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<BreakNode>(z));
                        });

                    CheckNode<VariableAssignmentNode>(
                        forLoopNode.IteratorAssignment,
                        y => CheckNode<AddNode>(y,
                            z => CheckNode<VariableNode>(z),
                            z => CheckNode<LiteralNode>(z)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void BreakFromIfWithElse()
        {
            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.BreakFromIfWithElse));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var forNode = CheckNode<ForNode>(x);

                    var forLoopNode =
                        CheckNode<ForLoopNode>(forNode.Loop,
                            y => CheckNode<LessThanNode>(y,
                                z => CheckNode<VariableNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forNode.InitialAssignments,
                        y => CheckNode<VariableAssignmentNode>(y,
                            z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forLoopNode.Statements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<VariableNode>(z)),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));

                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<BreakNode>(z));

                            Assert.Null(ifNode.FalseStatements);
                        },
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<VariableNode>(z)));

                    CheckNode<VariableAssignmentNode>(
                        forLoopNode.IteratorAssignment,
                        y => CheckNode<AddNode>(y,
                            z => CheckNode<VariableNode>(z),
                            z => CheckNode<LiteralNode>(z)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ContinueFromIf()
        {
            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.ContinueFromIf));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var forNode = CheckNode<ForNode>(x);

                    var forLoopNode =
                        CheckNode<ForLoopNode>(forNode.Loop,
                            y => CheckNode<LessThanNode>(y,
                                z => CheckNode<VariableNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forNode.InitialAssignments,
                        y => CheckNode<VariableAssignmentNode>(y,
                            z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forLoopNode.Statements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<VariableNode>(z)),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));

                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<ContinueNode>(z));
                        });

                    CheckNode<VariableAssignmentNode>(
                        forLoopNode.IteratorAssignment,
                        y => CheckNode<AddNode>(y,
                            z => CheckNode<VariableNode>(z),
                            z => CheckNode<LiteralNode>(z)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ContinueFromIfWithElse()
        {
            var sampleMethod = GetSampleMethod(nameof(ForSamples), nameof(ForSamples.ContinueFromIfWithElse));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var forNode = CheckNode<ForNode>(x);

                    var forLoopNode =
                        CheckNode<ForLoopNode>(forNode.Loop,
                            y => CheckNode<LessThanNode>(y,
                                z => CheckNode<VariableNode>(z),
                                z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forNode.InitialAssignments,
                        y => CheckNode<VariableAssignmentNode>(y,
                            z => CheckNode<LiteralNode>(z)));

                    CheckStatements(
                        forLoopNode.Statements,
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<VariableNode>(z)),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));

                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<ContinueNode>(z));

                            Assert.Null(ifNode.FalseStatements);
                        },
                        y => CheckNode<ActionCallNode>(y,
                            z => CheckNode<VariableNode>(z)));

                    CheckNode<VariableAssignmentNode>(
                        forLoopNode.IteratorAssignment,
                        y => CheckNode<AddNode>(y,
                            z => CheckNode<VariableNode>(z),
                            z => CheckNode<LiteralNode>(z)));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
