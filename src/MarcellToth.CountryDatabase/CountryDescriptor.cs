namespace MarcellToth.CountryDatabase
{
    /// <summary>
    ///     Stores information about a country.
    /// </summary>
    public class CountryDescriptor
    {
        /// <summary>
        ///     The official name of the country in English.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The ISO 3166-1 alpha-2 code of the country.
        /// </summary>
        public string Alpha2Code { get; }

        /// <summary>
        ///     The ISO 3166-1 alpha-3 code of the country.
        /// </summary>
        public string Alpha3Code { get; }

        /// <summary>
        ///     Initializes a <see cref="CountryDescriptor" /> with the given data.
        /// </summary>
        /// <param name="name">The english name of the country.</param>
        /// <param name="alpha2Code">The alpha-2 code of the country.</param>
        /// <param name="alpha3Code">The alpha-3 code of the country.</param>
        public CountryDescriptor(string name, string alpha2Code, string alpha3Code)
        {
            Name = name;
            Alpha2Code = alpha2Code;
            Alpha3Code = alpha3Code;
        }
    }
}