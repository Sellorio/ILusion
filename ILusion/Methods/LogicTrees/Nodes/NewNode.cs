using ILusion.Methods.LogicTrees.Helpers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ILusion.Methods.LogicTrees.Nodes
{
    /// <remarks>
    /// Cases:
    ///   Structs:
    ///     When calling empty constructor and assigning to a parameter, the parameter is loaded by reference and opcode initobj is used. This has no output.
    ///     When calling empty constructor and assigning to a local, the local is loaded by reference and opcode initobj is used. This has no output.
    ///     When calling empty constructor and passing value as parameter (same as default keyword), a local variable is generated and opcode initobj followed by opcode ldloc are used. This returns the created object.
    ///     When calling non-empty constructor and assigning to a parameter, the parameter is loaded by reference followed by the constructor parameter values and then opcode call. This has no output.
    ///     When calling non-empty constructor and assigning to a local, the local is loaded by reference followed by the constructor parameter values and then opcode call. This has no output.
    ///     When calling non-empty constructor and passing value as parameter, the constructor parameters are loaded followed by opcode newobj. This returns the created object.
    ///   Generic Type:
    ///     When calling empty constructor (only option), Activator.CreateInstance&lt;T&gt;() is called using opcode call. This returns the created object.
    ///   Class:
    ///     When calling any constructor, opcode newobj is used. This returns the created object.
    ///   Array:
    ///     Opcode newarr is used. This returns the created object.
    ///   Delegate:
    ///     ???
    /// </remarks>
    public sealed class NewNode : ValueNode
    {
        private static readonly MethodInfo _createInstanceMethod = typeof(Activator).GetMethod(nameof(Activator.CreateInstance), new Type[0]);

        internal VariableDefinition GeneratedVariable { get; }
        internal bool RequiresGeneratedVariable { get; }

        /// <summary>
        /// When creating a Struct value, if that value is being assigned to a Parameter or
        /// Local variable directly, the *this* parameter is passed in by reference so that
        /// the created struct does not need to be copied to the variable/parameter.
        /// </summary>
        public ReferenceValueNode This { get; }
        public IReadOnlyList<ValueNode> Parameters { get; }
        public TypeReference Type { get; }
        public MethodReference Constructor { get; }

        internal override Instruction[] ToInstructions()
        {
            // Generic Type
            if (Type is GenericParameter)
            {
                var genericMethod = Module.ImportReference(_createInstanceMethod);
                var call = new GenericInstanceMethod(genericMethod);
                call.GenericArguments.Add(Type);

                return new[] { Instruction.Create(OpCodes.Call, call) };
            }

            var resolvedType = Type.Resolve();

            // Class
            if (resolvedType.IsClass)
            {
                return new[] { Instruction.Create(OpCodes.Newobj, Constructor) };
            }

            // Array
            if (Type is ArrayType arrayType)
            {
                return new[] { Instruction.Create(OpCodes.Newarr, arrayType.ElementType) };
            }

            // Struct

            // Default constructor
            if (Constructor == null)
            {
                // Only placed on the stack
                if (This == null)
                {
                    var loadOpCode = OpCodeHelper.LoadLocalOpCode(GeneratedVariable.Index, out var requiresParameter);

                    return new[]
                    {
                        Instruction.Create(GeneratedVariable.Index > 255 ? OpCodes.Ldloca : OpCodes.Ldloca_S, GeneratedVariable.Index),
                        Instruction.Create(OpCodes.Initobj, Type),
                        requiresParameter ? Instruction.Create(loadOpCode, GeneratedVariable.Index) : Instruction.Create(loadOpCode)
                    };
                }
                else
                {
                    var loadOpCode = OpCodeHelper.LoadLocalOpCode(GeneratedVariable.Index, out var requiresParameter);

                    return new[]
                    {
                        Instruction.Create(OpCodes.Initobj, Type),
                        requiresParameter ? Instruction.Create(loadOpCode, GeneratedVariable.Index) : Instruction.Create(loadOpCode)
                    };
                }
            }

            if (This == null)
            {
                return new[] { Instruction.Create(OpCodes.Newobj, Constructor) };
            }
            else if (This is VariableReferenceNode variableReference)
            {
                var loadOpCode = OpCodeHelper.LoadLocalOpCode(variableReference.Variable.Index, out var requiresParameter);

                return new[]
                {
                    Instruction.Create(OpCodes.Call, Constructor),
                    requiresParameter ? Instruction.Create(loadOpCode, variableReference.Variable.Index) : Instruction.Create(loadOpCode)
                };
            }
            else if (This is ParameterReferenceNode parameterReference)
            {
                var loadOpCode = OpCodeHelper.LoadParameterOpCode(parameterReference.Parameter.Index, out var requiresParameter);

                return new[]
                {
                    Instruction.Create(OpCodes.Call, Constructor),
                    requiresParameter ? Instruction.Create(loadOpCode, parameterReference.Parameter.Index) : Instruction.Create(loadOpCode)
                };
            }
            else
            {
                throw new NotSupportedException("A new ReferenceValueNode was added but is not supported by NewNode.");
            }
        }

        internal override TypeReference GetValueType()
        {
            return Type;
        }
    }
}
