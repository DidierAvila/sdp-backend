using System.Linq.Expressions;
using AutoMapper;
using SDP.Domain.Common;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;
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

        public async Task<PagedList<ProductDto>> GetAllProductsAsync(ProductQueryParameters parameters, CancellationToken cancellationToken)
        {
            Expression<Func<Product, bool>>? filterExpression = null;
            
            // Aplicar filtros de búsqueda si se han proporcionado
            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                filterExpression = p => p.ProductName.Contains(parameters.SearchTerm);
            }
            
            // Aplicar filtros específicos
            if (!string.IsNullOrWhiteSpace(parameters.ProductName))
            {
                var nameFilter = (Expression<Func<Product, bool>>)(p => p.ProductName.Contains(parameters.ProductName));
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Product, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(nameFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : nameFilter;
            }
            
            if (parameters.MinPrice.HasValue)
            {
                var minPriceFilter = (Expression<Func<Product, bool>>)(p => p.UnitPrice >= parameters.MinPrice.Value);
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Product, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(minPriceFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : minPriceFilter;
            }
            
            if (parameters.MaxPrice.HasValue)
            {
                var maxPriceFilter = (Expression<Func<Product, bool>>)(p => p.UnitPrice <= parameters.MaxPrice.Value);
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Product, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(maxPriceFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : maxPriceFilter;
            }

            // Obtener datos paginados
            var (products, totalCount) = await _productRepository.GetPagedAsync(
                filterExpression,
                parameters.PageNumber,
                parameters.PageSize,
                parameters.OrderBy,
                cancellationToken);

            // Mapear a DTOs y devolver página
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return new PagedList<ProductDto>(productDtos, totalCount, parameters.PageNumber, parameters.PageSize);
        }
    }
}
