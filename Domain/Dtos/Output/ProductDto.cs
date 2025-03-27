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
    public string ProviderName { set; get; }

    public ProductDto MapFrom(Product entity)
    {
        Id = entity.Id;
        CreatedAt = entity.CreatedAt;
        Name = entity.Name;
        Price = entity.Price;
        ProviderName = entity.ServiceProvider.Name;
        return this;
    }
}
