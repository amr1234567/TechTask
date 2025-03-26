using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class ServiceProvider : BaseEntity
{
    [Required(ErrorMessage = "The service provider name is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The service provider name must be between 3 and 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The contact details are required.")]
    [MaxLength(500)]
    public string ContactDetails { get; set; }

    public IEnumerable<Product> Products { get; set; }
}
