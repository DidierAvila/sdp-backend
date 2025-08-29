using SDP.Domain.Common;

namespace SDP.Domain.UseCases.Orders.Queries
{
    public class OrderQueryParameters : QueryParameters
    {
        // Propiedades específicas para el filtrado de órdenes
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
