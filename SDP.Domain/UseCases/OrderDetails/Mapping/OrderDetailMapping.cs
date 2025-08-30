using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;

namespace SDP.Domain.UseCases.OrderDetails.Mapping
{
    public class OrderDetailMapping : Profile
    {
        public OrderDetailMapping()
        {
            // Mapeo de OrderDetail a OrderDetailDto
            CreateMap<OrderDetail, OrderDetailDto>();
            
            // Mapeo de CreateOrderDetailDto a OrderDetail
            CreateMap<CreateOrderDetailDto, OrderDetail>();
        }
    }
}
