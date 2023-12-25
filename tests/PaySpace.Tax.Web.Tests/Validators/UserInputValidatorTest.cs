using Moq;
using PaySpace.Tax.Infrastructure.Repositories.Interfaces;
using PaySpace.Tax.Web.Dtos;
using PaySpace.Tax.Web.Validators;

namespace PaySpace.Tax.Web.Tests.Validators
{
    [TestFixture]
    public class UserInputValidatorTest
    {
        private Mock<IPostalCodeRepository> _mockPostalCodeRepository;
        private UserInputValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _mockPostalCodeRepository = new Mock<IPostalCodeRepository>();
            _validator = new UserInputValidator(_mockPostalCodeRepository.Object);
        }


        [Test]
        public void ValidateUserInput_ValidInput_ReturnsNoErrors()
        {
            // Arrange
            var userInputDto = new UserInputRequestDto
            {
                AnnualIncome = 50_000,
                PostalCode = "7441"
            };

            _mockPostalCodeRepository.Setup(x => x.GetValidPostalCodes()).Returns(new List<string> { "7441" });

            // Act
            var validationResult = _validator.Validate(userInputDto);

            // Assert
            validationResult.IsValid.Should().BeTrue();
        }

        [Test]
        public void ValidateUserInput_InvalidPostalCode_ReturnsError()
        {
            // Arrange
            var userInputDto = new UserInputRequestDto
            {
                AnnualIncome = 50_000,
                PostalCode = "InvalidCode"
            };
            _mockPostalCodeRepository.Setup(x => x.GetValidPostalCodes()).Returns(new List<string> { "7441" });

            // Act
            var validationResult = _validator.Validate(userInputDto);

            // Assert
            validationResult.Errors.Select(x => x.ErrorMessage).Should().Contain("Invalid postal code.");
        }

        [Test]
        public void ValidateUserInput_NegativeAnnualIncome_ReturnsError()
        {
            // Arrange
            var userInputDto = new UserInputRequestDto
            {
                AnnualIncome = -50000,
                PostalCode = "7441"
            };

            _mockPostalCodeRepository.Setup(x => x.GetValidPostalCodes()).Returns(new List<string> { "7441" });

            // Act
            var validationResult = _validator.Validate(userInputDto);

            // Assert
            validationResult.Errors.Select(x => x.ErrorMessage).Should().Contain("Annual income must be greater than zero.");
        }

        [Test]
        public void ValidateUserInput_ZeroAnnualIncome_ReturnsError()
        {
            // Arrange
            var userInputDto = new UserInputRequestDto
            {
                AnnualIncome = 0,
                PostalCode = "7441"
            };

            _mockPostalCodeRepository.Setup(x => x.GetValidPostalCodes()).Returns(new List<string> { "7441" });

            // Act
            var validationResult = _validator.Validate(userInputDto);

            // Assert
            validationResult.Errors.Select(x => x.ErrorMessage).Should().Contain("Annual income must be greater than zero.");
        }
    }
}
