namespace ILusion.Tests.Sample
{
    public static class LiteralSamples
    {
        public static void Int_Minus1()
        {
            var x = -1;
        }

        public static void Int_0()
        {
            var x = 0;
        }

        public static void Int_1()
        {
            var x = 1;
        }

        public static void Int_2()
        {
            var x = 2;
        }

        public static void Int_3()
        {
            var x = 3;
        }

        public static void Int_4()
        {
            var x = 4;
        }

        public static void Int_5()
        {
            var x = 5;
        }

        public static void Int_6()
        {
            var x = 6;
        }

        public static void Int_7()
        {
            var x = 7;
        }

        public static void Int_8()
        {
            var x = 8;
        }

        public static void Int_Small()
        {
            var x = 9;
        }

        public static void Int_LargePositive()
        {
            var x = 129;
        }

        public static void Int_VeryLargePositive()
        {
            var x = int.MaxValue;
        }

        public static void Int_LargeNegative()
        {
            var x = -129;
        }

        public static void Int_VeryLargeNegative()
        {
            var x = int.MinValue;
        }

        public static void Long()
        {
            var x = 1234567891011;
        }

        public static void Float()
        {
            var x = 12.3f;
        }

        public static void Double()
        {
            var x = 12.3;
        }

        public static void Decimal()
        {
            var x = 12.3m;
        }

        public static void String()
        {
            var x = "123";
        }

        public static void Null()
        {
            var x = (object)null;
        }

        public static void DefaultObject()
        {
            var x = default(object);
        }

        public static void DefaultString()
        {
            var x = default(string);
        }

        public static void Boolean_InVariableAssignment_True()
        {
            var x = true;
        }

        public static void Boolean_ToString_True()
        {
            true.ToString();
        }

        public static void Boolean_AsParameter_True()
        {
            Method(true);
        }

        public static bool Boolean_AsReturn_True()
        {
            return true;
        }

        public static void Boolean_SetArrayElement_True(bool[] array)
        {
            array[0] = true;
        }

        public static void Boolean_Boxed_True()
        {
            var x = (object)true;
        }

        public static void Boolean_AsConstructorParameter_True()
        {
            new decimal(0, 0, 0, true, 0);
        }

        public static void Boolean_InVariableAssignment_False()
        {
            var x = false;
        }

        public static void Boolean_ToString_False()
        {
            false.ToString();
        }

        public static void Boolean_AsParameter_False()
        {
            Method(false);
        }

        public static bool Boolean_AsReturn_False()
        {
            return false;
        }

        public static void Boolean_SetArrayElement_False(bool[] array)
        {
            array[0] = false;
        }

        public static void Boolean_Boxed_False()
        {
            var x = (object)false;
        }

        public static void Boolean_AsConstructorParameter_False()
        {
            new decimal(0, 0, 0, false, 0);
        }

        public static void Boolean_DefaultAssignment()
        {
            var x = default(bool);
        }

        private static void Method(bool value)
        {
        }

        // Boolean_InIf (TBD)
    }
}
