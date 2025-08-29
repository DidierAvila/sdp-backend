using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;

namespace SDP.Domain.UseCases.Products.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            // Mapeo de Product a ProductDto
            CreateMap<Product, ProductDto>();

            // Mapeo de ProductDto a Product
            CreateMap<ProductDto, Product>();
        }
    }
}
