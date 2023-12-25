using PaySpace.Tax.Infrastructure.Enums;

namespace PaySpace.Tax.Application.Services.Interfaces
{
    public interface ITaxCalculationServiceFactory
    {
        /// <summary>
        /// Returns an Instance of <see cref="ITaxCalculationService"/> that matches <paramref name="taxType"/>
        /// </summary>
        /// <param name="taxType"></param>
        /// <exception cref="KeyNotFoundException">is thrown when postal code is not found or invalid.</exception>
        /// <returns>An instance of  <see cref="ITaxCalculationService"/> that matches the postal code provided</returns>
        ITaxCalculationService GetTaxCalculationService(TaxType taxType);
    }
}
