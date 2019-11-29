namespace ILusion.Tests.Sample
{
    public static class AsSamples
    {
        public static ClassA As(IInterface @interface)
        {
            return @interface as ClassA;
        }

        public interface IInterface
        {
        }

        public class ClassA : IInterface
        {
        }
    }
}
