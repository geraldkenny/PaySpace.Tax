using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PaySpace.Tax.Web.Controllers.Handlers.Interfaces;
using PaySpace.Tax.Web.Dtos;

namespace PaySpace.Tax.Web.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [EnableRateLimiting("concurrency")]
    public class TaxController(ITaxControllerHandler taxControllerHandler, ILogger<TaxController> logger) : ControllerBase
    {
        private readonly ITaxControllerHandler _taxControllerHandler = taxControllerHandler;
        private readonly ILogger<TaxController> _logger = logger;

        [HttpPost(nameof(Calculate))]
        public IActionResult Calculate([FromBody] UserInputRequestDto userInputRequest)
        {
            _logger.LogInformation("New request: {@requestModel}", userInputRequest);

            var result = _taxControllerHandler.UserInputTaxCalculationHandler(userInputRequest);

            return result.Match<IActionResult>(succ => Ok(new { responseMessage = succ }), error => BadRequest(new { responseMessage = error.Message }));
        }
    }
}
