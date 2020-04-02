using System;

namespace ILusion.Tests.Sample.ControlBlocks
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

        public static void AlwaysBreakAtEnd(bool condition)
        {
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                break;
            }
        }

        public static void AlwaysContinueAtEnd(bool condition)
        {
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                continue;
            }
        }

        public static void AlwaysReturnAtEnd(bool condition)
        {
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                return;
            }
        }

        public static void BreakFromIf(bool c2)
        {
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(i);

                if (c2)
                {
                    break;
                }
            }
        }

        public static void BreakFromIfWithElse(bool c2)
        {
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(i);

                if (c2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void ContinueFromIf(bool c2)
        {
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(i);

                if (c2)
                {
                    continue;
                }
            }
        }

        public static void ContinueFromIfWithElse(bool c2)
        {
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(i);

                if (c2)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
