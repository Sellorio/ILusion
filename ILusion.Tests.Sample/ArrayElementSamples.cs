using System;

namespace ILusion.Tests.Sample
{
    public static class ArrayElementSamples
    {
        public static void CopyInt8ToVariable(sbyte[] array)
        {
            var value = array[0];
        }

        public static void CopyInt16ToVariable(short[] array)
        {
            var value = array[0];
        }

        public static void CopyInt32ToVariable(int[] array)
        {
            var value = array[0];
        }

        public static void CopyInt64ToVariable(long[] array)
        {
            var value = array[0];
        }

        public static void CopyUInt8ToVariable(byte[] array)
        {
            var value = array[0];
        }

        public static void CopyUInt16ToVariable(ushort[] array)
        {
            var value = array[0];
        }

        public static void CopyUInt32ToVariable(uint[] array)
        {
            var value = array[0];
        }

        public static void CopyUInt64ToVariable(ulong[] array)
        {
            var value = array[0];
        }

        public static void CopyFloatToVariable(float[] array)
        {
            var value = array[0];
        }

        public static void CopyDoubleToVariable(double[] array)
        {
            var value = array[0];
        }

        public static void CopyStringToVariable(string[] array)
        {
            var value = array[0];
        }

        public static void CopyDateTimeToVariable(DateTime[] array)
        {
            var value = array[0];
        }

        public static void CopyGenericToVariable<T>(T[] array)
        {
            var value = array[0];
        }

        public static void CopyClassGenericToVariable<T>(T[] array)
            where T : class
        {
            var value = array[0];
        }

        public static void CopyStructGenericToVariable<T>(T[] array)
            where T : struct
        {
            var value = array[0];
        }
    }
}
