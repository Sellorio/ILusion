using System;

namespace ILusion.Tests.Sample
{
    public class FieldSamples
    {
        private static readonly string _staticClassField;
        private static readonly DateTime _staticStructField;
        private readonly string _instanceClassField;
        private readonly DateTime _instanceStructField;

        public void InstanceClassParameter()
        {
            Method(_instanceClassField);
        }

        public void InstanceClassToVariable()
        {
            var x = _instanceClassField;
        }

        public void InstanceStructToVariable()
        {
            var x = _instanceStructField;
        }

        public static void StaticClassParameter()
        {
            Method(_staticClassField);
        }

        public void StaticClassToVariable()
        {
            var x = _staticClassField;
        }

        public void StaticStructToVariable()
        {
            var x = _staticStructField;
        }

        private static void Method(string value)
        {
        }
    }
}
