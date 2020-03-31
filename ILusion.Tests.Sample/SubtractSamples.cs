using System.Diagnostics.CodeAnalysis;

namespace ILusion.Tests.Sample
{
    [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed")]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value")]
    public static class SubtractSamples
    {
        public static void SubtractInt8()
        {
            var left = (sbyte)1;
            var right = (sbyte)2;
            var x = left - right;
        }

        public static void SubtractUInt8()
        {
            var left = (byte)1;
            var right = (byte)2;
            var x = left - right;
        }

        public static void SubtractInt16()
        {
            var left = (short)1;
            var right = (short)2;
            var x = left - right;
        }

        public static void SubtractUInt16()
        {
            var left = (ushort)1;
            var right = (ushort)2;
            var x = left - right;
        }

        public static void SubtractInt32()
        {
            var left = 1;
            var right = 2;
            var x = left - right;
        }

        public static void SubtractUInt32()
        {
            var left = (uint)1;
            var right = (uint)2;
            var x = left - right;
        }

        public static void SubtractInt64()
        {
            var left = 1L;
            var right = 2L;
            var x = left - right;
        }

        public static void SubtractUInt64()
        {
            var left = (ulong)1;
            var right = (ulong)2;
            var x = left - right;
        }

        public static void SubtractFloat()
        {
            var left = 1f;
            var right = 2f;
            var x = left - right;
        }

        public static void SubtractDouble()
        {
            var left = 1.0;
            var right = 2.0;
            var x = left - right;
        }

        public static void SubtractDecimal()
        {
            var left = 1.0M;
            var right = 2.0M;
            var x = left - right;
        }

        public static void SubtractInt8Checked()
        {
            var left = (sbyte)1;
            var right = (sbyte)2;
            var x = checked(left - right);
        }

        public static void SubtractUInt8Checked()
        {
            var left = (byte)1;
            var right = (byte)2;
            var x = checked(left - right);
        }

        public static void SubtractInt16Checked()
        {
            var left = (short)1;
            var right = (short)2;
            var x = checked(left - right);
        }

        public static void SubtractUInt16Checked()
        {
            var left = (ushort)1;
            var right = (ushort)2;
            var x = checked(left - right);
        }

        public static void SubtractInt32Checked()
        {
            var left = 1;
            var right = 2;
            var x = checked(left - right);
        }

        public static void SubtractUInt32Checked()
        {
            var left = (uint)1;
            var right = (uint)2;
            var x = checked(left - right);
        }

        public static void SubtractInt64Checked()
        {
            var left = 1L;
            var right = 2L;
            var x = checked(left - right);
        }

        public static void SubtractUInt64Checked()
        {
            var left = (ulong)1;
            var right = (ulong)2;
            var x = checked(left - right);
        }

        public static void SubtractFloatChecked()
        {
            var left = 1f;
            var right = 2f;
            var x = checked(left - right);
        }

        public static void SubtractDoubleChecked()
        {
            var left = 1.0;
            var right = 2.0;
            var x = checked(left - right);
        }

        public static void SubtractDecimalChecked()
        {
            var left = 1.0M;
            var right = 2.0M;
            var x = checked(left - right);
        }
    }
}
