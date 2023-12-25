using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Tax.Infrastructure.Repositories.Interfaces
{
    public interface ITaxCalculationResultRepository
    {
        Task AddTaxCalculationResultAsync(decimal annualIncome, string postalCode, decimal calculatedTax);
    }
}
