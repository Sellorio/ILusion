using System;

namespace ILusion.Tests.Sample
{
    public static class ArrayElementReferenceSamples
    {
        public static void FromVariable(DateTime[] array)
        {
            array[0] = default;
        }

        public static void FromNew()
        {
            (new DateTime[0])[0] = default;
        }

        public static void AsRefParameter(string[] array)
        {
            RefAction(ref array[0]);
        }

        private static void RefAction(ref string value)
        {
        }
    }
}
