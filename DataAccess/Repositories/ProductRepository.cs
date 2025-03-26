using DataAccess.Contexts;
using Domain.Abstractions;
using Domain.Dtos.Input;
using Domain.Dtos.Output;
using Domain.Errors;
using Domain.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ProductRepository(ServiceProviderContext context) : IProductRepository
{
    public async Task<Result> CreateProduct(ProductModelCreateInput model)
    {
        var product = model.MapToModel();

        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        return Result.Ok();
    }

    public Task<Result> DeleteProduct(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<ProductDto>> GetProductById(string id)
    {
        var product = await context.Products.Where(p => p.Id == id).Select(p => new ProductDto().MapFrom(p)).FirstOrDefaultAsync();
        if(product == null)
            return EntityNotFoundError.Exists<Product>(id);
        return product;
    }

    public async Task<Result<IEnumerable<ProductDto>>> GetProducts(GetProductsParams inputs)
    {
        return await context.Products
            .Where(p => (string.IsNullOrEmpty(inputs.ProviderId) && p.ServiceProviderId == inputs.ProviderId) ||
                (inputs.CreatedFrom.HasValue && p.CreatedAt >= inputs.CreatedFrom.Value) || 
                (inputs.CreatedTo.HasValue && p.CreatedAt <= inputs.CreatedTo.Value) ||
                (inputs.MaxPrice.HasValue && p.Price <= inputs.MaxPrice.Value) ||
                (inputs.MinPrice.HasValue && p.Price >= inputs.MinPrice.Value))
            .Select(p => new ProductDto().MapFrom(p)).ToListAsync();
    }

    public Task<Result> UpdateProduct(ProductModelUpdateInput model)
    {
        throw new NotImplementedException();
    }
}
