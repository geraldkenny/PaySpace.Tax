using Microsoft.EntityFrameworkCore;
using PaySpace.Tax.Domain.Models;

namespace PaySpace.Tax.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<TaxCalculationResult> TaxCalculationResults { get; set; }
    }
}
