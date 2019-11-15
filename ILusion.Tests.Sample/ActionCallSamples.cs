namespace ILusion.Tests.Sample
{
    public class ActionCallSamples : ActionCallSamplesBase
    {
        private static TestStruct StructInstance;

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

        public override void CallBaseParameterlessMethod()
        {
            base.CallBaseParameterlessMethod();
        }

        public static void CallStructParameterlessMethodFromProperty()
        {
            TestStruct.Instance.InstanceParameterlessMethod();
        }

        public static void CallStructParameterlessMethodFromField()
        {
            StructInstance.InstanceParameterlessMethod();
        }

        public static void CallGenericParameterlessMethod()
        {
            StaticGenericMethod<int>();
        }

        public static void CallGenericClassParameterlessMethod()
        {
            GenericTest<string>.StaticGenericMethod<int>();
        }

        public static void CallMethodWithRefParameter()
        {
            var value = 1;
            StaticMethodWithRef(ref value);
        }

        public static void CallMethodWithOutParameter()
        {
            StaticMethodWithOut(out var value);
        }

        public static void CallMethodWithDiscardedOutParameter()
        {
            StaticMethodWithOut(out _);
        }
        
        public static void CallMethodWithGenericParameter()
        {
            StaticMethodWithGenericParameter(2);
        }

        public static void CallMethodWithGenericRefParameter()
        {
            var value = 2;
            StaticMethodWithGenericRefParameter(ref value);
        }

        public static void CallGenericMethodUsingGenericParameter<T>(T p)
            where T : IGenericParameter
        {
            p.Execute();
        }

        private static void StaticParameterlessMethod()
        {
        }

        private static void StaticParameterisedMethod(int parameter)
        {
        }

        private static void StaticGenericMethod<TValue>()
        {
        }

        private static void StaticMethodWithRef(ref int value)
        {
        }

        private static void StaticMethodWithOut(out int value)
        {
            value = 1;
        }

        private static void StaticMethodWithGenericParameter<T>(T p)
        {
        }

        private static void StaticMethodWithGenericRefParameter<T>(ref T p)
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

        private struct TestStruct
        {
            public static TestStruct Instance => new TestStruct();

            public void InstanceParameterlessMethod()
            {
            }
        }

        private static class GenericTest<T>
        {
            public static void StaticGenericMethod<T2>()
            {
            }
        }

        public interface IGenericParameter
        {
            void Execute();
        }
    }

    public class ActionCallSamplesBase
    {
        public virtual void CallBaseParameterlessMethod()
        {
        }
    }
}
