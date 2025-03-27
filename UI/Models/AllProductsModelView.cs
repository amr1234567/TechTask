using Domain.Dtos.Output;

namespace UI.Models
{
    public record AllProductsModelView
    {
        public IEnumerable<ProductDto> Products;
        public IEnumerable<ServiceProviderDto> Providers;

        public AllProductsModelView(IEnumerable<ProductDto> value1, IEnumerable<ServiceProviderDto> value2)
        {
            Products = value1;
            Providers = value2;
        }
    }
}
