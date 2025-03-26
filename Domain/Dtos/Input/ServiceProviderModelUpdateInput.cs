using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Dtos.Input;

public record ServiceProviderModelUpdateInput
{
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The service provider name must be between 3 and 100 characters.")]
    [AllowNull]
    public string? Name { get; set; }

    [AllowNull]
    [MaxLength(500)]
    public string? ContactDetails { get; set; }
}