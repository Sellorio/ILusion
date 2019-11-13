namespace ILusion.Tests.Sample
{
    public static class ActionCallSamples
    {
        public static void CallStaticParameterlessMethod()
        {
            StaticParameterlessMethod();
        }

        public static void CallStaticParameterisedMethod()
        {
            StaticParameterisedMethod(5);
        }

        public static void CallInstanceParameterlessMethod()
        {
            Test.Instance.InstanceParameterlessMethod();
        }

        public static void CallInstanceParameterisedMethod()
        {
            Test.Instance.InstanceParameterisedMethod(5);
        }

        private static void StaticParameterlessMethod()
        {
        }

        private static void StaticParameterisedMethod(int parameter)
        {
        }

        private class Test
        {
            public static Test Instance => new Test();

            public void InstanceParameterlessMethod()
            {
            }

            public void InstanceParameterisedMethod(int parameter)
            {
            }
        }
    }
}
