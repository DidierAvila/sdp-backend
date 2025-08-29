using SDP.Domain.Entities;
using SDP.Domain.Repository;

namespace SDP.Infrastructure.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContexts.SdpContex context) : base(context)
        {
        }
    }
}
