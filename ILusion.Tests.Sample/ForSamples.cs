using System;

namespace ILusion.Tests.Sample
{
    public static class ForSamples
    {
        public static void Simple()
        {
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void PreIteration()
        {
            for (var i = 0; i < 100; ++i)
            {
                Console.WriteLine(i);
            }
        }

        public static void WithoutVariableDeclaration(int i)
        {
            for (; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void ComplexIterator()
        {
            for (string s = "s"; s.Length < 3; s = s.ToString())
            {
                Console.WriteLine(s);
            }
        }
    }
}
