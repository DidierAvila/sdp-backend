using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.OrderDetails.Queries
{
    public interface IOrderDetailQueryHandler
    {
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId, CancellationToken cancellationToken);
    }
}
