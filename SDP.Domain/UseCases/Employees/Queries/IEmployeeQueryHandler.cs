using SDP.Domain.Dtos;

namespace SDP.Domain.UseCases.Employees.Queries
{
    public interface IEmployeeQueryHandler
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(CancellationToken cancellationToken);
    }
}