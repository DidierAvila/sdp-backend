using Microsoft.EntityFrameworkCore;
using SDP.Domain.Entities;
using SDP.Domain.Repository;
using SDP.Infrastructure.DbContexts;

namespace SDP.Infrastructure.Repository
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(SdpContex context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId, CancellationToken cancellationToken)
        {
            return await EntitySet
                .Where(od => od.OrderId == orderId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
