using System;

namespace ILusion.Exceptions
{
    public class ParsingException : Exception
    {
        internal ParsingException(string message)
            : base(message)
        {
        }
    }
}
