namespace Morwiyon.Blazor.Iban.Exceptions
{
    /// <summary>
    /// Exception whis is thrown, when the requested country is not supported
    /// </summary>
    public class UnsupportedCountryException : Exception
    {
        public string CountryCode { get; private set; }

        public UnsupportedCountryException() : base()
        { }

        public UnsupportedCountryException(string message) : base(message)
        { }

        public UnsupportedCountryException(string message, string countryCode) : base(message)
        {
            CountryCode = countryCode;
        }

        public UnsupportedCountryException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}
