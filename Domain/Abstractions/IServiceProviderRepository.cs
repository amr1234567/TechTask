using Domain.Dtos.Input;
using Domain.Dtos.Output;
using FluentResults;

namespace Domain.Abstractions;

public interface IServiceProviderRepository
{
    Task<Result<IEnumerable<ServiceProviderDto>>> GetServiceProviders();
    Task<Result<ServiceProviderDto>> GetServiceProviderById(string id);
    Task<Result> CreateServiceProvider(ServiceProviderModelCreateInput model);
    Task<Result> UpdateServiceProvider(string id, ServiceProviderModelUpdateInput model);
    Task<Result> DeleteServiceProvider(string id);
}
