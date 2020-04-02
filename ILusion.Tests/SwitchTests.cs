using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Mono.Cecil;
using Xunit;

namespace ILusion.Tests
{
    public class SwitchTests : TestBase
    {
        [Fact]
        public void OneSwitchClump()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClump));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void OneSwitchClumpPositiveOffset()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpPositiveOffset));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(3, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(4, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(5, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void OneSwitchClumpNegativeOffset()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpNegativeOffset));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(-2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(-1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void OneSwitchClumpWithDefault()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithDefault));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.IsType<SwitchDefaultCase>(y);
                            Assert.Equal(SwitchDefaultCase.CaseValue, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("DefaultBody", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void OneSwitchClumpWithReturns()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithReturns));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ReturnNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ReturnNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ReturnNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }));
                        });
                },
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var literal = CheckNode<LiteralNode>(y);
                        Assert.Equal("Fallback", literal.Value);
                    }));
        }

        [Fact]
        public void OneSwitchClumpWithReturnsAndDefault()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithReturnsAndDefault));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ReturnNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ReturnNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ReturnNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }));
                        });
                },
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var literal = CheckNode<LiteralNode>(y);
                        Assert.Equal("Default", literal.Value);
                    }));
        }

        [Fact]
        public void OneSwitchClumpWithReturnsAndBreaks()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithReturnsAndBreaks));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ReturnNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ReturnNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }));
                        });
                },
                x => CheckNode<ReturnNode>(x,
                    y =>
                    {
                        var literal = CheckNode<LiteralNode>(y);
                        Assert.Equal("Fallback", literal.Value);
                    }));
        }

        [Fact]
        public void OneSwitchClumpWithGoToCase()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithGoToCase));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }),
                                z =>
                                {
                                    var goToCase = CheckNode<GoToCaseNode>(z);
                                    Assert.Equal(2, goToCase.CaseValue);
                                });
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void OneSwitchClumpWithGoToCurrentCase()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithGoToCurrentCase));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }),
                                z =>
                                {
                                    var goToCase = CheckNode<GoToCaseNode>(z);
                                    Assert.Equal(1, goToCase.CaseValue);
                                });
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void OneSwitchClumpWithGoToDefault()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithGoToDefault));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }),
                                z => CheckNode<GoToDefaultNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.IsType<SwitchDefaultCase>(y);
                            Assert.Equal(SwitchDefaultCase.CaseValue, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Default", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void OneSwitchClumpWithGoToDefaultInDefault()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithGoToDefaultInDefault));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.IsType<SwitchDefaultCase>(y);
                            Assert.Equal(SwitchDefaultCase.CaseValue, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Default", literal.Value);
                                    }),
                                z => CheckNode<GoToDefaultNode>(z));
                        });
                });
        }

        [Fact]
        public void OneSwitchClumpWithGoTos()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithGoTos));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }),
                                z => CheckNode<GoToNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }),
                                z => CheckNode<GoToNode>(z));
                        },
                        y =>
                        {
                            Assert.IsType<SwitchDefaultCase>(y);
                            Assert.Equal(SwitchDefaultCase.CaseValue, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("DefaultBody", literal.Value);
                                    }),
                                z => CheckNode<GoToNode>(z));
                        });
                },
                x => CheckNode<ActionCallNode>(x, y => CheckNode<LiteralNode>(y)),
                x => CheckNode<ActionCallNode>(x, y => CheckNode<LiteralNode>(y)),
                x => CheckNode<ActionCallNode>(x, y => CheckNode<LiteralNode>(y)));
        }

        [Fact]
        public void OneSwitchClumpWithGap()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithGap));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(-2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(-1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void OneSwitchClumpWithGapAndDefault()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneSwitchClumpWithGapAndDefault));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(-2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(-1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(SwitchDefaultCase.CaseValue, y.Value);
                            Assert.IsType<SwitchDefaultCase>(y);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("DefaultBody", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                },
                x => CheckNode<ActionCallNode>(x, y => CheckNode<LiteralNode>(y)));
        }
        [Fact]
        public void FallthroughFromCaseToCase()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.FallthroughFromCaseToCase));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            var fallthrough = Assert.IsType<SwitchFallthroughCase>(y);
                            Assert.Same(switchNode.Cases[3], fallthrough.Target);
                            Assert.Empty(fallthrough.Statements);
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(3, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("3", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void FallthroughFromCaseToDefault()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.FallthroughFromCaseToDefault));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.IsType<SwitchDefaultCase>(y);
                            Assert.Equal(SwitchDefaultCase.CaseValue, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("DefaultBody", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                },
                x => CheckNode<ActionCallNode>(x, y => CheckNode<LiteralNode>(y)));
        }

        [Fact]
        public void TwoSwitchClumps()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.TwoSwitchClumps));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(-3, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-3", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(-2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(-1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(6, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("6", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(7, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("7", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(8, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("8", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void TwoSwitchClumpsWithDefault()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.TwoSwitchClumpsWithDefault));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(-3, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-3", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(-2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(-1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(6, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("6", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(7, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("7", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(8, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("8", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(SwitchDefaultCase.CaseValue, y.Value);
                            Assert.IsType<SwitchDefaultCase>(y);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("DefaultBody", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                },
                x => CheckNode<ActionCallNode>(x, y => CheckNode<LiteralNode>(y)));
        }

        [Fact]
        public void EnumSwitchClump()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.EnumSwitchClump));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            var enumMember = Assert.IsType<FieldDefinition>(y.Value);
                            Assert.Equal(0, enumMember.Constant);
                            Assert.Equal("One", enumMember.Name);

                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Luv", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            var enumMember = Assert.IsType<FieldDefinition>(y.Value);
                            Assert.Equal(1, enumMember.Constant);
                            Assert.Equal("Two", enumMember.Name);

                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("One", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            var enumMember = Assert.IsType<FieldDefinition>(y.Value);
                            Assert.Equal(2, enumMember.Constant);
                            Assert.Equal("Three", enumMember.Name);

                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Two", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void OneIntegerBranchClump()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.OneIntegerBranchClump));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void IntegerBranchClumpsWithZeroClump()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.IntegerBranchClumpsWithZeroClump));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void MultipleIntegerBranchClumps()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.MultipleIntegerBranchClumps));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(6, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("6", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(7, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("7", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void MultipleIntegerBranchClumpsWithDefault()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.MultipleIntegerBranchClumpsWithDefault));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(6, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("6", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(7, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("7", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(SwitchDefaultCase.CaseValue, y.Value);
                            Assert.IsType<SwitchDefaultCase>(y);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Default", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void MultipleEnumBranchClumps()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.MultipleEnumBranchClumps));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            var enumMember = Assert.IsType<FieldDefinition>(y.Value);
                            Assert.Equal(0, enumMember.Constant);
                            Assert.Equal("One", enumMember.Name);

                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            var enumMember = Assert.IsType<FieldDefinition>(y.Value);
                            Assert.Equal(1, enumMember.Constant);
                            Assert.Equal("Two", enumMember.Name);

                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            var enumMember = Assert.IsType<FieldDefinition>(y.Value);
                            Assert.Equal(6, enumMember.Constant);
                            Assert.Equal("Seven", enumMember.Name);

                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("6", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            var enumMember = Assert.IsType<FieldDefinition>(y.Value);
                            Assert.Equal(7, enumMember.Constant);
                            Assert.Equal("Eight", enumMember.Name);

                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("7", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void FloatBranchClump()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.FloatBranchClump));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0.0f, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0.0f", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1.0f, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1.0f", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2.0f, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2.0f", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void DoubleBranchClump()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.DoubleBranchClump));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0.0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0.0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1.0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1.0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2.0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2.0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void DoubleBranchClumpWithFloatCases()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.DoubleBranchClumpWithFloatCases));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0.0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0.0f", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1.0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1.0f", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2.0, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2.0f", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void FloatBranchClumpWithFallthrough()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.FloatBranchClumpWithFallthrough));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(0.0f, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0.0f", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(2.0f, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2.0f", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1.0f, y.Value);
                            var fallthrough = Assert.IsType<SwitchFallthroughCase>(y);
                            Assert.Same(switchNode.Cases[3], fallthrough.Target);
                            Assert.Empty(fallthrough.Statements);
                        },
                        y =>
                        {
                            Assert.Equal(3.0f, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("3.0f", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void DecimalBranchClump()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.DecimalBranchClump));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal(-2M, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(-1.1M, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("-1.1M", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(0.0M, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0.0M", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(1.1M, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1.1M", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(3M, y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("3", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void StringBranchClump()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.StringBranchClump));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal("Zero", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal("One", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal("Two", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void StringBranchClumpWithDefault()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.StringBranchClumpWithDefault));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Equal("Zero", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal("One", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal("Two", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal(SwitchDefaultCase.CaseValue, y.Value);
                            Assert.IsType<SwitchDefaultCase>(y);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("Default", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void StringBranchClumpWithNull()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.StringBranchClumpWithNull));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Null(y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("null", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal("Zero", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal("One", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal("Two", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }

        [Fact]
        public void StringBranchClumpWithNullFallthrough()
        {
            var sampleMethod = GetSampleMethod(nameof(SwitchSamples), nameof(SwitchSamples.StringBranchClumpWithNullFallthrough));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                x =>
                {
                    var switchNode = CheckNode<SwitchNode>(x, y => CheckNode<VariableNode>(y));

                    Assert.Collection(
                        switchNode.Cases,
                        y =>
                        {
                            Assert.Null(y.Value);
                            var fallthrough = Assert.IsType<SwitchFallthroughCase>(y);
                            Assert.Same(switchNode.Cases[1], fallthrough.Target);
                            Assert.Empty(fallthrough.Statements);
                        },
                        y =>
                        {
                            Assert.Equal("Zero", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("0", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal("One", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("1", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        },
                        y =>
                        {
                            Assert.Equal("Two", y.Value);
                            CheckStatements(
                                y.Statements,
                                z => CheckNode<ActionCallNode>(z,
                                    a =>
                                    {
                                        var literal = CheckNode<LiteralNode>(a);
                                        Assert.Equal("2", literal.Value);
                                    }),
                                z => CheckNode<BreakNode>(z));
                        });
                });
        }
    }

    // Uses switch when:
    //  - > 2 cases (exc. default)
    //  - Values are integer or enum
    //  - Split by all gaps, any gaps that can be combined without hitting a 1:1 ratio of gap to non-gap are combined as a single switch.
    //    If a clump has 3+ options, it is a switch, otherwise it is a branch-set.
    //  - Uses brgt <max value of clump> to skip to the next clump.
    //  - Subtract is used to correct for value offsets just before swtch (change is not made for branch clumps)
    // Uses a grouped set of branches when:
    //  - < 3 cases 
    //  - String values (using br.true - branch when true)
    //  - Floating point values (using br.eq - branch when equal)
    //  - Decimal values (using br.true - branch when true)
    // Branch cases:
    //  - Numeric type
    //     * ldloc              a
    //     * ldc
    //     * beq
    //  - String/Decimal
    //     * ldloc              a
    //     * ldstr
    //     * call op_Equality
    //     * brtrue
    //  - Type (checking for class, with variable)
    //     * ldloc              a
    //     * isinst
    //     * stloc              b
    //     * ldloc              b
    //     * brtrue
    //  - Type (checking for struct, with variable)
    //     * ldloc              a
    //     * isinst
    //     * brfalse
    //     * ldloc              a
    //     * unbox.any
    //     * stloc              b
    //     * br
    //  - Type (without variable)
    //     * ldloc              a
    //     * isinst
    //     * brtrue
}
