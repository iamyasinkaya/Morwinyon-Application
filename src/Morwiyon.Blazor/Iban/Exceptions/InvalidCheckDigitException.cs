namespace Morwiyon.Blazor.Iban.Exceptions
{
    /// <summary>
    /// Exception which is thrown to indicate that IBAN's check digit is invalid.
    /// </summary>
    public class InvalidCheckDigitException : Exception
    {
        public string ActualString { get; private set; }
        public string ExpectedString { get; private set; }

        public InvalidCheckDigitException() : base()
        { }

        public InvalidCheckDigitException(string message) : base(message)
        { }

        public InvalidCheckDigitException(string message, Exception innerException) : base(message, innerException)
        { }

        public InvalidCheckDigitException(string format, params object[] args) : base(string.Format(format, args))
        { }

        public InvalidCheckDigitException(string message, string expected, string actual) : base(message)
        {
            ActualString = actual;
            ExpectedString = expected;
        }
    }
}
