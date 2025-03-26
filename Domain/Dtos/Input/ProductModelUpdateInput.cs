using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Dtos.Input;

public record ProductModelUpdateInput
{
    [AllowNull]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The product name must be between 3 and 100 characters.")]
    public string? Name { get; set; }

    [AllowNull]
    [Range(0, double.MaxValue, ErrorMessage = "The price must be a non-negative value.")]
    public double? Price { get; set; }
}
