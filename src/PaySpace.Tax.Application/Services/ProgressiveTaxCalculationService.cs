using PaySpace.Tax.Application.Services.Interfaces;
using PaySpace.Tax.Infrastructure.Enums;

namespace PaySpace.Tax.Application.Services
{
    public class ProgressiveTaxCalculationService : ITaxCalculationService
    {
        public TaxType TaxType { get; } = TaxType.Progessive;

        /// <summary>
        /// Calculates the tax based on the given annual income using a progressive tax rate.
        /// </summary>
        /// <param name="annualIncome">The annual income for which the tax is to be calculated.</param>
        /// <returns>The calculated tax amount.</returns>
        public decimal CalculateTax(decimal annualIncome)
        {
            decimal calculatedTax = 0;

            switch (annualIncome)
            {
                case >= 0 and <= 8350:
                    calculatedTax = CalculatePercentage(annualIncome, 10);
                    break;
                case > 8350 and <= 33950:
                    calculatedTax = CalculatePercentage(annualIncome, 15);
                    break;
                case > 33950 and <= 82250:
                    calculatedTax = CalculatePercentage(annualIncome, 25);
                    break;
                case > 82250 and <= 171550:
                    calculatedTax = CalculatePercentage(annualIncome, 28);
                    break;
                case > 171550 and <= 372950:
                    calculatedTax = CalculatePercentage(annualIncome, 33);                 
                    break;
                case > 372950:
                    calculatedTax = CalculatePercentage(annualIncome, 35);
                    break;
            }
            return calculatedTax;
        }

        public static decimal CalculatePercentage(decimal value, int percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage),"Percentage should be between 0 and 100.");
            }

            return value * percentage / 100;
        }
    }
}
