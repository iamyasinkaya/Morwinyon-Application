using System.Text;

namespace Morwiyon.Blazor.Iban
{
    /// <summary>
    /// IBAN - International Bank Account Number
    /// ISO13616
    /// </summary>
    public class Iban
    {
        public string Value { get; private set; }

        private Iban(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Creates IBAN instance.
        /// Specified IBAN string undergoes validation
        /// </summary>
        /// <param name="iban"></param>
        /// <returns>A new Iban object instance</returns>
        public static Iban CreateInstance(string iban)
        {
            IbanUtils.Validate(iban);
            return new Iban(iban);
        }

        public CountryCodeEntry GetCountryCode() => CountryCode.GetCountryCode(IbanUtils.GetCountryCode(Value));

        public string GetCheckDigit() => IbanUtils.GetCheckDigit(Value);

        public string GetAccountNumber() => IbanUtils.GetAccountNumber(Value);

        public string GetAccountNumberPrefix() => IbanUtils.GetAccountNumberPrefix(Value);

        public string GetBankCode() => IbanUtils.GetBankCode(Value);

        public string GetBranchCode() => IbanUtils.GetBranchCode(Value);

        public string GetNationalCheckDigit() => IbanUtils.GetNationalCheckDigit(Value);

        public string GetAccountType() => IbanUtils.GetAccountType(Value);

        public string GetOwnerAccountType() => IbanUtils.GetOwnerAccountType(Value);

        public string GetIdentificationNumber() => IbanUtils.GetIdentificationNumber(Value);

        public string GetBalanceAccountNumber() => IbanUtils.GetBalanceAccountNumber(Value);

        public string GetBBan() => IbanUtils.GetBBan(Value);

        /// <summary>
        /// Returns formatted version of IBAN for printing
        /// </summary>
        /// <returns>Formatted string for printing</returns>
        public string ToFormattedString()
        {
            string result = "";
            StringBuilder sb = new StringBuilder(Value);
            int length = sb.Length;

            for (int i = 0; i < length / 4; i++)
            {
                sb.Insert((i + 1) * 4 + i, ' ');
            }

            result = sb.ToString().Trim();

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is Iban)
            {
                return Value.Equals((obj as Iban).Value);
            }

            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;

    }
}
