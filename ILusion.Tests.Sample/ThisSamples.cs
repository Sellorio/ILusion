namespace ILusion.Tests.Sample
{
    public class ThisClassSamples
    {
        public void ClassToVariable()
        {
            var x = this;
        }

        public void ClassToParameter()
        {
            Method(this);
        }

        private static void Method(ThisClassSamples p)
        {
        }
    }

    public struct ThisStructSamples
    {
        public void StructToVariable()
        {
            var x = this;
        }

        public void StructToParameter()
        {
            Method(this);
        }

        private static void Method(ThisStructSamples p)
        {
        }
    }
}
