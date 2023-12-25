using FluentValidation;
using PaySpace.Tax.Infrastructure.Repositories.Interfaces;
using PaySpace.Tax.Web.Dtos;

namespace PaySpace.Tax.Web.Validators
{
    public class UserInputValidator : AbstractValidator<UserInputRequestDto>
    {
        private readonly IPostalCodeRepository _postalCodeRepository;

        public UserInputValidator(IPostalCodeRepository postalCodeRepository)
        {
            _postalCodeRepository = postalCodeRepository;

            RuleFor(dto => dto.AnnualIncome)
                 .NotEmpty().WithMessage("Annual income is required.")
                 .GreaterThan(0).WithMessage("Annual income must be greater than zero.");

            RuleFor(dto => dto.PostalCode)
                .NotEmpty().WithMessage("Postal code is required.")
                .Must(BeAValidPostalCode).WithMessage("Invalid postal code.");
        }

        private bool BeAValidPostalCode(string postalCode)
        {
            var validPostalCodes = _postalCodeRepository.GetValidPostalCodes();
            return validPostalCodes.Contains(postalCode);
        }
    }
}
