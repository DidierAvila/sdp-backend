using SDP.Domain.Common;
using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Employees.Queries
{
    public interface IEmployeeQueryHandler
    {
        Task<PagedList<EmployeeDto>> GetAllEmployeesAsync(EmployeeQueryParameters parameters, CancellationToken cancellationToken);
    }
}