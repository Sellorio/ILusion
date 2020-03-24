using System.Diagnostics.CodeAnalysis;

namespace ILusion.Tests.Sample
{
    [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed")]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value")]
    public static class AddSamples
    {
        public static void AddInt8()
        {
            var left = (sbyte)1;
            var right = (sbyte)2;
            var x = left + right;
        }

        public static void AddUInt8()
        {
            var left = (byte)1;
            var right = (byte)2;
            var x = left + right;
        }

        public static void AddInt16()
        {
            var left = (short)1;
            var right = (short)2;
            var x = left + right;
        }

        public static void AddUInt16()
        {
            var left = (ushort)1;
            var right = (ushort)2;
            var x = left + right;
        }

        public static void AddInt32()
        {
            var left = 1;
            var right = 2;
            var x = left + right;
        }

        public static void AddUInt32()
        {
            var left = (uint)1;
            var right = (uint)2;
            var x = left + right;
        }

        public static void AddInt64()
        {
            var left = 1L;
            var right = 2L;
            var x = left + right;
        }

        public static void AddUInt64()
        {
            var left = (ulong)1;
            var right = (ulong)2;
            var x = left + right;
        }

        public static void AddFloat()
        {
            var left = 1f;
            var right = 2f;
            var x = left + right;
        }

        public static void AddDouble()
        {
            var left = 1.0;
            var right = 2.0;
            var x = left + right;
        }

        public static void AddDecimal()
        {
            var left = 1.0M;
            var right = 2.0M;
            var x = left + right;
        }

        public static void AddInt8Checked()
        {
            var left = (sbyte)1;
            var right = (sbyte)2;
            var x = checked(left + right);
        }

        public static void AddUInt8Checked()
        {
            var left = (byte)1;
            var right = (byte)2;
            var x = checked(left + right);
        }

        public static void AddInt16Checked()
        {
            var left = (short)1;
            var right = (short)2;
            var x = checked(left + right);
        }

        public static void AddUInt16Checked()
        {
            var left = (ushort)1;
            var right = (ushort)2;
            var x = checked(left + right);
        }

        public static void AddInt32Checked()
        {
            var left = 1;
            var right = 2;
            var x = checked(left + right);
        }

        public static void AddUInt32Checked()
        {
            var left = (uint)1;
            var right = (uint)2;
            var x = checked(left + right);
        }

        public static void AddInt64Checked()
        {
            var left = 1L;
            var right = 2L;
            var x = checked(left + right);
        }

        public static void AddUInt64Checked()
        {
            var left = (ulong)1;
            var right = (ulong)2;
            var x = checked(left + right);
        }

        public static void AddFloatChecked()
        {
            var left = 1f;
            var right = 2f;
            var x = checked(left + right);
        }

        public static void AddDoubleChecked()
        {
            var left = 1.0;
            var right = 2.0;
            var x = checked(left + right);
        }

        public static void AddDecimalChecked()
        {
            var left = 1.0M;
            var right = 2.0M;
            var x = checked(left + right);
        }
    }
}
