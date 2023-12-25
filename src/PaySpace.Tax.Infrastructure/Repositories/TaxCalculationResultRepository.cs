using PaySpace.Tax.Domain.Models;
using PaySpace.Tax.Infrastructure.Data;
using PaySpace.Tax.Infrastructure.Repositories.Interfaces;

namespace PaySpace.Tax.Infrastructure.Repositories
{
    public class TaxCalculationResultRepository(ApplicationDbContext dbContext) : ITaxCalculationResultRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task AddTaxCalculationResultAsync(decimal annualIncome, string postalCode, decimal calculatedTax)
        {
            var result = new TaxCalculationResult
            {
                AnnualIncome = annualIncome,
                PostalCode = postalCode,
                CalculatedTax = calculatedTax,
                CalculationDateTime = DateTime.UtcNow
            };

            _dbContext.TaxCalculationResults.Add(result);

            await _dbContext.SaveChangesAsync();
        }
    }
}
