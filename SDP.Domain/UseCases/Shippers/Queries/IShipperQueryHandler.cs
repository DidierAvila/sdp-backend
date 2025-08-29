using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Shippers.Queries
{
    public interface IShipperQueryHandler
    {
        Task<IEnumerable<ShipperDto>> GetAllShippersAsync(CancellationToken cancellationToken);
    }
}