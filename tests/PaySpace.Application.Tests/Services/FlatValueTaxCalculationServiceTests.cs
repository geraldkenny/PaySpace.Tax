using FluentAssertions;
using PaySpace.Tax.Application.Services;

namespace PaySpace.Tax.Application.Tests.Services
{
    [TestFixture]
    public class FlatValueTaxCalculationServiceTests
    {
        [Test]
        public void CalculateTax_LessThanLowerIncomeThreshold_ReturnsCorrectTax()
        {
            // Arrange
            var service = new FlatValueTaxCalculationService();
            var annualIncome = 150_000;

            // Act
            var tax = service.CalculateTax(annualIncome);

            // Assert
            tax.Should().Be(annualIncome * 0.05m);
        }

        [Test]
        public void CalculateTax_GreaterThanOrEqualToLowerIncomeThreshold_ReturnsFlatValueTax()
        {
            // Arrange
            var service = new FlatValueTaxCalculationService();
            var annualIncome = 250000;

            // Act
            var tax = service.CalculateTax(annualIncome);

            // Assert
            tax.Should().Be(10000);
        }
    }
}
