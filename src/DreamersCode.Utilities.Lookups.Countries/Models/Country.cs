#if NET8_0_OR_GREATER
using System.Collections.Frozen;
#endif
using System.Collections.Generic;

namespace DreamersCode.Utilities.Lookups.Countries.Models
{
    /// <summary>
    /// Provides display information for the given language
    /// </summary>
    public readonly struct DisplayInfo
    {
        /// <summary>
        /// The Three letter code representing language code (based on the ISO-639-2)
        /// </summary>
        public string LanguageCode { get; }

        /// <summary>
        /// The way the record needs to be displayed for the given language
        /// </summary>
        public string DisplayValue { get;}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="langCode">The Three letter code representing language code (based on the ISO-639-2)</param>
        /// <param name="displayValue">The way the record needs to be displayed for the given language</param>
        public DisplayInfo(string langCode, string displayValue)
        {
            LanguageCode = langCode;
            DisplayValue = displayValue;
        }

    }


    /// <summary>
    /// Model representation of a country as per ISO 3166
    /// </summary>
    public record Country
    {        
        /// <summary>
        /// two-letter country codes which are the most widely used (ISO 3166-1 alpha-2 )
        /// </summary>
        public string TwoLetterCode { get; private set; }

        /// <summary>
        /// ISO 3166-1 alpha-3 – three-letter country codes which allow a better visual association between the codes and the country names
        /// </summary>
        public string ThreeLetterCode { get; private set; }

        /// <summary>
        /// ISO 3166-1 numeric – three-digit country codes which are identical to those developed and maintained by the United Nations Statistics Division, 
        /// with the advantage of script (writing system) independence, and hence useful for people or systems using non-Latin scripts
        /// In this case, the numeric value is padded to adhere to the 3 digit standard
        /// </summary>
        public string NumericCodeAsString { get { return NumericCode.ToString("000"); } }

        /// <summary>
        /// ISO 3166-1 numeric – three-digit country codes which are identical to those developed and maintained by the United Nations Statistics Division, 
        /// with the advantage of script (writing system) independence, and hence useful for people or systems using non-Latin scripts.
        /// </summary>
        public short NumericCode { get; private set; }

#if NET8_0_OR_GREATER
        /// <summary>
        /// The names of the language for a given language code.  English is always present, other languages might be missing
        /// </summary>
        public FrozenSet<DisplayInfo> CountryNames { get; private set; }
#else
        /// <summary>
        /// The names of the language for a given language code.  English is always present, other languages might be missing
        /// </summary>
        public IReadOnlyCollection<DisplayInfo> CountryNames{ get; private set; }
#endif

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="countryNames"></param>
        /// <param name="twoLetterCode"></param>
        /// <param name="threeLetterCode"></param>
        /// <param name="numericCode"></param>
        public Country(List<DisplayInfo> countryNames, string twoLetterCode, string threeLetterCode, short numericCode)
        {            
            if (string.IsNullOrEmpty(twoLetterCode))
            {
                throw new System.ArgumentException($"'{nameof(twoLetterCode)}' cannot be null or empty.", nameof(twoLetterCode));
            }

            if (string.IsNullOrEmpty(threeLetterCode))
            {
                throw new System.ArgumentException($"'{nameof(threeLetterCode)}' cannot be null or empty.", nameof(threeLetterCode));
            }
            
            TwoLetterCode = twoLetterCode;
            ThreeLetterCode = threeLetterCode;
            NumericCode = numericCode;

#if NET8_0_OR_GREATER
            CountryNames = countryNames.ToFrozenSet();
#else
            CountryNames = countryNames;
#endif
        }

    }
}
