using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PaySpace.Tax.Application.Services;
using PaySpace.Tax.Application.Services.Interfaces;
using PaySpace.Tax.Infrastructure.Enums;
using PaySpace.Tax.Infrastructure.Repositories.Interfaces;
using PaySpace.Tax.Web.Controllers.Api;
using PaySpace.Tax.Web.Controllers.Handlers;
using PaySpace.Tax.Web.Dtos;

namespace PaySpace.Tax.Web.Tests.Controllers
{

    [TestFixture]
    public class TaxControllerTests
    {
        private Mock<IPostalCodeRepository> _mockPostalCodeRepository;
        private ITaxCalculationServiceFactory _taxCalculationServiceFactory;
        private TaxControllerHandler _controllerHandler;
        private TaxController _taxController;

        [SetUp]
        public void SetUp()
        {
            _mockPostalCodeRepository = new Mock<IPostalCodeRepository>();
            var taxCalculationResultRepository = new Mock<ITaxCalculationResultRepository>();
            _taxCalculationServiceFactory = new TaxCalculationServiceFactory();

            _controllerHandler = new TaxControllerHandler(_mockPostalCodeRepository.Object,
                                                      taxCalculationResultRepository.Object,
                                                      _taxCalculationServiceFactory);
            var logger = new Mock<ILogger<TaxController>>();

            _taxController = new TaxController(_controllerHandler, logger.Object);
        }

        [Test]
        public void CalculateTax_WithValidInput_ReturnsOkResult()
        {
            // Arrange
            var userInputDto = new UserInputRequestDto
            {
                AnnualIncome = 50000,
                PostalCode = "7441"
            };

            _mockPostalCodeRepository.Setup(repo => repo.GetValidPostalCodes())
                .Returns(new List<string> { "7441" }); // Mock valid postal codes

            // Act
            var result = _taxController.Calculate(userInputDto);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void CalculateTax_WithInvalidInput_ReturnsBadRequestResult()
        {
            // Arrange
            var userInputDto = new UserInputRequestDto
            {
                AnnualIncome = -50000, // Invalid annual income
                PostalCode = "InvalidCode"
            };

            _mockPostalCodeRepository.Setup(repo => repo.GetValidPostalCodes())
                .Returns(new List<string> { "7441" }); // Mock valid postal codes

            // Act
            var result = _taxController.Calculate(userInputDto);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
