using SDP.Domain.Entities;
using SDP.Domain.Repository;
using SDP.Infrastructure.DbContexts;

namespace SDP.Infrastructure.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(SdpContex context) : base(context)
        {
        }
    }
}
