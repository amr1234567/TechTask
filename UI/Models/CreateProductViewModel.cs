using Domain.Dtos.Input;
using Domain.Dtos.Output;

namespace UI.Models
{
    public record CreateProductViewModel
    {
        public ProductModelCreateInput CreationModel;
        public IEnumerable<ServiceProviderDto> Providers;

        public CreateProductViewModel(ProductModelCreateInput productModelCreateInput, IEnumerable<ServiceProviderDto> value)
        {
            CreationModel = productModelCreateInput;
            Providers = value;
        }
    }
}
