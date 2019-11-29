using ILusion.Exceptions;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILusion.Methods.LogicTrees.Helpers
{
    internal static class VariableHelper
    {
        internal static VariableDefinition GetReturnVariable(MethodDefinition method)
        {
            if (method.ReturnType.FullName == typeof(void).FullName)
            {
                return null;
            }
            else if (method.Body.HasVariables || method.Body.Instructions.Count > 0)
            {
                if (method.Body.Instructions.Count == 0)
                {
                    throw new EmissionException("Expected either a valid method or an empty method with no variables when calling ApplyTo.");
                }

                var loadReturnInstruction = method.Body.Instructions[method.Body.Instructions.Count - 2];

                switch (loadReturnInstruction.OpCode.Code)
                {
                    case Code.Ldloc_0:
                        return method.Body.Variables[0];
                    case Code.Ldloc_1:
                        return method.Body.Variables[1];
                    case Code.Ldloc_2:
                        return method.Body.Variables[2];
                    case Code.Ldloc_3:
                        return method.Body.Variables[3];
                    case Code.Ldloc:
                    case Code.Ldloc_S:
                        return (VariableDefinition)loadReturnInstruction.Operand;
                    default:
                        return null;
                }
            }

            var variable = new VariableDefinition(method.ReturnType);
            method.Body.Variables.Add(variable);

            return variable;
        }

        internal static Instruction CreateLoadVariableInstruction(VariableDefinition variable)
        {
            switch (variable.Index)
            {
                case 0:
                    return Instruction.Create(OpCodes.Ldloc_0);
                case 1:
                    return Instruction.Create(OpCodes.Ldloc_1);
                case 2:
                    return Instruction.Create(OpCodes.Ldloc_2);
                case 3:
                    return Instruction.Create(OpCodes.Ldloc_3);
                default:
                    return Instruction.Create(variable.Index < 256 ? OpCodes.Ldloc_S : OpCodes.Ldloc, variable.Index);
            }
        }

        internal static Instruction CreateSetVariableInstruction(VariableDefinition variable)
        {
            switch (variable.Index)
            {
                case 0:
                    return Instruction.Create(OpCodes.Stloc_0);
                case 1:
                    return Instruction.Create(OpCodes.Stloc_1);
                case 2:
                    return Instruction.Create(OpCodes.Stloc_2);
                case 3:
                    return Instruction.Create(OpCodes.Stloc_3);
                default:
                    return Instruction.Create(variable.Index < 256 ? OpCodes.Stloc_S : OpCodes.Stloc, variable.Index);
            }
        }
        
        internal static VariableDefinition GetVariableFromInstruction(MethodDefinition method, Instruction instruction)
        {
            switch (instruction.OpCode.Code)
            {
                case Code.Ldloc_0:
                case Code.Stloc_0:
                    return method.Body.Variables[0];
                case Code.Ldloc_1:
                case Code.Stloc_1:
                    return method.Body.Variables[1];
                case Code.Ldloc_2:
                case Code.Stloc_2:
                    return method.Body.Variables[2];
                case Code.Ldloc_3:
                case Code.Stloc_3:
                    return method.Body.Variables[3];
                case Code.Ldloc:
                case Code.Stloc:
                case Code.Ldloc_S:
                case Code.Stloc_S:
                    return (VariableDefinition)instruction.Operand;
                default:
                    return null;
            }
        }
    }
}
