using SDP.Domain.Entities;

namespace SDP.Domain.Repository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId, CancellationToken cancellationToken);
    }
}
