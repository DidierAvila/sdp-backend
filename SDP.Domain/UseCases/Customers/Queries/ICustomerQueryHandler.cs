using SDP.Domain.Common;
using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Customers.Queries
{
    public interface ICustomerQueryHandler
    {
        Task<PagedList<CustomerDto>> GetAllCustomersAsync(CustomerQueryParameters parameters, CancellationToken cancellationToken);
        Task<CustomerDto> GetCustomerByIdAsync(int id, CancellationToken cancellationToken);
    }
}
