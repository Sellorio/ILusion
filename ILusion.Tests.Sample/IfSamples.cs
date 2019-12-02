namespace ILusion.Tests.Sample
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
        }

        private static void Method(string value)
        {
        }
    }
}
