

using Morwiyon.Blazor.Iban.Enums;

namespace Morwiyon.Blazor.Iban
{
    /// <summary>
	/// Basic Bank Account Number.
	/// Class that holds a list of BBAN structures (sets of rules for BBAN string construction) for supported countries.
	/// </summary>
	public class Bban
    {
        private static SortedDictionary<string, BBanStructure> _bbanStructures;

        static Bban()
        {
            loadStructures();
        }

        /// <summary>
        /// Loads BBANs structures definitions
        /// </summary>
        private static void loadStructures()
        {
            _bbanStructures = new SortedDictionary<string, BBanStructure>
            {				
				{ "TR", new BBanStructure(BBanEntry.BankCode(5, "n"), BBanEntry.AccountNumber(17, "c")) }, // Turkey
			};
        }

        /// <summary>
        /// Search for BBAN structure of specified country
        /// </summary>
        /// <param name="countryCode">Country code object</param>
        /// <returns>BBAN structure of defined country, or null if given country code is unsupported</returns>
        public static BBanStructure GetStructureForCountry(CountryCodeEntry countryCode)
        {
            BBanStructure result = null;

            if (countryCode != null)
            {
                if (_bbanStructures.ContainsKey(countryCode.Alpha2))
                {
                    result = _bbanStructures[countryCode.Alpha2].Clone();
                }
            }

            return result;
        }

        /// <summary>
        /// Search for BBAN structure of specified country
        /// </summary>
        /// <param name="alpha2Code">Alpha2 Country code</param>
        /// <returns>BBAN structure of defined country, or null if given country code is unsupported</returns>
        public static BBanStructure GetStructureForCountry(string alpha2Code)
        {
            BBanStructure result = null;

            if (alpha2Code?.Length == 2)
            {
                if (_bbanStructures.ContainsKey(alpha2Code.ToUpper()))
                {
                    result = _bbanStructures[alpha2Code].Clone();
                }
            }

            return result;
        }

        /// <summary>
        /// Checks if specified BBAN entry is supported for given country code.
        /// </summary>
        /// <param name="alpha2Code">Alpha2 Country code</param>
        /// <param name="entryType">BBAN entry type</param>
        /// <returns>True if given country contains rule for specified entry</returns>
        public static bool IsBbanEntrySupported(string alpha2Code, BBanEntryType entryType)
        {
            BBanStructure structure = GetStructureForCountry(alpha2Code);
            bool result = false;

            if (structure != null)
            {
                result = structure.Entries.Any(x => x.EntryType == entryType);
            }

            return result;
        }
    }

    /// <summary>
    /// BBAN structure representation
    /// </summary>
    public class BBanStructure
    {
        /// <summary>
        /// List of BBAN's rules
        /// </summary>
        public List<BBanEntry> Entries { get; private set; }

        public BBanStructure(params BBanEntry[] entries)
        {
            Entries = new List<BBanEntry>(entries);
        }

        /// <summary>
        /// Length of BBAN string
        /// </summary>
        /// <returns>A number representating a length of BBAN string</returns>
        public int GetBBanLength()
        {
            int length = 0;
            foreach (BBanEntry entry in Entries)
            {
                length += entry.Length;
            }

            return length;
        }

        public BBanStructure Clone()
        {
            BBanStructure result = new BBanStructure();
            foreach (var item in Entries)
            {
                result.Entries.Add(new BBanEntry(item.EntryType, item.CharacterType, item.Length));
            }
            return result;
        }
    }

    /// <summary>
    /// Representation of BBan structure's entry (the rule)
    /// </summary>
    public class BBanEntry
    {
        public BBanEntryType EntryType { get; private set; }
        public BBanEntryCharacterType CharacterType { get; private set; }
        public int Length { get; private set; } = 0;

        internal BBanEntry(BBanEntryType entryType, BBanEntryCharacterType characterType, int length)
        {
            EntryType = entryType;
            CharacterType = characterType;
            Length = length;
        }

        public static BBanEntry BankCode(int length, string characterType) => new BBanEntry(BBanEntryType.BANK_CODE, getCharacterType(characterType), length);
        public static BBanEntry BranchCode(int length, string characterType) => new BBanEntry(BBanEntryType.BRANCH_CODE, getCharacterType(characterType), length);
        public static BBanEntry AccountNumberPrefix(int length, string characterType) => new BBanEntry(BBanEntryType.ACCOUNT_NUMBER_PREFIX, getCharacterType(characterType), length);
        public static BBanEntry AccountNumber(int length, string characterType) => new BBanEntry(BBanEntryType.ACCOUNT_NUMBER, getCharacterType(characterType), length);
        public static BBanEntry NationalCheckDigit(int length, string characterType) => new BBanEntry(BBanEntryType.NATIONAL_CHECK_DIGIT, getCharacterType(characterType), length);
        public static BBanEntry AccountType(int length, string characterType) => new BBanEntry(BBanEntryType.ACCOUNT_TYPE, getCharacterType(characterType), length);
        public static BBanEntry OwnerAccountNumber(int length, string characterType) => new BBanEntry(BBanEntryType.OWNER_ACCOUNT_NUMBER, getCharacterType(characterType), length);
        public static BBanEntry IdentificationNumber(int length, string characterType) => new BBanEntry(BBanEntryType.IDENTIFICATION_NUMBER, getCharacterType(characterType), length);
        public static BBanEntry BalanceAccountNumber(int length, string characterType) => new BBanEntry(BBanEntryType.BALANCE_ACCOUNT_NUMBER, getCharacterType(characterType), length);

        private static BBanEntryCharacterType getCharacterType(string character)
        {
            if (string.IsNullOrEmpty(character) || character.Length != 1)
            {
                throw new ArgumentException($"Value of 'character' parameter is invalid ! [{character}] ");
            }

            return (BBanEntryCharacterType)System.Enum.Parse(typeof(BBanEntryCharacterType), character, true);
        }
    }
}
