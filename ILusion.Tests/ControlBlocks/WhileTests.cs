﻿using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Methods.LogicTrees.Nodes.ControlBlocks;
using ILusion.Tests.Sample.ControlBlocks;
using Xunit;

namespace ILusion.Tests.ControlBlocks
{
    public class WhileTests : TestBase
    {
        [Fact]
        public void Simple()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.Simple));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Infinite()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.Infinite));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<LiteralNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AlwaysBreakAtEnd()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.AlwaysBreakAtEnd));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y),
                        y => CheckNode<BreakNode>(y));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AlwaysContinueAtEnd()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.AlwaysContinueAtEnd));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y),
                        y => CheckNode<ContinueNode>(y));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void AlwaysReturnAtEnd()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.AlwaysReturnAtEnd));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y),
                        y => CheckNode<BreakNode>(y));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void BreakFromIf()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.BreakFromIf));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));
                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<BreakNode>(z));
                        });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void BreakFromIfWithElse()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.BreakFromIfWithElse));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));
                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<BreakNode>(z));
                            Assert.Null(ifNode.FalseStatements);
                        },
                        y => CheckNode<ActionCallNode>(y));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ContinueFromIf()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.ContinueFromIf));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));
                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<ContinueNode>(z));
                            Assert.Null(ifNode.FalseStatements);
                        });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ContinueFromIfWithElse()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.ContinueFromIfWithElse));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));
                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<ContinueNode>(z));
                            Assert.Null(ifNode.FalseStatements);
                        },
                        y => CheckNode<ActionCallNode>(y));
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void WithIfElse()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.WithIfElse));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));
                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<ActionCallNode>(z));
                            CheckStatements(
                                ifNode.FalseStatements,
                                z => CheckNode<ActionCallNode>(z));
                        });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void BreakFromIfInIf()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.BreakFromIfInIf));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));
                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<ActionCallNode>(z),
                                z =>
                                {
                                    var childIfNode = CheckNode<IfNode>(z, a => CheckNode<ParameterNode>(a));
                                    CheckStatements(
                                        childIfNode.TrueStatements,
                                        a => CheckNode<BreakNode>(a));
                                    Assert.Null(childIfNode.FalseStatements);
                                });
                        });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void ContinueFromIfInIf()
        {
            var sampleMethod = GetSampleMethod(nameof(WhileSamples), nameof(WhileSamples.ContinueFromIfInIf));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    var whileNode =
                        CheckNode<WhileNode>(x,
                            y => CheckNode<ParameterNode>(y));

                    Assert.Same(NthValueChild(x, 0), whileNode.Condition);
                    CheckStatements(
                        whileNode.Statements,
                        y => CheckNode<ActionCallNode>(y),
                        y =>
                        {
                            var ifNode = CheckNode<IfNode>(y, z => CheckNode<ParameterNode>(z));
                            CheckStatements(
                                ifNode.TrueStatements,
                                z => CheckNode<ActionCallNode>(z),
                                z =>
                                {
                                    var childIfNode = CheckNode<IfNode>(z, a => CheckNode<ParameterNode>(a));
                                    CheckStatements(
                                        childIfNode.TrueStatements,
                                        a => CheckNode<ContinueNode>(a));
                                    Assert.Null(childIfNode.FalseStatements);
                                });
                        });
                });

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
