namespace ILusion.Tests.Sample
{
    public static class LessThanSamples
    {
        public static void Int8()
        {
            var left = (sbyte)1;
            var right = (sbyte)2;
            var x = left < right;
        }

        public static void UInt8()
        {
            var left = (byte)1;
            var right = (byte)2;
            var x = left < right;
        }

        public static void Int16()
        {
            var left = (short)1;
            var right = (short)2;
            var x = left < right;
        }

        public static void UInt16()
        {
            var left = (ushort)1;
            var right = (ushort)2;
            var x = left < right;
        }

        public static void Int32()
        {
            var left = 1;
            var right = 2;
            var x = left < right;
        }

        public static void UInt32()
        {
            var left = (uint)1;
            var right = (uint)2;
            var x = left < right;
        }

        public static void Int64()
        {
            var left = 1L;
            var right = 2L;
            var x = left < right;
        }

        public static void UInt64()
        {
            var left = (ulong)1;
            var right = (ulong)2;
            var x = left < right;
        }

        public static void Float()
        {
            var left = 1f;
            var right = 2f;
            var x = left < right;
        }

        public static void Double()
        {
            var left = 1.0;
            var right = 2.0;
            var x = left < right;
        }

        public static void Decimal()
        {
            var left = 1.0M;
            var right = 2.0M;
            var x = left < right;
        }
    }
}
