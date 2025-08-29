using SDP.Domain.Entities;
using SDP.Domain.Repository;
using SDP.Infrastructure.DbContexts;

namespace SDP.Infrastructure.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(SdpContex context) : base(context)
        {
        }
    }
}
