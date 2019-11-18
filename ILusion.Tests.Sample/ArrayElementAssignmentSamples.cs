using System;

namespace ILusion.Tests.Sample
{
    public static class ArrayElementAssignmentSamples
    {
        public static void SetClassElement(string[] array)
        {
            array[0] = "";
        }

        public static void SetStructElement(DateTime[] array)
        {
            array[0] = DateTime.Now;
        }

        public static void SetStructElementWithVariable(DateTime[] array)
        {
            var value = DateTime.Now;
            array[0] = value;
        }

        public static void SetStructElementDefault(DateTime[] array)
        {
            array[0] = default;
        }

        public static void SetNull(string[] array)
        {
            array[0] = null;
        }

        public static void SetGenericElement<T>(T[] array, T value)
        {
            array[0] = value;
        }
    }
}
