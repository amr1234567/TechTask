using Domain.Contracts;
using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Input;

public record ServiceProviderModelCreateInput : IInputModel<ServiceProvider>
{
    [Required(ErrorMessage = "The service provider name is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The service provider name must be between 3 and 100 characters.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "The contact details are required.")]
    public string ContactDetails { get; set; }

    public ServiceProvider MapToModel()
    {
        return new()
        {
            CreatedAt = DateTime.Now,
            Name = Name,
            ContactDetails = ContactDetails,
            Id = Guid.NewGuid().ToString(),
            UpdatedAt = DateTime.Now
        };
    }
}
