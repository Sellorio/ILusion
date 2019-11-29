namespace ILusion.Tests.Sample
{
    public static class IsSamples
    {
        public static bool WithoutVariable(object value)
        {
            return value is string;
        }

        public static bool WithVariable(object value)
        {
            return value is string str;
        }
    }
}
