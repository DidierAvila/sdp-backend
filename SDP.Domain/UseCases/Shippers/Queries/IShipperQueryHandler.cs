using SDP.Domain.Common;
using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Shippers.Queries
{
    public interface IShipperQueryHandler
    {
        Task<PagedList<ShipperDto>> GetAllShippersAsync(ShipperQueryParameters parameters, CancellationToken cancellationToken);
    }
}