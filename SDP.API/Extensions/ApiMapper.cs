using SDP.Domain.UseCases.Customers.Mapping;
using SDP.Domain.UseCases.Employees.Mapping;
using SDP.Domain.UseCases.OrderDetails.Mapping;
using SDP.Domain.UseCases.Orders.Mapping;
using SDP.Domain.UseCases.Products.Mapping;
using SDP.Domain.UseCases.Shippers.Mapping;

namespace SDP.API.Extensions
{
    public static class ApiMapper 
    {
        public static IServiceCollection AddApiMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => 
            {
                cfg.AddProfile<EmployeeMapping>();
                cfg.AddProfile<ProductMapping>();
                cfg.AddProfile<ShipperMapping>();
                cfg.AddProfile<CustomerMapping>();
                cfg.AddProfile<OrderMapping>();
                cfg.AddProfile<OrderDetailMapping>();
            });

            return services;
        }
    }
}
