using DataAccess.Contexts;
using Domain.Abstractions;
using Domain.Dtos.Input;
using Domain.Dtos.Output;
using Domain.Errors;
using Domain.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ServiceProviderRepository(ServiceProviderContext context) : IServiceProviderRepository
{
    public async Task<Result> CreateServiceProvider(ServiceProviderModelCreateInput model)
    {
        var service = model.MapToModel();
        await context.ServiceProviders.AddAsync(service);
        await context.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> DeleteServiceProvider(string id)
    {
        var service = await GetServiceProviderForInternal(id);
        if (service.IsFailed)
            return Result.Fail(service.Errors);

        context.ServiceProviders.Remove(service.Value);
        await context.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result<ServiceProviderDto>> GetServiceProviderById(string id)
    {
        var service = await context.ServiceProviders.Where(s => s.Id == id)
            .Select(s => new ServiceProviderDto().MapFrom(s)).FirstOrDefaultAsync();
        if (service is null)
        {
            return EntityNotFoundError.Exists<ServiceProvider>(id);
        }
        return service;
    }

    public async Task<Result<IEnumerable<ServiceProviderDto>>> GetServiceProviders()
    {
        return await context.ServiceProviders.Select(s => new ServiceProviderDto().MapFrom(s)).ToListAsync();
    }

    public async Task<Result> UpdateServiceProvider(string id, ServiceProviderModelUpdateInput model)
    {
        var serviceResult = await GetServiceProviderForInternal(id);
        if (serviceResult.IsFailed)
            return Result.Fail(serviceResult.Errors);
        var service = serviceResult.Value;
        service.ContactDetails = model.ContactDetails ?? service.ContactDetails;
        service.Name = model.Name ?? service.Name;
        context.ServiceProviders.Update(service);
        await context.SaveChangesAsync();
        return Result.Ok();
    }

    private async Task<Result<ServiceProvider>> GetServiceProviderForInternal(string id)
    {
        var service = await context.ServiceProviders.FirstOrDefaultAsync(s => s.Id == id);
        if (service is null)
        {
            return EntityNotFoundError.Exists<ServiceProvider>(id);
        }

        return service;
    } 
}
