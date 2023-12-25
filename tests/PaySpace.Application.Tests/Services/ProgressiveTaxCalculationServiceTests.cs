using PaySpace.Tax.Application.Services;

namespace PaySpace.Tax.Application.Tests.Services
{
    [TestFixture]
    public class ProgressiveTaxCalculationServiceTests
    {
        [Test]
        [TestCase(8000, ExpectedResult = 800, TestName = "10% Tax Rate")]
        [TestCase(30000, ExpectedResult = 4500, TestName = "15% Tax Rate")]
        [TestCase(70000, ExpectedResult = 17500, TestName = "25% Tax Rate")]
        [TestCase(150000, ExpectedResult = 42000, TestName = "28% Tax Rate")]
        [TestCase(200000, ExpectedResult = 66000, TestName = "33% Tax Rate")]
        [TestCase(400000, ExpectedResult = 140000, TestName = "35% Tax Rate")]
        public decimal CalculateTax_ReturnsCorrectTax(decimal annualIncome)
        {
            // Arrange
            var service = new ProgressiveTaxCalculationService();

            // Act
            var tax = service.CalculateTax(annualIncome);

            // Assert
            return tax;
        }
    }
}
