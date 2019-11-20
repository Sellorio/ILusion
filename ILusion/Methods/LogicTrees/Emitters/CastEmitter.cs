using ILusion.Exceptions;
using ILusion.Methods.LogicTrees.Helpers;
using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class CastEmitter : EmitterBase<CastNode>
    {
        protected override void Emit(EmitterContext<CastNode> emitterContext)
        {
            var sourceType = emitterContext.Node.Value.GetValueType();
            var targetType = emitterContext.Node.Type;

            if (sourceType == null)
            {
                throw new EmissionException("Unable to determine source type for cast.");
            }

            if (sourceType.FullName == typeof(object).FullName)
            {
                if (TypeHelper.IsClass(targetType) && !targetType.IsGenericParameter)
                {
                    emitterContext.Emit(OpCodes.Castclass, targetType);
                }
                else
                {
                    emitterContext.Emit(OpCodes.Unbox_Any, targetType);
                }
            }
            else if (targetType.FullName == typeof(object).FullName)
            {
                // no cast operation is required when using a class as an object
                if (!TypeHelper.IsClass(sourceType) || sourceType.IsGenericParameter)
                {
                    emitterContext.Emit(OpCodes.Box, sourceType);
                }
            }
            else if (TypeHelper.IsClass(sourceType) && TypeHelper.IsClass(targetType))
            {
                emitterContext.Emit(OpCodes.Castclass, targetType);
            }
            else
            {
                var mapping = emitterContext.Node.ThrowOnOverflow ? _checkedConversionOpCodeMapping : _uncheckedConversionOpCodeMapping;

                if (!mapping.TryGetValue(sourceType.FullName, out var targetTypeMapping))
                {
                    throw new EmissionException("Cast not supported for the source type.");
                }

                if (!targetTypeMapping.TryGetValue(targetType.FullName, out var opCode))
                {
                    throw new EmissionException("Cast not supported for the target type.");
                }

                if (opCode != null)
                {
                    if ((targetType.FullName == typeof(float).FullName || targetType.FullName == typeof(double).FullName)
                        && (sourceType.FullName == typeof(uint).FullName || sourceType.FullName == typeof(ulong).FullName))
                    {
                        emitterContext.Emit(OpCodes.Conv_R_Un);
                    }

                    emitterContext.Emit(opCode.Value);
                }
            }
        }

        private static readonly Dictionary<string, Dictionary<string, OpCode?>> _uncheckedConversionOpCodeMapping =
            new Dictionary<string, Dictionary<string, OpCode?>>
            {
                {
                    typeof(double).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_I2 },
                        { typeof(int).FullName, OpCodes.Conv_I4 },
                        { typeof(long).FullName, OpCodes.Conv_I8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_U2 },
                        { typeof(uint).FullName, OpCodes.Conv_U4 },
                        { typeof(ulong).FullName, OpCodes.Conv_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_U1 }
                    }
                },
                {
                    typeof(float).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(short).FullName, OpCodes.Conv_I2 },
                        { typeof(int).FullName, OpCodes.Conv_I4 },
                        { typeof(long).FullName, OpCodes.Conv_I8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_U2 },
                        { typeof(uint).FullName, OpCodes.Conv_U4 },
                        { typeof(ulong).FullName, OpCodes.Conv_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_U1 }
                    }
                },
                {
                    typeof(short).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(int).FullName, null },
                        { typeof(long).FullName, OpCodes.Conv_I8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_U2 },
                        { typeof(uint).FullName, null },
                        { typeof(ulong).FullName, OpCodes.Conv_I8 },
                        { typeof(byte).FullName, OpCodes.Conv_U1 }
                    }
                },
                {
                    typeof(int).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_I2 },
                        { typeof(long).FullName, OpCodes.Conv_I8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_U2 },
                        { typeof(uint).FullName, null },
                        { typeof(ulong).FullName, OpCodes.Conv_I8 },
                        { typeof(byte).FullName, OpCodes.Conv_U1 }
                    }
                },
                {
                    typeof(long).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_I2 },
                        { typeof(int).FullName, OpCodes.Conv_I4 },
                        { typeof(sbyte).FullName, OpCodes.Conv_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_U2 },
                        { typeof(uint).FullName, OpCodes.Conv_U4 },
                        { typeof(ulong).FullName, null },
                        { typeof(byte).FullName, OpCodes.Conv_U1 }
                    }
                },
                {
                    typeof(sbyte).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, null },
                        { typeof(int).FullName, null },
                        { typeof(long).FullName, OpCodes.Conv_I8 },
                        { typeof(ushort).FullName, OpCodes.Conv_U2 },
                        { typeof(uint).FullName, null },
                        { typeof(ulong).FullName, OpCodes.Conv_I8 },
                        { typeof(byte).FullName, OpCodes.Conv_U1 }
                    }
                },
                {
                    typeof(ushort).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_I2 },
                        { typeof(int).FullName, null },
                        { typeof(long).FullName, OpCodes.Conv_U8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_I1 },
                        { typeof(uint).FullName, null },
                        { typeof(ulong).FullName, OpCodes.Conv_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_U1 }
                    }
                },
                {
                    typeof(uint).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_I2 },
                        { typeof(int).FullName, null },
                        { typeof(long).FullName, OpCodes.Conv_U8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_U2 },
                        { typeof(ulong).FullName, OpCodes.Conv_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_U1 }
                    }
                },
                {
                    typeof(ulong).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_I2 },
                        { typeof(int).FullName, OpCodes.Conv_I4 },
                        { typeof(long).FullName, null },
                        { typeof(sbyte).FullName, OpCodes.Conv_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_U2 },
                        { typeof(uint).FullName, OpCodes.Conv_U4 },
                        { typeof(byte).FullName, OpCodes.Conv_U1 }
                    }
                },
                {
                    typeof(byte).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, null },
                        { typeof(int).FullName, null },
                        { typeof(long).FullName, OpCodes.Conv_U8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_I1 },
                        { typeof(ushort).FullName, null },
                        { typeof(uint).FullName, null },
                        { typeof(ulong).FullName, OpCodes.Conv_U8 }
                    }
                }
            };

        private static readonly Dictionary<string, Dictionary<string, OpCode?>> _checkedConversionOpCodeMapping =
            new Dictionary<string, Dictionary<string, OpCode?>>
            {
                {
                    typeof(double).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_Ovf_I2 },
                        { typeof(int).FullName, OpCodes.Conv_Ovf_I4 },
                        { typeof(long).FullName, OpCodes.Conv_Ovf_I8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_Ovf_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_Ovf_U2 },
                        { typeof(uint).FullName, OpCodes.Conv_Ovf_U4 },
                        { typeof(ulong).FullName, OpCodes.Conv_Ovf_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_Ovf_U1 }
                    }
                },
                {
                    typeof(float).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(short).FullName, OpCodes.Conv_Ovf_I2 },
                        { typeof(int).FullName, OpCodes.Conv_Ovf_I4 },
                        { typeof(long).FullName, OpCodes.Conv_Ovf_I8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_Ovf_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_Ovf_U2 },
                        { typeof(uint).FullName, OpCodes.Conv_Ovf_U4 },
                        { typeof(ulong).FullName, OpCodes.Conv_Ovf_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_Ovf_U1 }
                    }
                },
                {
                    typeof(short).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(int).FullName, null },
                        { typeof(long).FullName, OpCodes.Conv_I8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_Ovf_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_Ovf_U2 },
                        { typeof(uint).FullName, OpCodes.Conv_Ovf_U4 },
                        { typeof(ulong).FullName, OpCodes.Conv_Ovf_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_Ovf_U1 }
                    }
                },
                {
                    typeof(int).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_Ovf_I2 },
                        { typeof(long).FullName, OpCodes.Conv_I8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_Ovf_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_Ovf_U2 },
                        { typeof(uint).FullName, OpCodes.Conv_Ovf_U4 },
                        { typeof(ulong).FullName, OpCodes.Conv_Ovf_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_Ovf_U1 }
                    }
                },
                {
                    typeof(long).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_Ovf_I2 },
                        { typeof(int).FullName, OpCodes.Conv_Ovf_I4 },
                        { typeof(sbyte).FullName, OpCodes.Conv_Ovf_I1 },
                        { typeof(ushort).FullName, OpCodes.Conv_Ovf_U2 },
                        { typeof(uint).FullName, OpCodes.Conv_Ovf_U4 },
                        { typeof(ulong).FullName, OpCodes.Conv_Ovf_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_Ovf_U1 }
                    }
                },
                {
                    typeof(sbyte).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, null },
                        { typeof(int).FullName, null },
                        { typeof(long).FullName, OpCodes.Conv_I8 },
                        { typeof(ushort).FullName, OpCodes.Conv_Ovf_U2 },
                        { typeof(uint).FullName, OpCodes.Conv_Ovf_U4 },
                        { typeof(ulong).FullName, OpCodes.Conv_Ovf_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_Ovf_U1 }
                    }
                },
                {
                    typeof(ushort).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_Ovf_I2_Un },
                        { typeof(int).FullName, null },
                        { typeof(long).FullName, OpCodes.Conv_U8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_Ovf_I1_Un },
                        { typeof(uint).FullName, null },
                        { typeof(ulong).FullName, OpCodes.Conv_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_Ovf_U1_Un }
                    }
                },
                {
                    typeof(uint).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_Ovf_I2_Un },
                        { typeof(int).FullName, OpCodes.Conv_Ovf_I4_Un },
                        { typeof(long).FullName, OpCodes.Conv_U8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_Ovf_I1_Un },
                        { typeof(ushort).FullName, OpCodes.Conv_Ovf_U2_Un },
                        { typeof(ulong).FullName, OpCodes.Conv_U8 },
                        { typeof(byte).FullName, OpCodes.Conv_Ovf_U1_Un }
                    }
                },
                {
                    typeof(ulong).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, OpCodes.Conv_Ovf_I2_Un },
                        { typeof(int).FullName, OpCodes.Conv_Ovf_I4_Un },
                        { typeof(long).FullName, OpCodes.Conv_Ovf_I8_Un },
                        { typeof(sbyte).FullName, OpCodes.Conv_Ovf_I1_Un },
                        { typeof(ushort).FullName, OpCodes.Conv_Ovf_U2_Un },
                        { typeof(uint).FullName, OpCodes.Conv_Ovf_U4_Un },
                        { typeof(byte).FullName, OpCodes.Conv_Ovf_U1_Un }
                    }
                },
                {
                    typeof(byte).FullName,
                    new Dictionary<string, OpCode?>
                    {
                        { typeof(double).FullName, OpCodes.Conv_R8 },
                        { typeof(float).FullName, OpCodes.Conv_R4 },
                        { typeof(short).FullName, null },
                        { typeof(int).FullName, null },
                        { typeof(long).FullName, OpCodes.Conv_U8 },
                        { typeof(sbyte).FullName, OpCodes.Conv_Ovf_I1_Un },
                        { typeof(ushort).FullName, null },
                        { typeof(uint).FullName, null },
                        { typeof(ulong).FullName, OpCodes.Conv_U8 }
                    }
                }
            };
    }
}
