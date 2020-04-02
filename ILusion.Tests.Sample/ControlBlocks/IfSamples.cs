namespace ILusion.Tests.Sample.ControlBlocks
{
    public static class IfSamples
    {
        public static void WithoutElse(bool condition)
        {
            if (condition)
            {
                Method("sample");
            }
        }

        public static void WithElse(bool condition)
        {
            if (condition)
            {
                Method("true");
            }
            else
            {
                Method("false");
            }

            Method("always");
        }

        public static void InvertedCondition(bool condition)
        {
            if (!condition)
            {
                Method("true");
            }
            else
            {
                Method("false");
            }

            Method("always");
        }

        private static void Method(string value)
        {
        }
    }
}
