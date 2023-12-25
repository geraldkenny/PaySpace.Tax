using FluentValidation;
using FluentValidation.Results;
using LanguageExt.Common;
using PaySpace.Tax.Application.Services.Interfaces;
using PaySpace.Tax.Infrastructure.Enums;
using PaySpace.Tax.Infrastructure.Repositories.Interfaces;
using PaySpace.Tax.Web.Controllers.Handlers.Interfaces;
using PaySpace.Tax.Web.Dtos;
using PaySpace.Tax.Web.Validators;

namespace PaySpace.Tax.Web.Controllers.Handlers
{
    public class TaxControllerHandler(IPostalCodeRepository postalCodeRepository,
                                      ITaxCalculationResultRepository taxCalculationResultRepository,
                                      ITaxCalculationServiceFactory taxCalculationServiceFactory) : ITaxControllerHandler
    {
        private readonly IPostalCodeRepository _postalCodeRepository = postalCodeRepository;
        private readonly ITaxCalculationServiceFactory _taxCalculationServiceFactory = taxCalculationServiceFactory;
        private readonly ITaxCalculationResultRepository _taxCalculationResultRepository = taxCalculationResultRepository;

        /// <summary>
        /// Handles user input for tax calculation, performing validation, determining the tax type based on the postal code,
        /// calculating the tax using the appropriate service, and asynchronously storing the result.
        /// </summary>
        /// <param name="userInputRequestDto">The input data for tax calculation.</param>
        /// <returns>
        /// A <see cref="Result{T}"/> containing the calculated tax or validation errors. 
        /// The result is wrapped in a string for compatibility.
        /// </returns>
        public Result<string> UserInputTaxCalculationHandler(UserInputRequestDto userInputRequestDto)
        {
            var validationResult = ValidateUserInput(userInputRequestDto);

            if (!validationResult.IsValid)
            {
                var errors = new ValidationException(string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage)));

                return new Result<string>(errors);
            }

            TaxType taxType = _postalCodeRepository.GetPostalCodeTaxType(userInputRequestDto!.PostalCode);

            var taxService = _taxCalculationServiceFactory.GetTaxCalculationService(taxType);

            decimal tax = taxService.CalculateTax(userInputRequestDto!.AnnualIncome.Value);

            // Asynchronously add the tax calculation result to the repository.
            Task.Run(() => _taxCalculationResultRepository.AddTaxCalculationResultAsync(userInputRequestDto.AnnualIncome.Value,
                                                                                   userInputRequestDto.PostalCode,
                                                                                   tax));

            return new Result<string>(tax.ToString());

        }

        /// <summary>
        /// Validates user input using the <see cref="UserInputValidator"/>.
        /// </summary>
        /// <param name="userInputDto">The user input data to be validated.</param>
        /// <returns>The validation result.</returns>
        private ValidationResult ValidateUserInput(UserInputRequestDto userInputDto)
        {
            var validator = new UserInputValidator(_postalCodeRepository);

            return validator.Validate(userInputDto);
        }
    }
}
