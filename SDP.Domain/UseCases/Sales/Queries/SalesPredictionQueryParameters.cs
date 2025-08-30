using SDP.Domain.Common;

namespace SDP.Domain.UseCases.Sales.Queries
{
    public class SalesPredictionQueryParameters : QueryParameters
    {
        public string? CustomerName { get; set; }
    }
}
