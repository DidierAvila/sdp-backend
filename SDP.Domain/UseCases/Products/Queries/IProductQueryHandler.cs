using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Products.Queries
{
    public interface IProductQueryHandler
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken);
    }
}