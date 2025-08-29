using System.Linq.Expressions;
using AutoMapper;
using SDP.Domain.Common;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;
using SDP.Domain.Repository;

namespace SDP.Domain.UseCases.Shippers.Queries
{
    public class ShipperQueryHandler : IShipperQueryHandler
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly IMapper _mapper;

        public ShipperQueryHandler(IShipperRepository shipperRepository, IMapper mapper)
        {
            _shipperRepository = shipperRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<ShipperDto>> GetAllShippersAsync(ShipperQueryParameters parameters, CancellationToken cancellationToken)
        {
            Expression<Func<Shipper, bool>>? filterExpression = null;
            
            // Aplicar filtros de búsqueda si se han proporcionado
            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                filterExpression = s => s.CompanyName.Contains(parameters.SearchTerm) || 
                                        s.Phone.Contains(parameters.SearchTerm);
            }
            
            // Aplicar filtros específicos
            if (!string.IsNullOrWhiteSpace(parameters.CompanyName))
            {
                var nameFilter = (Expression<Func<Shipper, bool>>)(s => s.CompanyName.Contains(parameters.CompanyName));
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Shipper, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(nameFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : nameFilter;
            }

            // Obtener datos paginados
            var (shippers, totalCount) = await _shipperRepository.GetPagedAsync(
                filterExpression,
                parameters.PageNumber,
                parameters.PageSize,
                parameters.OrderBy,
                cancellationToken);

            // Mapear a DTOs y devolver página
            var shipperDtos = _mapper.Map<IEnumerable<ShipperDto>>(shippers);
            return new PagedList<ShipperDto>(shipperDtos, totalCount, parameters.PageNumber, parameters.PageSize);
        }
    }
}
