using System;

namespace ILusion.Tests.Sample
{
    public static class ParameterSamples
    {
        public static DateTime Struct(DateTime value)
        {
            return value;
        }

        public static string Class(string value)
        {
            return value;
        }

        public static T Generic<T>(T value)
        {
            return value;
        }

        public static sbyte SByteByRef(ref sbyte value)
        {
            return value;
        }

        public static byte ByteByRef(ref byte value)
        {
            return value;
        }

        public static short ShortByRef(ref short value)
        {
            return value;
        }

        public static ushort UShortByRef(ref ushort value)
        {
            return value;
        }

        public static int IntByRef(ref int value)
        {
            return value;
        }

        public static uint UIntByRef(ref uint value)
        {
            return value;
        }

        public static long LongByRef(ref long value)
        {
            return value;
        }

        public static ulong ULongByRef(ref ulong value)
        {
            return value;
        }

        public static float FloatByRef(ref float value)
        {
            return value;
        }

        public static double DoubleByRef(ref double value)
        {
            return value;
        }

        public static DateTime StructByRef(ref DateTime value)
        {
            return value;
        }

        public static string ClassByRef(ref string value)
        {
            return value;
        }

        public static void ByRefNative(ref string value)
        {
            Method(ref value);
        }

        private static void Method(ref string value)
        {
        }
    }
}
