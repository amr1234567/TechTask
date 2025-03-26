using Domain.Contracts;
using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Dtos.Output;

public record ProductDto : IOutputModel<ProductDto, Product>
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public ProductDto MapFrom(Product entity)
    {
        Id = entity.Id;
        CreatedAt = entity.CreatedAt;
        Name = entity.Name;
        Price = entity.Price;
        return this;
    }
}
