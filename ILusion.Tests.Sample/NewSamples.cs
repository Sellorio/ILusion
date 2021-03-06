﻿using System;
using System.Collections.Generic;

namespace ILusion.Tests.Sample
{
    public static class NewSamples
    {
        public static void Generic<T>()
            where T : new()
        {
            var x = new T();
        }

        public static void ClassGeneric<T>()
            where T : class, new()
        {
            var x = new T();
        }

        public static void Array()
        {
            var x = new bool[1];
        }

        public static void EmptyConstructor()
        {
            var x = new Class();
        }

        public static void ConstructorParameters()
        {
            var x = new Class("");
        }

        public static void NewStructAsParameter()
        {
            Static(new DateTime(2019, 11, 21));
        }

        public static void NewClassAsParameter()
        {
            string.IsNullOrEmpty(new string(' ', 1));
        }

        public static void NewClassToString()
        {
            new Class().ToString();
        }

        public static void CollectionInitializer()
        {
            new List<string>
            {
                "a",
                "b"
            };
        }

        public static void ArrayInitializer()
        {
            var x = new[] { "a", "b" };
        }

        public static void AnonymousClass()
        {
            var x = new { A = "a", B = "b" };
        }

        private static void Static(DateTime val)
        {
        }

        private class Class
        {
            public Class() { }
            public Class(string v) { }
        }
    }
}
