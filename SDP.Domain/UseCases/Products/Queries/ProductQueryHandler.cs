using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Products.Queries
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            // Implementation to retrieve all products
            throw new NotImplementedException();
        }
    }
}
