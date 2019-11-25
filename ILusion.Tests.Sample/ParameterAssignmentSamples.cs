using System;

namespace ILusion.Tests.Sample
{
    public static class ParameterAssignmentSamples
    {
        public static void Class(string parameter)
        {
            parameter = "";
        }

        public static void Struct(DateTime parameter)
        {
            parameter = DateTime.Now;
        }

        public static void Generic<T>(T v1, T v2)
        {
            v1 = v2;
        }

        public static void GenericNew<T>(T parameter)
            where T : new()
        {
            parameter = new T();
        }
    }
}
