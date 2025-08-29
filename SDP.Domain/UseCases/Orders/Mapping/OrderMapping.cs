using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;

namespace SDP.Domain.UseCases.Orders.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            // Mapeo de Order a OrderDto
            CreateMap<Order, OrderDto>();

            // Mapeo de OrderDto a Order
            CreateMap<OrderDto, Order>();
        }
    }
}
