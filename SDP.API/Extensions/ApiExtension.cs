using SDP.Domain.Repository;
using SDP.Domain.UseCases.Customers.Queries;
using SDP.Domain.UseCases.Employees.Queries;
using SDP.Domain.UseCases.OrderDetails.Queries;
using SDP.Domain.UseCases.Orders.Commands;
using SDP.Domain.UseCases.Orders.Queries;
using SDP.Domain.UseCases.Products.Queries;
using SDP.Domain.UseCases.Sales.Queries;
using SDP.Domain.UseCases.Shippers.Queries;
using SDP.Infrastructure.Repository;

namespace SDP.API.Extensions
{
    public static class ApiExtension
    {
        public static IServiceCollection AddApiExtention(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IShipperRepository, ShipperRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            
            // Register query handlers
            services.AddScoped<IEmployeeQueryHandler, EmployeeQueryHandler>();
            services.AddScoped<IProductQueryHandler, ProductQueryHandler>();
            services.AddScoped<IShipperQueryHandler, ShipperQueryHandler>();
            services.AddScoped<ICustomerQueryHandler, CustomerQueryHandler>();
            services.AddScoped<IOrderQueryHandler, OrderQueryHandler>();
            services.AddScoped<IOrderDetailQueryHandler, OrderDetailQueryHandler>();
            services.AddScoped<ISalesPredictionQueryHandler, SalesPredictionQueryHandler>();
            
            // Register command handlers
            services.AddScoped<ICreateOrderCommandHandler, CreateOrderCommandHandler>();

            return services;
        }
    }
}
