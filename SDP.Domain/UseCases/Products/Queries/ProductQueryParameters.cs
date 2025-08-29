using SDP.Domain.Common;

namespace SDP.Domain.UseCases.Products.Queries
{
    public class ProductQueryParameters : QueryParameters
    {
        // Propiedades específicas para el filtrado de productos
        public string? ProductName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
