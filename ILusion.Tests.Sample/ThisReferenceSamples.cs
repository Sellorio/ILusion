namespace ILusion.Tests.Sample
{
    public class ThisReferenceClassSamples
    {
        public void ClassToOut(out ThisReferenceClassSamples result)
        {
            result = this;
        }
    }

    public struct ThisReferenceStructSamples
    {
        public void StructToOut(out ThisReferenceStructSamples result)
        {
            result = this;
        }

        public void StructMethodCall()
        {
            ToString();
        }
    }
}
