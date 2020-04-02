using System;

namespace ILusion.Tests.Sample.ControlBlocks
{
    public static class SwitchExpressionSamples
    {
        public static void Simple(TestEnum value)
        {
            var x = value switch
            {
                TestEnum.One => "one",
                _ => string.Empty
            };
        }

        public static void WithThrow(TestEnum value)
        {
            var x = value switch
            {
                TestEnum.One => "one",
                _ => throw new InvalidOperationException()
            };
        }

        public enum TestEnum
        {
            One,
            Two,
            Three
        }
    }
}
