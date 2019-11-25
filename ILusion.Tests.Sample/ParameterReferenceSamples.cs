using System;

namespace ILusion.Tests.Sample
{
    public static class ParameterReferenceSamples
    {
        public static void AsRef(string value)
        {
            RefMethod(ref value);
        }

        public static void RefAsRef(ref string value)
        {
            RefMethod(ref value);
        }

        public static void Initialize(DateTime value)
        {
            value = default;
        }

        public static void StructInstanceMethod(DateTime value)
        {
            value.ToString();
        }

        public static void GenericInstanceMethod<T>(T value)
        {
            value.ToString();
        }

        public static void StructGenericInstanceMethod<T>(T value)
            where T : struct
        {
            value.ToString();
        }

        private static void RefMethod(ref string value)
        {
        }
    }
}
