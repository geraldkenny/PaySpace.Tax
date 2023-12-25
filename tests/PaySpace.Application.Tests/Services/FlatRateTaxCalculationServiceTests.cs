using PaySpace.Tax.Application.Services;

namespace PaySpace.Tax.Application.Tests.Services
{
    [TestFixture]
    public class FlatRateTaxCalculationServiceTests
    {
        [Test]
        public void CalculateTax_ReturnsCorrectTax()
        {
            // Arrange
            var service = new FlatRateTaxCalculationService();
            var annualIncome = 50_000;

            // Act
            var tax = service.CalculateTax(annualIncome);

            // Assert
            tax.Should().Be(annualIncome * 0.175m);
        }
    }
}
