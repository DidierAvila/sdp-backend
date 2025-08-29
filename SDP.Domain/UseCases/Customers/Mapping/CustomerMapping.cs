using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;

namespace SDP.Domain.UseCases.Customers.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            // Mapeo de Customer a CustomerDto
            CreateMap<Customer, CustomerDto>();

            // Mapeo de CustomerDto a Customer
            CreateMap<CustomerDto, Customer>();
        }
    }
}
