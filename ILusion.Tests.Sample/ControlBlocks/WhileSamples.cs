namespace ILusion.Tests.Sample.ControlBlocks
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

        public static void AlwaysContinueAtEnd(bool condition)
        {
            while (condition)
            {
                Do();
                continue;
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

        public static void ContinueFromIf(bool c1, bool c2)
        {
            while (c1)
            {
                Do();

                if (c2)
                {
                    continue;
                }
            }
        }

        public static void ContinueFromIfWithElse(bool c1, bool c2)
        {
            while (c1)
            {
                Do();

                if (c2)
                {
                    continue;
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

        public static void ContinueFromIfInIf(bool c1, bool c2, bool c3)
        {
            while (c1)
            {
                Do();

                if (c2)
                {
                    Do();

                    if (c3)
                    {
                        continue;
                    }
                }
            }
        }

        private static void Do()
        {
        }
    }
}
