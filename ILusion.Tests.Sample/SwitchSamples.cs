using System;

namespace ILusion.Tests.Sample
{
    public static class SwitchSamples
    {
        public static void OneSwitchClump(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("Luv");
                    break;
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
            }
        }

        public static void OneSwitchClumpPositiveOffset(int value)
        {
            switch (value)
            {
                case 3:
                    Console.WriteLine("Luv");
                    break;
                case 4:
                    Console.WriteLine("One");
                    break;
                case 5:
                    Console.WriteLine("Two");
                    break;
            }
        }

        public static void OneSwitchClumpNegativeOffset(int value)
        {
            switch (value)
            {
                case -2:
                    Console.WriteLine("Luv");
                    break;
                case -1:
                    Console.WriteLine("One");
                    break;
                case 0:
                    Console.WriteLine("Two");
                    break;
            }
        }

        public static void OneSwitchClumpWithDefault(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("Luv");
                    break;
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                default:
                    Console.WriteLine("DefaultBody");
                    break;
            }
        }

        public static string OneSwitchClumpWithReturns(int value)
        {
            switch (value)
            {
                case 0:
                    return "Luv";
                case 1:
                    return "One";
                case 2:
                    return "Two";
            }

            return "Fallback";
        }

        public static string OneSwitchClumpWithReturnsAndDefault(int value)
        {
            switch (value)
            {
                case 0:
                    return "Luv";
                case 1:
                    return "One";
                case 2:
                    return "Two";
                default:
                    return "Default";
            }
        }

        public static string OneSwitchClumpWithReturnsAndBreaks(int value)
        {
            switch (value)
            {
                case 0:
                    return "Luv";
                case 1:
                    break;
                case 2:
                    return "Two";
            }

            return "Fallback";
        }

        public static void OneSwitchClumpWithGoToCase(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("Luv");
                    break;
                case 1:
                    Console.WriteLine("One");
                    goto case 2;
                case 2:
                    Console.WriteLine("Two");
                    break;
            }
        }

        public static void OneSwitchClumpWithGoToCurrentCase(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("Luv");
                    break;
                case 1:
                    Console.WriteLine("One");
                    goto case 1;
                case 2:
                    Console.WriteLine("Two");
                    break;
            }
        }

        public static void OneSwitchClumpWithGoToDefault(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("Luv");
                    goto default;
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }

        public static void OneSwitchClumpWithGoToDefaultInDefault(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("Luv");
                    break;
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                default:
                    Console.WriteLine("Default");
                    goto default;
            }
        }

        public static void OneSwitchClumpWithGoTos(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("Luv");
                    goto blog;
                case 1:
                    Console.WriteLine("One");
                    goto bongo;
                case 2:
                    Console.WriteLine("Two");
                    goto boogy;
                default:
                    Console.WriteLine("DefaultBody");
                    goto bongo;
            }

        blog:
            Console.WriteLine("Blog");

        boogy:
            Console.WriteLine("Boogy");

        bongo:
            Console.WriteLine("Bongo");
        }

        public enum Test
        {
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten
        }
    }
}
