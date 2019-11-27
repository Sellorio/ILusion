using System;

namespace ILusion.Tests.Sample
{
    public static class VariableReferenceSamples
    {
        public static void AsRef()
        {
            var value = "";
            RefMethod(ref value);
        }

        public static void Initialize()
        {
            var value = default(DateTime);
        }

        public static void StructInstanceMethod(DateTime value)
        {
            var v = value;
            v.ToString();
        }

        public static void GenericInstanceMethod<T>(T value)
        {
            var v = value;
            v.ToString();
        }

        public static void StructGenericInstanceMethod<T>(T value)
            where T : struct
        {
            var v = value;
            v.ToString();
        }

        private static void RefMethod(ref string value)
        {
        }
    }
}
