using System.Text.Json.Serialization;

namespace PaySpace.Tax.Web.Dtos
{
    public record UserInputRequestDto
    {
        [JsonPropertyName(nameof(AnnualIncome))]
        public decimal? AnnualIncome { get; init; }

        [JsonPropertyName(name: nameof(PostalCode))]
        public string? PostalCode { get; init; }
    }
}
