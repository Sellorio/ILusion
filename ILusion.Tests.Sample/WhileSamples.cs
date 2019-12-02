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

        public static void Break(bool condition)
        {
            while (condition)
            {
                Do();
                break;
            }
        }

        private static void Do()
        {
        }
    }
}
