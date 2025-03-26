using Domain.Dtos.Input;
using Domain.Dtos.Output;
using FluentResults;

namespace Domain.Abstractions;

public interface IProductRepository
{
    Task<Result<IEnumerable<ProductDto>>> GetProducts(GetProductsParams inputs);
    Task<Result> CreateProduct(ProductModelCreateInput model);
    Task<Result> UpdateProduct(ProductModelUpdateInput model);
    Task<Result> DeleteProduct(string id);
    Task<Result<ProductDto>> GetProductById(string id);
}
