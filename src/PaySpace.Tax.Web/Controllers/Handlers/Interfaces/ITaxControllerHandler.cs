using LanguageExt.Common;
using PaySpace.Tax.Web.Dtos;

namespace PaySpace.Tax.Web.Controllers.Handlers.Interfaces
{
    public interface ITaxControllerHandler
    {
        /// <summary>
        /// Handles user input for tax calculation, performing validation, determining the tax type based on the postal code,
        /// calculating the tax using the appropriate service, and asynchronously storing the result.
        /// </summary>
        /// <param name="userInputRequestDto">The input data for tax calculation.</param>
        /// <returns>
        /// A <see cref="Result{T}"/> containing the calculated tax or validation errors. 
        /// The result is wrapped in a string for compatibility.
        /// </returns>
        Result<string> UserInputTaxCalculationHandler(UserInputRequestDto userInputRequestDto);
    }
}
