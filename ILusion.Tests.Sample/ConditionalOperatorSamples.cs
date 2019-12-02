namespace ILusion.Tests.Sample
{
    public static class ConditionalOperatorSamples
    {
        public static void Simple()
        {
            var c = true;
            var t = true;
            var f = false;

            var x = c ? t : f;
        }

        public static string CommonValues(bool condition)
        {
            return condition ? Func(2, 3) : Func(2, 3);
        }

        public static string NullTrueExpression(bool condition)
        {
            return condition ? null : Func(2, 3);
        }

        public static string NullFalseExpression(bool condition)
        {
            return condition ? Func(2, 3) : null;
        }

        private static string Func(int p1, int p2)
        {
            return p1 + "-" + p2;
        }
    }
}
