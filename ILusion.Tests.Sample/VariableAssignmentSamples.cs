using System;

namespace ILusion.Tests.Sample
{
    public static class VariableAssignmentSamples
    {
        public static void Class()
        {
            var x = 1;
        }

        public static void Struct(DateTime parameter)
        {
            var x = parameter;
        }

        public static void Generic<T>(T parameter)
        {
            var x = parameter;
        }

        public static void GenericNew<T>()
            where T : new()
        {
            var x = new T();
        }
    }
}
