using PaySpace.Tax.Application.Services.Interfaces;
using PaySpace.Tax.Infrastructure.Enums;

namespace PaySpace.Tax.Application.Services
{
    public class FlatValueTaxCalculationService : ITaxCalculationService
    {
        private const decimal _flatValueAmount = 10_000;
        private const decimal _lowerIncomeThreshold = 200_000;
        private const decimal _lowerIncomeTaxRate = 0.05m;

        public TaxType TaxType => TaxType.FlatValue;

        /// <summary>
        /// Calculates the tax based on the provided annual income
        /// </summary>
        /// <param name="annualIncome">The annual income for which the tax is to be calculated.</param>
        /// <returns>
        /// The calculated tax amount based on the specified rules:
        /// - If the annual income is below the lower income threshold, calculate tax using a lower income tax rate.
        /// - If the annual income is equal to or above the lower income threshold, return a flat value amount.
        /// </returns>
        public decimal CalculateTax(decimal annualIncome)
        {
            if (annualIncome < _lowerIncomeThreshold)
            {
                return annualIncome * _lowerIncomeTaxRate;
            }

            return _flatValueAmount;
        }
    }
}
