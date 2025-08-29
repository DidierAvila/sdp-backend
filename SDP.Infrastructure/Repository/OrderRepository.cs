using SDP.Domain.Entities;
using SDP.Domain.Repository;
using SDP.Infrastructure.DbContexts;

namespace SDP.Infrastructure.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(SdpContex context) : base(context)
        {
        }
    }
}
