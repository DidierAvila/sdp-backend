using SDP.Domain.Common;
using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Sales.Queries
{
    public interface ISalesPredictionQueryHandler
    {
        Task<PagedList<SalesPredictionDto>> GetSalesPredictionAsync(SalesPredictionQueryParameters parameters, CancellationToken cancellationToken);
    }
}
