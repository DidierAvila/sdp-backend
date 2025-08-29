using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Repository;

namespace SDP.Domain.UseCases.Orders.Queries
{
    public class OrderQueryHandler : IOrderQueryHandler
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAll(cancellationToken);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByID(id, cancellationToken);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByCustomerId(customerId, cancellationToken);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
    }
}
