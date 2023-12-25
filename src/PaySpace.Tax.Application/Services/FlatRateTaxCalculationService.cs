using PaySpace.Tax.Application.Services.Interfaces;
using PaySpace.Tax.Infrastructure.Enums;

namespace PaySpace.Tax.Application.Services
{
    public class FlatRateTaxCalculationService : ITaxCalculationService
    {
        private const decimal _flatRatePercentage = 17.5m;

        public TaxType TaxType => TaxType.FlatRate;

        /// <summary>
        /// Calculates the tax amount based on a flat rate percentage applied to the annual income.
        /// </summary>
        /// <param name="annualIncome">The annual income for which the tax is to be calculated.</param>
        /// <returns>The calculated tax amount.</returns>
        public decimal CalculateTax(decimal annualIncome)
        {
            return annualIncome * (_flatRatePercentage / 100);
        }
    }
}
