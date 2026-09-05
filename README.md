# DreamersCode.Utilities.Lookups.Countries

## Introduction 
A .Net lib that offers a lists of all the countries as per ISO-3166 in a handy lookup mode.

# Getting Started
## How To Use
1. Download the package from Nuget.org (Package name: DreamersCode.Utilities.Lookups.Countries)
2. The static class "CountryCollection" offers up a property "AllCountries" which allows you to enumerate through all the countries or filter using LINQ.
    1. **.Net 8**: The list defaults to a FrozenSet that prioritises read speed for faster queries
    2. **.Net Standard 2.0 & 2.1**: The list defaults to IReadOnlyList    

# Example usage:
```
    var result = CountryCollection.AllCountries.SingleOrDefault(x => x.ThreeLetterCode.Equals("MLT", StringComparison.OrdinalIgnoreCase));
    Console.WriteLine($"Country Name In English {result.CountryNames.Single(x => x.LanguageCode.Equals("eng", StringComparison.OrdinalIgnoreCase))}");
    Console.WriteLine($"Country Three Letter Code --> {result.ThreeLetterCode}");
    Console.WriteLine($"Country Two Letter Code --> {result.TwoLetterCode}");
    Console.WriteLine($"Country Numeric Code --> {result.NumericCodeAsString}");
```

# Release Notes
Version 3.0.0 (Rel Date: 05/09/2026)
- Moved from Azure Devops to GitHub
- Dropped support for .Net 4.62 (replaced with DN Standard 2.0)

Version 2.1.1 (Rel Date: 17/02/2024)
- Added support for .Net 4.62
- Updated url to new package location

Version 2.1.0 (Rel Date: 15/12/2023)
- Changed to match other packages with display values
- Updated readme with example to match with other packages

Version 2.0.2 (Rel Date: 10/02/2024)
- Issues with readme fixed

Version 2.0.0 (Rel Date: 19/12/2023)
- Initial Version

# Contribute
Feel free to send any feedback or suggestions to suggestions@dreamerscode.com