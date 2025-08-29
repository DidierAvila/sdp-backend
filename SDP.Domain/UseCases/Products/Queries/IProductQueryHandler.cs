using SDP.Domain.Common;
using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Products.Queries
{
    public interface IProductQueryHandler
    {
        Task<PagedList<ProductDto>> GetAllProductsAsync(ProductQueryParameters parameters, CancellationToken cancellationToken);
    }
}