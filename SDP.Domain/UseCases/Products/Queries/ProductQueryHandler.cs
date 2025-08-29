using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Repository;

namespace SDP.Domain.UseCases.Products.Queries
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll(cancellationToken);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
