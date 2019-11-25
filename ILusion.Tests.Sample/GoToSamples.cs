namespace ILusion.Tests.Sample
{
    public static class GoToSamples
    {
        // for some reason the label itself produces a br.s instruction.
        public static void GoTo()
        {
        test:
            return;
        }
    }
}
