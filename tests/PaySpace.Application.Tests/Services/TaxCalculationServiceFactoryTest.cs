using FluentAssertions;
using PaySpace.Tax.Application.Services;
using PaySpace.Tax.Infrastructure.Enums;

namespace PaySpace.Tax.Application.Tests.Services
{
    [TestFixture]
    public class TaxCalculationServiceFactoryTests
    {
        [Test]
        [TestCase(TaxType.Progessive, ExpectedResult = typeof(ProgressiveTaxCalculationService), TestName = "Progressive service")]
        [TestCase(TaxType.FlatValue, ExpectedResult = typeof(FlatValueTaxCalculationService), TestName = "FlatValue service")]
        [TestCase(TaxType.FlatRate, ExpectedResult = typeof(FlatRateTaxCalculationService), TestName = "FlatRate service")]
        public Type GetTaxCalculationService_WithTaxType_ReturnsCorrectService(TaxType taxType)
        {
            // Arrange
            var factory = new TaxCalculationServiceFactory();

            // Act
            var service = factory.GetTaxCalculationService(taxType);

            // Assert
            return service.GetType();
        }
    }
}
