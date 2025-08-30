using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Repository;

namespace SDP.Domain.UseCases.OrderDetails.Queries
{
    public class OrderDetailQueryHandler : IOrderDetailQueryHandler
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetailsByOrderIdAsync(orderId, cancellationToken);
            return _mapper.Map<IEnumerable<OrderDetailDto>>(orderDetails);
        }
    }
}
