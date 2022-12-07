namespace Morwiyon.Blazor.Iban
{
    /// <summary>
    /// Business Identifier Codes (also known as SWIFT-BIC, BIC code, SWIFT ID or SWIFT code).
    /// ISO 9362
    /// </summary>
    public class Bic
    {
        public string Value { get; private set; }

        private Bic(string value)
        {
            Value = value;
        }

        /// <summary>
        /// BIC object creation
        /// </summary>
        /// <param name="bicCode">The string to be parsed as BIC code.</param>
        /// <returns>BIC object holding the value represented by the string argument.</returns>
        /// <exception cref="BicFormatException">If the string contains invalid BIC code<./exception>
        /// <exception cref="UnsupportedCountryException">If BIC's country is not supported.</exception>
        public static Bic CreateInstance(string bicCode)
        {
            BicUtils.ValidateBIC(bicCode);
            return new Bic(bicCode);
        }

        /// <summary>
        /// Bank code from the BIC
        /// </summary>
        public string BankCode => BicUtils.GetBankCode(Value);

        /// <summary>
        /// Country code from the BIC
        /// </summary>
        /// <returns>CountryCodeEntry representation of BIC's country code</returns>
        public CountryCodeEntry GetCountryCode() => CountryCode.GetCountryCode(BicUtils.GetCountryCode(Value));

        /// <summary>
        /// Location code from the BIC
        /// </summary>
        public string LocationCode => BicUtils.GetLocationCode(Value);

        /// <summary>
        /// Branch code from the BIC
        /// </summary>
        /// <returns>String represenation of the BIC's branch code, empty string if BIC has no branch code.</returns>
        public string GetBranchCode()
        {
            string result = "";

            if (BicUtils.HasBranchCode(Value))
            {
                result = BicUtils.GetBranchCode(Value);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is Bic)
            {
                return Value.Equals((obj as Bic).Value);
            }

            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }
}
