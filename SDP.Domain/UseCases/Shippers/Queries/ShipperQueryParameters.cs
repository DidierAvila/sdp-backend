using SDP.Domain.Common;

namespace SDP.Domain.UseCases.Shippers.Queries
{
    public class ShipperQueryParameters : QueryParameters
    {
        // Propiedades específicas para el filtrado de transportistas
        public string? CompanyName { get; set; }
    }
}
