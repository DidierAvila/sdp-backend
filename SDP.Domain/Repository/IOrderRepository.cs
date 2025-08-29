using SDP.Domain.Entities;

namespace SDP.Domain.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId, CancellationToken cancellationToken);
    }
}
