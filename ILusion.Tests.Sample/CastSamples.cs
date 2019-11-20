using System;

namespace ILusion.Tests.Sample
{
    public static class CastSamples
    {
        public static void BoxStruct(DateTime value)
        {
            var v = (object)value;
        }

        public static void UnboxStruct(object value)
        {
            var v = (DateTime)value;
        }

        public static void BoxGeneric<T>(T value)
        {
            var v = (object)value;
        }

        public static void UnboxGeneric<T>(object value)
        {
            var v = (T)value;
        }

        public static void BoxStructGeneric<T>(T value)
            where T : struct
        {
            var v = (object)value;
        }

        public static void UnboxStructGeneric<T>(object value)
            where T : struct
        {
            var v = (T)value;
        }

        public static void CastClassToObject(string value)
        {
            var v = (object)value;
        }

        public static void CastObjectToClass(object value)
        {
            var v = (string)value;
        }

        public static void CastClassGenericToObject<T>(T value)
            where T : class
        {
            var v = (object)value;
        }

        public static void CastObjectToClassGeneric<T>(object value)
            where T : class
        {
            var v = (T)value;
        }

        public static void Int8ToUInt8(sbyte value)
        {
            var v = (byte)value;
        }

        public static void Int8ToInt16(sbyte value)
        {
            var v = (short)value;
        }

        public static void Int8ToUInt16(sbyte value)
        {
            var v = (ushort)value;
        }

        public static void Int8ToInt32(sbyte value)
        {
            var v = (int)value;
        }

        public static void Int8ToUInt32(sbyte value)
        {
            var v = (uint)value;
        }

        public static void Int8ToInt64(sbyte value)
        {
            var v = (long)value;
        }

        public static void Int8ToUInt64(sbyte value)
        {
            var v = (ulong)value;
        }

        public static void Int8ToFloat(sbyte value)
        {
            var v = (float)value;
        }

        public static void Int8ToDouble(sbyte value)
        {
            var v = (double)value;
        }

        public static void UInt8ToInt8(byte value)
        {
            var v = (sbyte)value;
        }

        public static void UInt8ToInt16(byte value)
        {
            var v = (short)value;
        }

        public static void UInt8ToUInt16(byte value)
        {
            var v = (ushort)value;
        }

        public static void UInt8ToInt32(byte value)
        {
            var v = (int)value;
        }

        public static void UInt8ToUInt32(byte value)
        {
            var v = (uint)value;
        }

        public static void UInt8ToInt64(byte value)
        {
            var v = (long)value;
        }

        public static void UInt8ToUInt64(byte value)
        {
            var v = (ulong)value;
        }

        public static void UInt8ToFloat(byte value)
        {
            var v = (float)value;
        }

        public static void UInt8ToDouble(byte value)
        {
            var v = (double)value;
        }

        public static void Int16ToInt8(short value)
        {
            var v = (sbyte)value;
        }

        public static void Int16ToUInt8(short value)
        {
            var v = (byte)value;
        }

        public static void Int16ToUInt16(short value)
        {
            var v = (ushort)value;
        }

        public static void Int16ToInt32(short value)
        {
            var v = (int)value;
        }

        public static void Int16ToUInt32(short value)
        {
            var v = (uint)value;
        }

        public static void Int16ToInt64(short value)
        {
            var v = (long)value;
        }

        public static void Int16ToUInt64(short value)
        {
            var v = (ulong)value;
        }

        public static void Int16ToFloat(short value)
        {
            var v = (float)value;
        }

        public static void Int16ToDouble(short value)
        {
            var v = (double)value;
        }

        public static void UInt16ToInt8(ushort value)
        {
            var v = (sbyte)value;
        }

        public static void UInt16ToUInt8(ushort value)
        {
            var v = (byte)value;
        }

        public static void UInt16ToInt16(ushort value)
        {
            var v = (short)value;
        }

        public static void UInt16ToInt32(ushort value)
        {
            var v = (int)value;
        }

        public static void UInt16ToUInt32(ushort value)
        {
            var v = (uint)value;
        }

        public static void UInt16ToInt64(ushort value)
        {
            var v = (long)value;
        }

        public static void UInt16ToUInt64(ushort value)
        {
            var v = (ulong)value;
        }

        public static void UInt16ToFloat(ushort value)
        {
            var v = (float)value;
        }

        public static void UInt16ToDouble(ushort value)
        {
            var v = (double)value;
        }

        public static void Int32ToInt8(int value)
        {
            var v = (sbyte)value;
        }

        public static void Int32ToUInt8(int value)
        {
            var v = (byte)value;
        }

        public static void Int32ToInt16(int value)
        {
            var v = (short)value;
        }

        public static void Int32ToUInt16(int value)
        {
            var v = (ushort)value;
        }

        public static void Int32ToUInt32(int value)
        {
            var v = (uint)value;
        }

        public static void Int32ToInt64(int value)
        {
            var v = (long)value;
        }

        public static void Int32ToUInt64(int value)
        {
            var v = (ulong)value;
        }

        public static void Int32ToFloat(int value)
        {
            var v = (float)value;
        }

        public static void Int32ToDouble(int value)
        {
            var v = (double)value;
        }

        public static void UInt32ToInt8(uint value)
        {
            var v = (sbyte)value;
        }

        public static void UInt32ToUInt8(uint value)
        {
            var v = (byte)value;
        }

        public static void UInt32ToInt16(uint value)
        {
            var v = (short)value;
        }

        public static void UInt32ToUInt16(uint value)
        {
            var v = (ushort)value;
        }

        public static void UInt32ToInt32(uint value)
        {
            var v = (int)value;
        }

        public static void UInt32ToInt64(uint value)
        {
            var v = (long)value;
        }

        public static void UInt32ToUInt64(uint value)
        {
            var v = (ulong)value;
        }

        public static void UInt32ToFloat(uint value)
        {
            var v = (float)value;
        }

        public static void UInt32ToDouble(uint value)
        {
            var v = (double)value;
        }

        public static void Int64ToInt8(long value)
        {
            var v = (sbyte)value;
        }

        public static void Int64ToUInt8(long value)
        {
            var v = (byte)value;
        }

        public static void Int64ToInt16(long value)
        {
            var v = (short)value;
        }

        public static void Int64ToUInt16(long value)
        {
            var v = (ushort)value;
        }

        public static void Int64ToInt32(long value)
        {
            var v = (int)value;
        }

        public static void Int64ToUInt32(long value)
        {
            var v = (uint)value;
        }

        public static void Int64ToUInt64(long value)
        {
            var v = (ulong)value;
        }

        public static void Int64ToFloat(long value)
        {
            var v = (float)value;
        }

        public static void Int64ToDouble(long value)
        {
            var v = (double)value;
        }

        public static void UInt64ToInt8(ulong value)
        {
            var v = (sbyte)value;
        }

        public static void UInt64ToUInt8(ulong value)
        {
            var v = (byte)value;
        }

        public static void UInt64ToInt16(ulong value)
        {
            var v = (short)value;
        }

        public static void UInt64ToUInt16(ulong value)
        {
            var v = (ushort)value;
        }

        public static void UInt64ToInt32(ulong value)
        {
            var v = (int)value;
        }

        public static void UInt64ToInt64(ulong value)
        {
            var v = (long)value;
        }

        public static void UInt64ToUInt32(ulong value)
        {
            var v = (uint)value;
        }

        public static void UInt64ToFloat(ulong value)
        {
            var v = (float)value;
        }

        public static void UInt64ToDouble(ulong value)
        {
            var v = (double)value;
        }

        public static void DoubleToInt8(double value)
        {
            var v = (sbyte)value;
        }

        public static void DoubleToUInt8(double value)
        {
            var v = (byte)value;
        }

        public static void DoubleToInt16(double value)
        {
            var v = (short)value;
        }

        public static void DoubleToUInt16(double value)
        {
            var v = (ushort)value;
        }

        public static void DoubleToInt32(double value)
        {
            var v = (int)value;
        }

        public static void DoubleToUInt32(double value)
        {
            var v = (uint)value;
        }

        public static void DoubleToInt64(double value)
        {
            var v = (long)value;
        }

        public static void DoubleToUInt64(double value)
        {
            var v = (ulong)value;
        }

        public static void DoubleToFloat(double value)
        {
            var v = (float)value;
        }

        public static void FloatToInt8(float value)
        {
            var v = (sbyte)value;
        }

        public static void FloatToUInt8(float value)
        {
            var v = (byte)value;
        }

        public static void FloatToInt16(float value)
        {
            var v = (short)value;
        }

        public static void FloatToUInt16(float value)
        {
            var v = (ushort)value;
        }

        public static void FloatToInt32(float value)
        {
            var v = (int)value;
        }

        public static void FloatToUInt32(float value)
        {
            var v = (uint)value;
        }

        public static void FloatToInt64(float value)
        {
            var v = (long)value;
        }

        public static void FloatToUInt64(float value)
        {
            var v = (ulong)value;
        }

        public static void FloatToDouble(float value)
        {
            var v = (double)value;
        }

        public static void CheckedInt8ToUInt8(sbyte value)
        {
            var v = checked((byte)value);
        }

        public static void CheckedInt8ToInt16(sbyte value)
        {
            var v = checked((short)value);
        }

        public static void CheckedInt8ToUInt16(sbyte value)
        {
            var v = checked((ushort)value);
        }

        public static void CheckedInt8ToInt32(sbyte value)
        {
            var v = checked((int)value);
        }

        public static void CheckedInt8ToUInt32(sbyte value)
        {
            var v = checked((uint)value);
        }

        public static void CheckedInt8ToInt64(sbyte value)
        {
            var v = checked((long)value);
        }

        public static void CheckedInt8ToUInt64(sbyte value)
        {
            var v = checked((ulong)value);
        }

        public static void CheckedInt8ToFloat(sbyte value)
        {
            var v = checked((float)value);
        }

        public static void CheckedInt8ToDouble(sbyte value)
        {
            var v = checked((double)value);
        }

        public static void CheckedUInt8ToInt8(byte value)
        {
            var v = checked((sbyte)value);
        }

        public static void CheckedUInt8ToInt16(byte value)
        {
            var v = checked((short)value);
        }

        public static void CheckedUInt8ToUInt16(byte value)
        {
            var v = checked((ushort)value);
        }

        public static void CheckedUInt8ToInt32(byte value)
        {
            var v = checked((int)value);
        }

        public static void CheckedUInt8ToUInt32(byte value)
        {
            var v = checked((uint)value);
        }

        public static void CheckedUInt8ToInt64(byte value)
        {
            var v = checked((long)value);
        }

        public static void CheckedUInt8ToUInt64(byte value)
        {
            var v = checked((ulong)value);
        }

        public static void CheckedUInt8ToFloat(byte value)
        {
            var v = checked((float)value);
        }

        public static void CheckedUInt8ToDouble(byte value)
        {
            var v = checked((double)value);
        }

        public static void CheckedInt16ToInt8(short value)
        {
            var v = checked((sbyte)value);
        }

        public static void CheckedInt16ToUInt8(short value)
        {
            var v = checked((byte)value);
        }

        public static void CheckedInt16ToUInt16(short value)
        {
            var v = checked((ushort)value);
        }

        public static void CheckedInt16ToInt32(short value)
        {
            var v = checked((int)value);
        }

        public static void CheckedInt16ToUInt32(short value)
        {
            var v = checked((uint)value);
        }

        public static void CheckedInt16ToInt64(short value)
        {
            var v = checked((long)value);
        }

        public static void CheckedInt16ToUInt64(short value)
        {
            var v = checked((ulong)value);
        }

        public static void CheckedInt16ToFloat(short value)
        {
            var v = checked((float)value);
        }

        public static void CheckedInt16ToDouble(short value)
        {
            var v = checked((double)value);
        }

        public static void CheckedUInt16ToInt8(ushort value)
        {
            var v = checked((sbyte)value);
        }

        public static void CheckedUInt16ToUInt8(ushort value)
        {
            var v = checked((byte)value);
        }

        public static void CheckedUInt16ToInt16(ushort value)
        {
            var v = checked((short)value);
        }

        public static void CheckedUInt16ToInt32(ushort value)
        {
            var v = checked((int)value);
        }

        public static void CheckedUInt16ToUInt32(ushort value)
        {
            var v = checked((uint)value);
        }

        public static void CheckedUInt16ToInt64(ushort value)
        {
            var v = checked((long)value);
        }

        public static void CheckedUInt16ToUInt64(ushort value)
        {
            var v = checked((ulong)value);
        }

        public static void CheckedUInt16ToFloat(ushort value)
        {
            var v = checked((float)value);
        }

        public static void CheckedUInt16ToDouble(ushort value)
        {
            var v = checked((double)value);
        }

        public static void CheckedInt32ToInt8(int value)
        {
            var v = checked((sbyte)value);
        }

        public static void CheckedInt32ToUInt8(int value)
        {
            var v = checked((byte)value);
        }

        public static void CheckedInt32ToInt16(int value)
        {
            var v = checked((short)value);
        }

        public static void CheckedInt32ToUInt16(int value)
        {
            var v = checked((ushort)value);
        }

        public static void CheckedInt32ToUInt32(int value)
        {
            var v = checked((uint)value);
        }

        public static void CheckedInt32ToInt64(int value)
        {
            var v = checked((long)value);
        }

        public static void CheckedInt32ToUInt64(int value)
        {
            var v = checked((ulong)value);
        }

        public static void CheckedInt32ToFloat(int value)
        {
            var v = checked((float)value);
        }

        public static void CheckedInt32ToDouble(int value)
        {
            var v = checked((double)value);
        }

        public static void CheckedUInt32ToInt8(uint value)
        {
            var v = checked((sbyte)value);
        }

        public static void CheckedUInt32ToUInt8(uint value)
        {
            var v = checked((byte)value);
        }

        public static void CheckedUInt32ToInt16(uint value)
        {
            var v = checked((short)value);
        }

        public static void CheckedUInt32ToUInt16(uint value)
        {
            var v = checked((ushort)value);
        }

        public static void CheckedUInt32ToInt32(uint value)
        {
            var v = checked((int)value);
        }

        public static void CheckedUInt32ToInt64(uint value)
        {
            var v = checked((long)value);
        }

        public static void CheckedUInt32ToUInt64(uint value)
        {
            var v = checked((ulong)value);
        }

        public static void CheckedUInt32ToFloat(uint value)
        {
            var v = checked((float)value);
        }

        public static void CheckedUInt32ToDouble(uint value)
        {
            var v = checked((double)value);
        }

        public static void CheckedInt64ToInt8(long value)
        {
            var v = checked((sbyte)value);
        }

        public static void CheckedInt64ToUInt8(long value)
        {
            var v = checked((byte)value);
        }

        public static void CheckedInt64ToInt16(long value)
        {
            var v = checked((short)value);
        }

        public static void CheckedInt64ToUInt16(long value)
        {
            var v = checked((ushort)value);
        }

        public static void CheckedInt64ToInt32(long value)
        {
            var v = checked((int)value);
        }

        public static void CheckedInt64ToUInt32(long value)
        {
            var v = checked((uint)value);
        }

        public static void CheckedInt64ToUInt64(long value)
        {
            var v = checked((ulong)value);
        }

        public static void CheckedInt64ToFloat(long value)
        {
            var v = checked((float)value);
        }

        public static void CheckedInt64ToDouble(long value)
        {
            var v = checked((double)value);
        }

        public static void CheckedUInt64ToInt8(ulong value)
        {
            var v = checked((sbyte)value);
        }

        public static void CheckedUInt64ToUInt8(ulong value)
        {
            var v = checked((byte)value);
        }

        public static void CheckedUInt64ToInt16(ulong value)
        {
            var v = checked((short)value);
        }

        public static void CheckedUInt64ToUInt16(ulong value)
        {
            var v = checked((ushort)value);
        }

        public static void CheckedUInt64ToInt32(ulong value)
        {
            var v = checked((int)value);
        }

        public static void CheckedUInt64ToInt64(ulong value)
        {
            var v = checked((long)value);
        }

        public static void CheckedUInt64ToUInt32(ulong value)
        {
            var v = checked((uint)value);
        }

        public static void CheckedUInt64ToFloat(ulong value)
        {
            var v = checked((float)value);
        }

        public static void CheckedUInt64ToDouble(ulong value)
        {
            var v = checked((double)value);
        }

        public static void CheckedDoubleToInt8(double value)
        {
            var v = checked((sbyte)value);
        }

        public static void CheckedDoubleToUInt8(double value)
        {
            var v = checked((byte)value);
        }

        public static void CheckedDoubleToInt16(double value)
        {
            var v = checked((short)value);
        }

        public static void CheckedDoubleToUInt16(double value)
        {
            var v = checked((ushort)value);
        }

        public static void CheckedDoubleToInt32(double value)
        {
            var v = checked((int)value);
        }

        public static void CheckedDoubleToUInt32(double value)
        {
            var v = checked((uint)value);
        }

        public static void CheckedDoubleToInt64(double value)
        {
            var v = checked((long)value);
        }

        public static void CheckedDoubleToUInt64(double value)
        {
            var v = checked((ulong)value);
        }

        public static void CheckedDoubleToFloat(double value)
        {
            var v = checked((float)value);
        }

        public static void CheckedFloatToInt8(float value)
        {
            var v = checked((sbyte)value);
        }

        public static void CheckedFloatToUInt8(float value)
        {
            var v = checked((byte)value);
        }

        public static void CheckedFloatToInt16(float value)
        {
            var v = checked((short)value);
        }

        public static void CheckedFloatToUInt16(float value)
        {
            var v = checked((ushort)value);
        }

        public static void CheckedFloatToInt32(float value)
        {
            var v = checked((int)value);
        }

        public static void CheckedFloatToUInt32(float value)
        {
            var v = checked((uint)value);
        }

        public static void CheckedFloatToInt64(float value)
        {
            var v = checked((long)value);
        }

        public static void CheckedFloatToUInt64(float value)
        {
            var v = checked((ulong)value);
        }

        public static void CheckedFloatToDouble(float value)
        {
            var v = checked((double)value);
        }
    }
}
