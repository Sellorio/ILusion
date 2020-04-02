using System;

namespace ILusion.Tests.Sample.ControlBlocks
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

        public static void OneSwitchClumpWithGap(int value)
        {
            switch (value)
            {
                case -2:
                    Console.WriteLine("-2");
                    break;
                case -1:
                    Console.WriteLine("-1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
            }
        }

        public static void OneSwitchClumpWithGapAndDefault(int value)
        {
            switch (value)
            {
                case -2:
                    Console.WriteLine("-2");
                    break;
                case -1:
                    Console.WriteLine("-1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                default:
                    Console.WriteLine("DefaultBody");
                    break;
            }

            Console.WriteLine("After Switch");
        }

        public static void FallthroughFromCaseToCase(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("0");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                case 1:
                case 3:
                    Console.WriteLine("3");
                    break;
            }
        }

        public static void FallthroughFromCaseToDefault(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("0");
                    break;
                case 1:
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                case 3:
                default:
                    Console.WriteLine("DefaultBody");
                    break;
            }

            Console.WriteLine("After Switch");
        }

        public static void TwoSwitchClumps(int value)
        {
            switch (value)
            {
                case -3:
                    Console.WriteLine("-3");
                    break;
                case -2:
                    Console.WriteLine("-2");
                    break;
                case -1:
                    Console.WriteLine("-1");
                    break;
                case 6:
                    Console.WriteLine("6");
                    break;
                case 7:
                    Console.WriteLine("7");
                    break;
                case 8:
                    Console.WriteLine("8");
                    break;
            }
        }

        public static void TwoSwitchClumpsWithDefault(int value)
        {
            switch (value)
            {
                case -3:
                    Console.WriteLine("-3");
                    break;
                case -2:
                    Console.WriteLine("-2");
                    break;
                case -1:
                    Console.WriteLine("-1");
                    break;
                case 6:
                    Console.WriteLine("6");
                    break;
                case 7:
                    Console.WriteLine("7");
                    break;
                case 8:
                    Console.WriteLine("8");
                    break;
                default:
                    Console.WriteLine("DefaultBody");
                    break;
            }

            Console.WriteLine("After Switch");
        }

        public static void EnumSwitchClump(Test value)
        {
            switch (value)
            {
                case Test.One:
                    Console.WriteLine("Luv");
                    break;
                case Test.Two:
                    Console.WriteLine("One");
                    break;
                case Test.Three:
                    Console.WriteLine("Two");
                    break;
            }
        }

        public static void IntegerBranchClumpsWithZeroClump(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("0");
                    break;
                case 1:
                    Console.WriteLine("1");
                    break;
            }
        }

        public static void OneIntegerBranchClump(int value)
        {
            switch (value)
            {
                case 1:
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
            }
        }

        public static void MultipleIntegerBranchClumps(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("0");
                    break;
                case 1:
                    Console.WriteLine("1");
                    break;
                case 6:
                    Console.WriteLine("6");
                    break;
                case 7:
                    Console.WriteLine("7");
                    break;
            }
        }

        public static void MultipleIntegerBranchClumpsWithDefault(int value)
        {
            switch (value)
            {
                case 0:
                    Console.WriteLine("0");
                    break;
                case 1:
                    Console.WriteLine("1");
                    break;
                case 6:
                    Console.WriteLine("6");
                    break;
                case 7:
                    Console.WriteLine("7");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }

        public static void MultipleEnumBranchClumps(Test value)
        {
            switch (value)
            {
                case Test.One:
                    Console.WriteLine("0");
                    break;
                case Test.Two:
                    Console.WriteLine("1");
                    break;
                case Test.Seven:
                    Console.WriteLine("6");
                    break;
                case Test.Eight:
                    Console.WriteLine("7");
                    break;
            }
        }

        public static void FloatBranchClump(float value)
        {
            switch (value)
            {
                case 0.0f:
                    Console.WriteLine("0.0f");
                    break;
                case 1.0f:
                    Console.WriteLine("1.0f");
                    break;
                case 2.0f:
                    Console.WriteLine("2.0f");
                    break;
            }
        }

        public static void DoubleBranchClump(double value)
        {
            switch (value)
            {
                case 0.0:
                    Console.WriteLine("0.0");
                    break;
                case 1.0:
                    Console.WriteLine("1.0");
                    break;
                case 2.0:
                    Console.WriteLine("2.0");
                    break;
            }
        }

        public static void DoubleBranchClumpWithFloatCases(double value)
        {
            switch (value)
            {
                case 0.0f:
                    Console.WriteLine("0.0f");
                    break;
                case 1.0f:
                    Console.WriteLine("1.0f");
                    break;
                case 2.0f:
                    Console.WriteLine("2.0f");
                    break;
            }
        }

        public static void FloatBranchClumpWithFallthrough(float value)
        {
            switch (value)
            {
                case 0.0f:
                    Console.WriteLine("0.0f");
                    break;
                case 2.0f:
                    Console.WriteLine("2.0f");
                    break;
                case 1.0f:
                case 3.0f:
                    Console.WriteLine("3.0f");
                    break;
            }
        }

        public static void DecimalBranchClump(decimal value)
        {
            switch (value)
            {
                case -2:
                    Console.WriteLine("-2");
                    break;
                case -1.1M:
                    Console.WriteLine("-1.1M");
                    break;
                case 0.0M:
                    Console.WriteLine("0.0M");
                    break;
                case 1.1M:
                    Console.WriteLine("1.1M");
                    break;
                case 3:
                    Console.WriteLine("3");
                    break;
            }
        }

        public static void StringBranchClump(string value)
        {
            switch (value)
            {
                case "Zero":
                    Console.WriteLine("0");
                    break;
                case "One":
                    Console.WriteLine("1");
                    break;
                case "Two":
                    Console.WriteLine("2");
                    break;
            }
        }

        public static void StringBranchClumpWithDefault(string value)
        {
            switch (value)
            {
                case "Zero":
                    Console.WriteLine("0");
                    break;
                case "One":
                    Console.WriteLine("1");
                    break;
                case "Two":
                    Console.WriteLine("2");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }

        public static void StringBranchClumpWithNull(string value)
        {
            switch (value)
            {
                case null:
                    Console.WriteLine("null");
                    break;
                case "Zero":
                    Console.WriteLine("0");
                    break;
                case "One":
                    Console.WriteLine("1");
                    break;
                case "Two":
                    Console.WriteLine("2");
                    break;
            }
        }

        public static void StringBranchClumpWithNullFallthrough(string value)
        {
            switch (value)
            {
                case null:
                case "Zero":
                    Console.WriteLine("0");
                    break;
                case "One":
                    Console.WriteLine("1");
                    break;
                case "Two":
                    Console.WriteLine("2");
                    break;
            }
        }

        public static void TypeBranchClump(object value)
        {
            switch (value)
            {
                case string str:
                    Console.WriteLine(str);
                    break;
                case Exception _:
                    Console.WriteLine("class without variable");
                    break;
                case byte by:
                    Console.WriteLine(by);
                    break;
                case int _:
                    Console.WriteLine("value without variable");
                    break;
            }
        }

        public static void TypeBranchClumpWithNoVariables(object value)
        {
            switch (value)
            {
                case string _:
                    Console.WriteLine("string");
                    break;
                case Exception _:
                    Console.WriteLine("Exception");
                    break;
                case int _:
                    Console.WriteLine("int");
                    break;
            }
        }

        public static void TypeBranchClumpWithValueTypeFirst(object value)
        {
            switch (value)
            {
                case byte by:
                    Console.WriteLine(by);
                    break;
                case int _:
                    Console.WriteLine("value without variable");
                    break;
                case string str:
                    Console.WriteLine(str);
                    break;
                case Exception _:
                    Console.WriteLine("class without variable");
                    break;
            }
        }

        public static void TypeBranchClumpWithValueTypeFirstAndNoVariables(object value)
        {
            switch (value)
            {
                case int _:
                    Console.WriteLine("int");
                    break;
                case string _:
                    Console.WriteLine("string");
                    break;
                case Exception _:
                    Console.WriteLine("Exception");
                    break;
            }
        }

        public static void TypeBranchClumpWithDefault(object value)
        {
            switch (value)
            {
                case string str:                // class with variable
                    Console.WriteLine(str);
                    break;
                case Exception _:               // class without variable
                    Console.WriteLine("class without variable");
                    break;
                case byte by:
                    Console.WriteLine(by);
                    break;
                case int _:                     // value without variable
                    Console.WriteLine("value without variable");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }

        public static void TypeBranchClumpWithGeneric<T>(object value)
        {
            switch (value)
            {
                case string str:
                    Console.WriteLine(str);
                    break;
                case Exception _:
                    Console.WriteLine("class without variable");
                    break;
                case T _:
                    Console.WriteLine("generic");
                    break;
            }
        }

        public static void TypeBranchClumpWithGenericAndVariable<T>(object value)
        {
            switch (value)
            {
                case string str:
                    Console.WriteLine(str);
                    break;
                case Exception _:
                    Console.WriteLine("class without variable");
                    break;
                case T rick:
                    Console.WriteLine(rick);
                    break;
            }
        }

        public static void TypeBranchClumpWithClassGeneric<T>(object value)
            where T : class
        {
            switch (value)
            {
                case string str:
                    Console.WriteLine(str);
                    break;
                case Exception _:
                    Console.WriteLine("class without variable");
                    break;
                case T _:
                    Console.WriteLine("generic");
                    break;
            }
        }

        public static void TypeBranchClumpWithClassGenericAndVariable<T>(object value)
            where T : class
        {
            switch (value)
            {
                case string str:
                    Console.WriteLine(str);
                    break;
                case Exception _:
                    Console.WriteLine("class without variable");
                    break;
                case T rick:
                    Console.WriteLine(rick);
                    break;
            }
        }

        public static void TypeBranchClumpWithStructGeneric<T>(object value)
            where T : struct
        {
            switch (value)
            {
                case string str:
                    Console.WriteLine(str);
                    break;
                case Exception _:
                    Console.WriteLine("class without variable");
                    break;
                case T _:
                    Console.WriteLine("generic");
                    break;
            }
        }

        public static void TypeBranchClumpWithStructGenericAndVariable<T>(object value)
            where T : struct
        {
            switch (value)
            {
                case string str:
                    Console.WriteLine(str);
                    break;
                case Exception _:
                    Console.WriteLine("class without variable");
                    break;
                case T rick:
                    Console.WriteLine(rick);
                    break;
            }
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
