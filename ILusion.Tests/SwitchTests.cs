using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
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
