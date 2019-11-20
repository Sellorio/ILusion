using System;

namespace ILusion.Tests.Sample
{
    public class FieldReferenceSamples<T, T2, T3>
        where T2 : class
        where T3 : struct
    {
        private static DateTime _static;
        private static T _t1;
        private static T2 _t2;
        private static T3 _t3;
        private DateTime _instance;

        public void InitializeInstance()
        {
            _instance = default;
        }

        public static void InitializeStatic()
        {
            _static = default;
        }

        public static void StructToString()
        {
            _static.ToString();
        }

        public static void GenericToString()
        {
            _t1.ToString();
        }

        public static void GenericClassToString()
        {
            _t2.ToString();
        }

        public static void GenericStructToString()
        {
            _t3.ToString();
        }

        public static void AsRefParameter()
        {
            RefAction(ref _static);
        }

        private static void RefAction(ref DateTime value)
        {
        }
    }
}
