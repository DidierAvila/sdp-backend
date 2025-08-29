using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;

namespace SDP.Domain.UseCases.Orders.Mapping
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            // Mapeo de Order a OrderDto
            CreateMap<Order, OrderDto>();
            
            // Mapeo de CreateOrderDto a Order
            CreateMap<CreateOrderDto, Order>();
        }
    }
}
