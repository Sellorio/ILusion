﻿using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal interface IEmitter
    {
        Type SupportedNode { get; }
        void Emit(Dictionary<Instruction, LogicNode> instructionToNodeMapping, MethodDefinition target, LogicNode node, VariableDefinition returnDefinition);
        void UpdateBranches(Dictionary<Instruction, LogicNode> instructionToNodeMapping, MethodDefinition method, LogicNode node, VariableDefinition returnDefinition);
    }
}
