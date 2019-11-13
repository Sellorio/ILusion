using System;

namespace ILusion.Exceptions
{
    public class EmissionException : Exception
    {
        public EmissionException(string message)
            : base(message)
        {
        }
    }
}
