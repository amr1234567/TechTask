using Domain.Contracts;
using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Input;

public record ProductModelCreateInput : IInputModel<Product>
{
    [Required(ErrorMessage = "The product name is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The product name must be between 3 and 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The price is required.")]
    [Range(10, double.MaxValue, ErrorMessage = "The price must be a more than 0.")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Creation Date is required")]
    [DataType(DataType.DateTime)]
    public DateTime CreationDate { set; get; } = DateTime.UtcNow;

    [Required(ErrorMessage = "The service provider ID is required.")]
    public string ServiceProviderId { get; set; }

    public Product MapToModel()
    {
        return new()
        {
            CreatedAt = CreationDate,
            Name = Name,
            Price = Price,
            ServiceProviderId = ServiceProviderId,
            Id = Guid.NewGuid().ToString(),
            UpdatedAt = DateTime.Now
        };
    }
}
