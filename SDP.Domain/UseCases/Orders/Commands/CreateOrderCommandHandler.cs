using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;
using SDP.Domain.Repository;
using System.Transactions;

namespace SDP.Domain.UseCases.Orders.Commands
{
    public class CreateOrderCommandHandler : ICreateOrderCommandHandler
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken cancellationToken)
        {
            // Usamos una transacción para asegurar la consistencia entre la orden y sus detalles
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            
            try
            {
                // Mapear el DTO a una entidad
                var order = _mapper.Map<Order>(createOrderDto);
                
                // Establecer la fecha de orden a la fecha actual
                order.OrderDate = DateTime.UtcNow;
                
                // El ShippedDate será null hasta que se envíe el pedido
                order.ShippedDate = null;

                // Crear la orden en el repositorio
                var createdOrder = await _orderRepository.Create(order, cancellationToken);

                // Crear los detalles de la orden
                if (createOrderDto.OrderDetails != null && createOrderDto.OrderDetails.Any())
                {
                    // Mapear todos los detalles y asignarles el ID de la orden creada
                    var orderDetails = createOrderDto.OrderDetails.Select(detailDto => 
                    {
                        var orderDetail = _mapper.Map<OrderDetail>(detailDto);
                        orderDetail.OrderId = createdOrder.OrderId;
                        return orderDetail;
                    }).ToList();
                    
                    // Crear todos los detalles en una sola transacción
                    await _orderDetailRepository.CreateMany(orderDetails, cancellationToken);
                }

                // Completar la transacción
                scope.Complete();

                // Mapear la entidad creada de vuelta a un DTO
                return _mapper.Map<OrderDto>(createdOrder);
            }
            catch (Exception)
            {
                // La transacción se revertirá automáticamente
                throw;
            }
        }
    }
}
