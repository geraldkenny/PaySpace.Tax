using PaySpace.Tax.Infrastructure.Enums;
using PaySpace.Tax.Infrastructure.Repositories.Interfaces;

namespace PaySpace.Tax.Infrastructure.Repositories
{
    public class PostalCodeRepository : IPostalCodeRepository
    {
        private readonly IReadOnlyDictionary<string, TaxType> _postalCodeTaxTypes;// This can be replace with database access

        public PostalCodeRepository()
        {
            // Initialize or fetch valid postal codes from the database
            _postalCodeTaxTypes = new Dictionary<string, TaxType>
            {
                { "7441", TaxType.Progessive },
                { "A100", TaxType.FlatValue },
                { "7000", TaxType.FlatRate },
                { "1000", TaxType.Progessive },
            };
        }

        /// <summary>
        /// Gets a collection of valid postal codes available in the repository.
        /// </summary>
        /// <returns>An IEnumerable<string> containing valid postal codes.</returns>
        public IEnumerable<string> GetValidPostalCodes()
        {
            return _postalCodeTaxTypes.Keys;
        }

        /// <summary>
        /// Retrieves the tax type associated with the specified postal code.
        /// </summary>
        /// <param name="postalCode">The postal code for which the tax type is requested.</param>
        /// <returns>The TaxType associated with the specified postal code.</returns>
        public TaxType GetPostalCodeTaxType(string postalCode)
        {
            return _postalCodeTaxTypes[postalCode];
        }
    }
}
