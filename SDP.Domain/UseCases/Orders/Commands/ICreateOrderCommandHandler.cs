using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Orders.Commands
{
    public interface ICreateOrderCommandHandler
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken cancellationToken);
    }
}
