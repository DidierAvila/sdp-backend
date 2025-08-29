using Microsoft.EntityFrameworkCore;
using SDP.Domain.Entities;

namespace SDP.Infrastructure.DbContexts
{
    public partial class SdpContex : DbContext
    {
        public SdpContex(DbContextOptions<SdpContex> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This method is intentionally left empty because the configuration is provided externally via DbContextOptions.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => OnModelCreatingPartial(modelBuilder);

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
