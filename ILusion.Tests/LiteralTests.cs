using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class LiteralTests : TestBase
    {
        [Fact]
        public void Int_Minus1()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_Minus1));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(-1, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_0()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_0));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(0, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_1()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_1));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(1, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_2()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_2));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(2, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_3()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_3));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(3, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_4()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_4));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(4, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_5()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_5));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(5, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_6()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_6));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(6, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_7()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_7));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(7, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_8()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_8));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(8, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_Small()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_Small));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(9, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_LargePositive()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_LargePositive));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(129, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_VeryLargePositive()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_VeryLargePositive));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(int.MaxValue, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_LargeNegative()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_LargeNegative));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(-129, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Int_VeryLargeNegative()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Int_VeryLargeNegative));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(int.MinValue, literalNode.Value);
                        Assert.Equal("System.Int32", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Long()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Long));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(1234567891011, literalNode.Value);
                        Assert.Equal("System.Int64", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Float()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Float));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(12.3f, literalNode.Value);
                        Assert.Equal("System.Single", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Double()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Double));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Equal(12.3, literalNode.Value);
                        Assert.Equal("System.Double", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        // uses new Decimal(int,int,int,bool,byte) to construct decimals
        [Fact]
        public void Decimal()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Decimal));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<InitializeNode>(
                        x,
                        y => CheckNode<VariableReferenceNode>(y),
                        y => CheckNode<LiteralNode>(y),
                        y => CheckNode<LiteralNode>(y),
                        y => CheckNode<LiteralNode>(y),
                        y => CheckNode<LiteralNode>(y),
                        y => CheckNode<LiteralNode>(y));
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Null()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Null));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Null(literalNode.Value);
                        Assert.Equal("System.Object", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void DefaultObject()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.DefaultObject));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Null(literalNode.Value);
                        Assert.Equal("System.Object", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void DefaultString()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.DefaultString));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.Null(literalNode.Value);
                        Assert.Equal("System.Object", literalNode.GetValueType()?.FullName);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_InVariableAssignment_True()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_InVariableAssignment_True));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.IsType<bool>(literalNode.Value);
                        Assert.True((bool)literalNode.Value);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_InVariableAssignment_False()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_InVariableAssignment_False));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.IsType<bool>(literalNode.Value);
                        Assert.False((bool)literalNode.Value);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_ToString_True()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_ToString_True));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.IsType<bool>(literalNode.Value);
                        Assert.True((bool)literalNode.Value);
                    });
                },
                x =>
                {
                    CheckNode<DiscardNode>(x, y =>
                    {
                        CheckNode<FunctionCallNode>(y, z =>
                        {
                            CheckNode<VariableReferenceNode>(z);
                        });
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_ToString_False()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_ToString_False));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.IsType<bool>(literalNode.Value);
                        Assert.False((bool)literalNode.Value);
                    });
                },
                x =>
                {
                    CheckNode<DiscardNode>(x, y =>
                    {
                        CheckNode<FunctionCallNode>(y, z =>
                        {
                            CheckNode<VariableReferenceNode>(z);
                        });
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_AsParameter_True()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_AsParameter_True));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<ActionCallNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.IsType<bool>(literalNode.Value);
                        Assert.True((bool)literalNode.Value);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_AsParameter_False()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_AsParameter_False));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<ActionCallNode>(x, y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.IsType<bool>(literalNode.Value);
                        Assert.False((bool)literalNode.Value);
                    });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_AsReturn_True()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_AsReturn_True));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y =>
                {
                    var literalNode = CheckNode<LiteralNode>(y);
                    Assert.IsType<bool>(literalNode.Value);
                    Assert.True((bool)literalNode.Value);
                }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_AsReturn_False()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_AsReturn_False));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y =>
                {
                    var literalNode = CheckNode<LiteralNode>(y);
                    Assert.IsType<bool>(literalNode.Value);
                    Assert.False((bool)literalNode.Value);
                }),
                x => CheckNode<GoToNode>(x),
                x => CheckNode<ReturnNode>(x, y => CheckNode<VariableNode>(y)));

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_SetArrayElement_True()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_SetArrayElement_True));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ArrayElementAssignmentNode>(x,
                    y => CheckNode<ParameterNode>(y),
                    y => CheckNode<LiteralNode>(y),
                    y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.IsType<bool>(literalNode.Value);
                        Assert.True((bool)literalNode.Value);
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_SetArrayElement_False()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_SetArrayElement_False));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<ArrayElementAssignmentNode>(x,
                    y => CheckNode<ParameterNode>(y),
                    y => CheckNode<LiteralNode>(y),
                    y =>
                    {
                        var literalNode = CheckNode<LiteralNode>(y);
                        Assert.IsType<bool>(literalNode.Value);
                        Assert.False((bool)literalNode.Value);
                    }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_Boxed_True()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_Boxed_True));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<CastNode>(y, z =>
                {
                    var literalNode = CheckNode<LiteralNode>(z);
                    Assert.IsType<bool>(literalNode.Value);
                    Assert.True((bool)literalNode.Value);
                })),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_Boxed_False()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_Boxed_False));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<CastNode>(y, z =>
                {
                    var literalNode = CheckNode<LiteralNode>(z);
                    Assert.IsType<bool>(literalNode.Value);
                    Assert.False((bool)literalNode.Value);
                })),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_AsConstructorParameter_True()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_AsConstructorParameter_True));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<NewNode>(y,
                        z => CheckNode<LiteralNode>(z),
                        z => CheckNode<LiteralNode>(z),
                        z => CheckNode<LiteralNode>(z),
                        z =>
                        {
                            var literalNode = CheckNode<LiteralNode>(z);
                            Assert.IsType<bool>(literalNode.Value);
                            Assert.True((bool)literalNode.Value);
                        },
                        z => CheckNode<LiteralNode>(z))),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_AsConstructorParameter_False()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_AsConstructorParameter_False));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<DiscardNode>(x,
                    y => CheckNode<NewNode>(y,
                        z => CheckNode<LiteralNode>(z),
                        z => CheckNode<LiteralNode>(z),
                        z => CheckNode<LiteralNode>(z),
                        z =>
                        {
                            var literalNode = CheckNode<LiteralNode>(z);
                            Assert.IsType<bool>(literalNode.Value);
                            Assert.False((bool)literalNode.Value);
                        },
                        z => CheckNode<LiteralNode>(z))),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        [Fact]
        public void Boolean_DefaultAssignment()
        {
            var sampleMethod = GetSampleMethod(nameof(LiteralSamples), nameof(LiteralSamples.Boolean_DefaultAssignment));
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y =>
                {
                    var literalNode = CheckNode<LiteralNode>(y);
                    Assert.IsType<bool>(literalNode.Value);
                    Assert.False((bool)literalNode.Value);
                }),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
