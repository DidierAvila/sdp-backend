using SDP.Domain.Entities;
using SDP.Domain.Repository;
using SDP.Infrastructure.DbContexts;

namespace SDP.Infrastructure.Repository
{
    public class ShipperRepository : RepositoryBase<Shipper>, IShipperRepository
    {
        public ShipperRepository(SdpContex context) : base(context)
        {
        }
    }
}
