namespace PaySpace.Tax.Domain.Models
{
    public class TaxCalculationResult
    {
        public int Id { get; set; }

        public decimal AnnualIncome { get; set; }

        public string PostalCode { get; set; }

        public decimal CalculatedTax { get; set; }

        public DateTime CalculationDateTime { get; set; }
    }
}
