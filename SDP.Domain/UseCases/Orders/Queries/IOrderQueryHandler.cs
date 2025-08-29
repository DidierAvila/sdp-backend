using SDP.Domain.Common;
using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Orders.Queries
{
    public interface IOrderQueryHandler
    {
        Task<PagedList<OrderDto>> GetAllOrdersAsync(OrderQueryParameters parameters, CancellationToken cancellationToken);
        Task<OrderDto> GetOrderByIdAsync(int id, CancellationToken cancellationToken);
        Task<PagedList<OrderDto>> GetOrdersByCustomerIdAsync(int customerId, OrderQueryParameters parameters, CancellationToken cancellationToken);
    }
}
