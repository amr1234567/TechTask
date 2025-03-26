using Domain.Contracts;
using Domain.Models;

namespace Domain.Dtos.Output;

public class ServiceProviderDto : IOutputModel<ServiceProviderDto, ServiceProvider>
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public string ContactDetails { get; set; }

    public ServiceProviderDto MapFrom(ServiceProvider entity)
    {
        Id = entity.Id;
        CreatedAt = entity.CreatedAt;
        Name = entity.Name;
        ContactDetails = entity.ContactDetails;
        return this;
    }
}
