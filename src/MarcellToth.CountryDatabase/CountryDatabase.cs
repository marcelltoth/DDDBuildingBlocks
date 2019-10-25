using System.Collections.Generic;
using System.Linq;

namespace MarcellToth.CountryDatabase
{
    /// <summary>
    ///     Database of the known countries of the world.
    /// </summary>
    public static partial class CountryDatabase
    {
        /// <summary>
        ///     A dictionary of all countries in the database keyed by their alpha-2 code.
        /// </summary>
        public static IReadOnlyDictionary<string, CountryDescriptor> CountriesByAlpha2Code { get; }
        
        /// <summary>
        ///     A dictionary of all countries in the database keyed by their alpha-3 code.
        /// </summary>
        public static IReadOnlyDictionary<string, CountryDescriptor> CountriesByAlpha3Code { get; }
        
        static CountryDatabase()
        {
            CountriesByAlpha2Code = AllCountries.ToDictionary(c => c.Alpha2Code, c => c);
            
            CountriesByAlpha3Code = AllCountries.ToDictionary(c => c.Alpha3Code, c => c);
        }
    }
}