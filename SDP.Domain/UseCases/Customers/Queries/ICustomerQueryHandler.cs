using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Customers.Queries
{
    public interface ICustomerQueryHandler
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync(CancellationToken cancellationToken);
        Task<CustomerDto> GetCustomerByIdAsync(int id, CancellationToken cancellationToken);
    }
}
