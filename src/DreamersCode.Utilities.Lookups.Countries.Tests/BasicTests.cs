using DreamersCode.Utilities.Lookups.Countries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DreamersCode.Utilities.Lookups.Countries.Tests
{
    [TestClass]
    public class BasicTests
    {                        
        [TestMethod]
        public void FetchOneCountry()
        {
            var result = CountryCollection.AllCountries.SingleOrDefault(x => x.ThreeLetterCode == "MLT");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FetchOneCountryNumericCodeIsThreeCharacters()
        {
            var result = CountryCollection.AllCountries.SingleOrDefault(x => x.ThreeLetterCode == "MLT");
            Assert.IsNotNull(result);            
            Assert.AreEqual(3, result.NumericCodeAsString.Length);
        }


        [TestMethod]
        public void FetchMoreThenOneCountry()
        {
            var result = CountryCollection.AllCountries.Where(x => x.NumericCode > 700);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.IsGreaterThan(1, result.Count());
        }
        // Additional Tests for Comprehensive Coverage

        [TestMethod]
        public void AllCountriesNotNull()
        {
            Assert.IsNotNull(CountryCollection.AllCountries);
        }

        [TestMethod]
        public void AllCountriesNotEmpty()
        {
            Assert.IsNotEmpty(CountryCollection.AllCountries);
        }

        [TestMethod]
        public void AllCountriesCountIsValid()
        {
            // ISO 3166-1 has approximately 249 entries
            Assert.IsGreaterThan(200, CountryCollection.AllCountries.Count);
        }

        [TestMethod]
        public void FetchCountryByTwoLetterCode()
        {
            var result = CountryCollection.AllCountries.SingleOrDefault(x => x.TwoLetterCode == "US");
            Assert.IsNotNull(result);
            Assert.AreEqual("USA", result.ThreeLetterCode);
        }

        [TestMethod]
        public void FetchCountryByNumericCode()
        {
            var result = CountryCollection.AllCountries.SingleOrDefault(x => x.NumericCode == 840);
            Assert.IsNotNull(result);
            Assert.AreEqual("US", result.TwoLetterCode);
        }

        [TestMethod]
        public void TwoLetterCodesAreNotNull()
        {
            var nullTwoLetterCodes = CountryCollection.AllCountries.Where(x => string.IsNullOrEmpty(x.TwoLetterCode));
            Assert.IsEmpty(nullTwoLetterCodes);
        }

        [TestMethod]
        public void ThreeLetterCodesAreNotNull()
        {
            var nullThreeLetterCodes = CountryCollection.AllCountries.Where(x => string.IsNullOrEmpty(x.ThreeLetterCode));
            Assert.IsEmpty(nullThreeLetterCodes);
        }

        [TestMethod]
        public void TwoLetterCodesAreExactlyTwoCharacters()
        {
            var invalidCodes = CountryCollection.AllCountries.Where(x => x.TwoLetterCode.Length != 2);
            Assert.IsEmpty(invalidCodes);
        }

        [TestMethod]
        public void ThreeLetterCodesAreExactlyThreeCharacters()
        {
            var invalidCodes = CountryCollection.AllCountries.Where(x => x.ThreeLetterCode.Length != 3);
            Assert.IsEmpty(invalidCodes);
        }

        [TestMethod]
        public void NumericCodesArePositive()
        {
            var negativeOrZero = CountryCollection.AllCountries.Where(x => x.NumericCode <= 0);
            Assert.IsEmpty(negativeOrZero);
        }

        [TestMethod]
        public void NumericCodeAsStringIsPadded()
        {
            var countryWithSingleDigitCode = CountryCollection.AllCountries.SingleOrDefault(x => x.NumericCode == 4);
            Assert.IsNotNull(countryWithSingleDigitCode);
            Assert.AreEqual("004", countryWithSingleDigitCode.NumericCodeAsString);
        }

        [TestMethod]
        public void AllCountriesHaveDisplayNames()
        {
            var countriesWithoutNames = CountryCollection.AllCountries.Where(x => x.CountryNames == null || x.CountryNames.Count == 0);
            Assert.IsEmpty(countriesWithoutNames);
        }

        [TestMethod]
        public void NoCountriesDuplicatedByTwoLetterCode()
        {
            var twoLetterCodes = CountryCollection.AllCountries.GroupBy(x => x.TwoLetterCode);
            var duplicates = twoLetterCodes.Where(g => g.Count() > 1);
            Assert.IsEmpty(duplicates);
        }

        [TestMethod]
        public void NoCountriesDuplicatedByThreeLetterCode()
        {
            var threeLetterCodes = CountryCollection.AllCountries.GroupBy(x => x.ThreeLetterCode);
            var duplicates = threeLetterCodes.Where(g => g.Count() > 1);
            Assert.IsEmpty(duplicates);
        }

        [TestMethod]
        public void NoCountriesDuplicatedByNumericCode()
        {
            var numericCodes = CountryCollection.AllCountries.GroupBy(x => x.NumericCode);
            var duplicates = numericCodes.Where(g => g.Count() > 1);
            Assert.IsEmpty(duplicates);
        }

        [TestMethod]
        public void AllCountriesCaseConsistency()
        {
            // Verify two-letter codes are uppercase
            var invalidTwoLetterCases = CountryCollection.AllCountries.Where(x => x.TwoLetterCode != x.TwoLetterCode.ToUpperInvariant());
            Assert.IsEmpty(invalidTwoLetterCases);

            // Verify three-letter codes are uppercase
            var invalidThreeLetterCases = CountryCollection.AllCountries.Where(x => x.ThreeLetterCode != x.ThreeLetterCode.ToUpperInvariant());
            Assert.IsEmpty(invalidThreeLetterCases);
        }

        [TestMethod]
        public void CountryMaltaHasExpectedProperties()
        {
            var malta = CountryCollection.AllCountries.SingleOrDefault(x => x.ThreeLetterCode == "MLT");
            Assert.IsNotNull(malta);
            Assert.AreEqual("MT", malta.TwoLetterCode);
            Assert.AreEqual((short)470, malta.NumericCode);
            Assert.AreEqual("470", malta.NumericCodeAsString);
        }

        [TestMethod]
        public void CanSearchMultipleCountriesByCriteria()
        {
            var europeanCountries = CountryCollection.AllCountries.Where(x => x.NumericCode > 200 && x.NumericCode < 900).ToList();
            Assert.IsGreaterThan(5, europeanCountries.Count);
        }

        [TestMethod]
        public void AllCountriesReadOnly()
        {
            var result = CountryCollection.AllCountries;
            Assert.IsNotNull(result);
            // Verify it's a read-only collection by checking the type
            Assert.IsTrue(((((result is System.Collections.Generic.IReadOnlyCollection<Models.Country>)))));
        }
    }
}
