using System;

namespace ILusion.Tests.Sample
{
    public static class ReferenceAssignmentSamples
    {
        public static void Int8(out sbyte result)
        {
            result = 0;
        }

        public static void UInt8(out byte result)
        {
            result = 0;
        }

        public static void Int16(out short result)
        {
            result = 0;
        }

        public static void UInt16(out ushort result)
        {
            result = 0;
        }

        public static void Int32(out int result)
        {
            result = 0;
        }

        public static void UInt32(out uint result)
        {
            result = 0U;
        }

        public static void Int64(out long result)
        {
            result = 1234567891011;
        }

        public static void UInt64(out ulong result)
        {
            result = 1234567891011;
        }

        public static void Float(out float result)
        {
            result = 0.0f;
        }

        public static void Double(out double result)
        {
            result = 0.0;
        }

        public static void Struct(out DateTime result)
        {
            result = new DateTime(2011, 11, 27);
        }

        public static void Class(out string result)
        {
            result = "";
        }
    }
}
