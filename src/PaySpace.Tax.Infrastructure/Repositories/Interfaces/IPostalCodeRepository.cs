using PaySpace.Tax.Infrastructure.Enums;

namespace PaySpace.Tax.Infrastructure.Repositories.Interfaces
{
    public interface IPostalCodeRepository
    {
        IEnumerable<string> GetValidPostalCodes();

        TaxType GetPostalCodeTaxType(string postalCode);
    }
}
