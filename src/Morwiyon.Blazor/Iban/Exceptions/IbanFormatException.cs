using Morwiyon.Blazor.Iban.Enums;

namespace Morwiyon.Blazor.Iban.Exceptions
{
    /// <summary>
	/// Exception which is thrown, when the application attempts to convert a string to IBAN,
	/// but that the string does not have the appropriate format.
	/// Contains a field for indication which rule of validation is broken an which character
	/// in the string causes failure.
	/// </summary>
	public class IbanFormatException : Exception
    {
        public IbanFormatViolation FormatViolation { get; private set; }
        public object ExpectedObject { get; private set; }
        public object ActualObject { get; private set; }
        public BBanEntryType BBanEntryType { get; private set; }
        public char InvalidCharacter { get; private set; }

        public IbanFormatException() : base()
        { }

        public IbanFormatException(string message) : base(message)
        { }

        public IbanFormatException(string message, Exception innerException) : base(message, innerException)
        { }

        public IbanFormatException(string format, params object[] args) : base(string.Format(format, args))
        { }

        public IbanFormatException(string message, IbanFormatViolation formatViolation, Exception innerException) : base(message, innerException)
        {
            FormatViolation = formatViolation;
        }

        public IbanFormatException(string message, IbanFormatViolation formatViolation) : base(message)
        {
            FormatViolation = formatViolation;
        }

        public IbanFormatException(string message, IbanFormatViolation formatViolation, object actual, object expected) : base(message)
        {
            FormatViolation = formatViolation;
            ActualObject = actual;
            ExpectedObject = expected;
        }

        public IbanFormatException(string message, IbanFormatViolation formatViolation, object actual) : base(message)
        {
            FormatViolation = formatViolation;
            ActualObject = actual;
        }

        public IbanFormatException(string message, IbanFormatViolation formatViolation, char invalidCharacter) : base(message)
        {
            FormatViolation = formatViolation;
            InvalidCharacter = invalidCharacter;
        }

        public IbanFormatException(string message, IbanFormatViolation formatViolation, char invalidCharacter, BBanEntryType entryType, object actual) : base(message)
        {
            FormatViolation = formatViolation;
            InvalidCharacter = invalidCharacter;
            BBanEntryType = entryType;
            ActualObject = actual;
        }
    }
}
