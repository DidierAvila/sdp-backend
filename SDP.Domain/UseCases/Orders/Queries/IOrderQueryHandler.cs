using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Orders.Queries
{
    public interface IOrderQueryHandler
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken);
        Task<OrderDto> GetOrderByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId, CancellationToken cancellationToken);
    }
}
