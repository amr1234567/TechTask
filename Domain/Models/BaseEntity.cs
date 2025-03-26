using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class BaseEntity
{
    [Key]
    [Required]
    public string Id { get; init; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; init; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }
}