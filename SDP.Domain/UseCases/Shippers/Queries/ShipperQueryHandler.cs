using AutoMapper;
using SDP.Domain.Dtos;
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

        public async Task<IEnumerable<ShipperDto>> GetAllShippersAsync(CancellationToken cancellationToken)
        {
            var shippers = await _shipperRepository.GetAll(cancellationToken);
            return _mapper.Map<IEnumerable<ShipperDto>>(shippers);
        }
    }
}
