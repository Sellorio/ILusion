using System;

namespace ILusion.Tests.Sample
{
    public static class InitializeSamples
    {
        public static void Variable_Default()
        {
            var v = default(DateTime);
        }

        public static void Variable_NewStruct()
        {
            var v = new DateTime();
        }

        public static void Parameter_Default(DateTime v)
        {
            v = default;
        }

        public static void Parameter_NewStruct(DateTime v)
        {
            v = new DateTime();
        }

        public static void RefParameter_Default(ref DateTime v)
        {
            v = default;
        }

        public static void RefParameter_NewStruct(ref DateTime v)
        {
            v = new DateTime();
        }

        public static void Array_Default(DateTime[] array)
        {
            array[0] = default;
        }

        public static void Array_NewStruct(DateTime[] array)
        {
            array[0] = new DateTime();
        }

        public static void StructGeneric_Default<T>()
            where T : struct
        {
            var v = default(T);
        }

        public static void StructGeneric_NewStruct<T>()
            where T : struct
        {
            var v = new T();
        }

        public static void WithConstructor()
        {
            var v = new DateTime(2019, 11, 21);
        }

        public static void NewStructToString()
        {
            new DateTime(2019, 11, 21).ToString();
        }
    }
}
