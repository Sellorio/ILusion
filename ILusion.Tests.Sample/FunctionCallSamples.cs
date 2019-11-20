namespace ILusion.Tests.Sample
{
    public class FunctionCallSamples : FunctionCallSamplesBase
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

        public override string CallBaseParameterlessMethod()
        {
            return base.CallBaseParameterlessMethod();
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

        private static string StaticParameterlessMethod()
        {
            return null;
        }

        private static string StaticParameterisedMethod(int parameter)
        {
            return null;
        }

        private static string StaticGenericMethod<TValue>()
        {
            return null;
        }

        private static string StaticMethodWithRef(ref int value)
        {
            return null;
        }

        private static string StaticMethodWithOut(out int value)
        {
            value = 1;
            return null;
        }

        private static string StaticMethodWithGenericParameter<T>(T p)
        {
            return null;
        }

        private static string StaticMethodWithGenericRefParameter<T>(ref T p)
        {
            return null;
        }

        private class Test
        {
            public static Test Instance => new Test();

            public string InstanceParameterlessMethod()
            {
                return null;
            }

            public string InstanceParameterisedMethod(int parameter)
            {
                return null;
            }
        }

        private struct TestStruct
        {
            public static TestStruct Instance => new TestStruct();

            public string InstanceParameterlessMethod()
            {
                return null;
            }
        }

        private static class GenericTest<T>
        {
            public static string StaticGenericMethod<T2>()
            {
                return null;
            }
        }

        public interface IGenericParameter
        {
            string Execute();
        }
    }

    public class FunctionCallSamplesBase
    {
        public virtual string CallBaseParameterlessMethod()
        {
            return null;
        }
    }
}
