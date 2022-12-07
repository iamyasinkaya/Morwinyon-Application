using Morwiyon.Blazor.Iban.Enums;

namespace Morwiyon.Blazor.Iban.Exceptions
{
    /// <summary>
    /// Exception which is thrown, when the application attempts to convert a string to Bic or to validate Bic's string representation, but the
    /// string does not have the appropriate format.
    /// Contains a field for indication which rule of validation is broken.
    /// </summary>
    public class BicFormatException : Exception
    {
        public object ExpectedObject { get; private set; }
        public object ActualObject { get; private set; }
        public BicFormatViolation FormatViolation { get; private set; }

        public BicFormatException() : base()
        { }

        public BicFormatException(string message) : base(message)
        { }

        public BicFormatException(string format, params object[] args) : base(string.Format(format, args))
        { }

        public BicFormatException(string message, Exception innerException) : base(message, innerException)
        { }

        public BicFormatException(string message, BicFormatViolation violation, object actual, object expected) : base(message)
        {
            ActualObject = actual;
            ExpectedObject = expected;
            FormatViolation = violation;
        }

        public BicFormatException(string message, BicFormatViolation violation) : base(message)
        {
            FormatViolation = violation;
        }

        public BicFormatException(string message, BicFormatViolation violation, Exception innerException) : base(message, innerException)
        {
            FormatViolation = violation;
        }

        public BicFormatException(string message, BicFormatViolation violation, object actual) : base(message)
        {
            ActualObject = actual;
            FormatViolation = violation;
        }
    }
}
