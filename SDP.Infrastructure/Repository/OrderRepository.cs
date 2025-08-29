using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId, CancellationToken cancellationToken)
        {
            return await _context.Set<Order>()
                .Where(o => o.CustId == customerId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
