using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;
using SDP.Domain.Repository;

namespace SDP.Domain.UseCases.Orders.Commands
{
    public class CreateOrderCommandHandler : ICreateOrderCommandHandler
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken cancellationToken)
        {
            // Mapear el DTO a una entidad
            var order = _mapper.Map<Order>(createOrderDto);
            
            // Establecer la fecha de orden a la fecha actual
            order.OrderDate = DateTime.UtcNow;
            
            // El ShippedDate será null hasta que se envíe el pedido
            order.ShippedDate = null;

            // Crear la orden en el repositorio
            var createdOrder = await _orderRepository.Create(order, cancellationToken);

            // Mapear la entidad creada de vuelta a un DTO
            return _mapper.Map<OrderDto>(createdOrder);
        }
    }
}
