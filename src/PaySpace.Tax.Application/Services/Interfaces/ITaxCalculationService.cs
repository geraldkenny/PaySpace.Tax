using PaySpace.Tax.Infrastructure.Enums;

namespace PaySpace.Tax.Application.Services.Interfaces
{
    public interface ITaxCalculationService
    {
        TaxType TaxType { get; }

        decimal CalculateTax(decimal annualIncome);
    }
}
