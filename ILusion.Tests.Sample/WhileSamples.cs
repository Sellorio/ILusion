namespace ILusion.Tests.Sample
{
    public static class WhileSamples
    {
        public static void Simple(bool condition)
        {
            while (condition)
            {
                Do();
            }
        }

        public static void Infinite()
        {
            while (true)
            {
                Do();
            }
        }

        public static void AlwaysBreakAtEnd(bool condition)
        {
            while (condition)
            {
                Do();
                break;
            }
        }

        public static void AlwaysReturnAtEnd(bool condition)
        {
            while (condition)
            {
                Do();
                return;
            }
        }

        public static void BreakFromIf(bool c1, bool c2)
        {
            while (c1)
            {
                Do();

                if (c2)
                {
                    break;
                }
            }
        }

        public static void BreakFromIfWithElse(bool c1, bool c2)
        {
            while (c1)
            {
                Do();

                if (c2)
                {
                    break;
                }
                else
                {
                    Do();
                }
            }
        }

        public static void WithIfElse(bool c1, bool c2)
        {
            while (c1)
            {
                Do();

                if (c2)
                {
                    Do();
                }
                else
                {
                    Do();
                }
            }
        }

        public static void BreakFromIfInIf(bool c1, bool c2, bool c3)
        {
            while (c1)
            {
                Do();

                if (c2)
                {
                    Do();

                    if (c3)
                    {
                        break;
                    }
                }
            }
        }

        private static void Do()
        {
        }
    }
}
