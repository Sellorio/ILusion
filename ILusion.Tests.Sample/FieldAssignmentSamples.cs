using System;

namespace ILusion.Tests.Sample
{
    public class FieldAssignmentSamples
    {
        private static string _staticClassField;
        private static DateTime _staticStructField;
        private string _instanceClassField;
        private DateTime _instanceStructField;

        public void InstanceClassFromParameter(string value)
        {
            _instanceClassField = value;
        }

        public void InstanceClassFromArray(string[] array)
        {
            _instanceClassField = array[0];
        }

        public void InstanceStructFromParameter(DateTime value)
        {
            _instanceStructField = value;
        }

        public void InstanceStructFromArray(DateTime[] array)
        {
            _instanceStructField = array[0];
        }

        public void StaticClassFromParameter(string value)
        {
            _staticClassField = value;
        }

        public void StaticClassFromArray(string[] array)
        {
            _staticClassField = array[0];
        }

        public void StaticStructFromParameter(DateTime value)
        {
            _staticStructField = value;
        }

        public void StaticStructFromArray(DateTime[] array)
        {
            _staticStructField = array[0];
        }
    }
}
