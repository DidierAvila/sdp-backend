using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;

namespace SDP.Domain.UseCases.Shippers.Mapping
{
    public class ShipperMapping : Profile
    {
        public ShipperMapping()
        {
            // Mapeo de Shipper a ShipperDto
            CreateMap<Shipper, ShipperDto>();

            // Mapeo de ShipperDto a Shipper
            CreateMap<ShipperDto, Shipper>();
        }
    }
}
