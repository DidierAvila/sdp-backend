using SDP.Domain.Common;

namespace SDP.Domain.UseCases.Customers.Queries
{
    public class CustomerQueryParameters : QueryParameters
    {
        // Propiedades específicas para el filtrado de clientes
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? Country { get; set; }
    }
}
