using SDP.Domain.UseCases.Products.Queries;

namespace SDP.API.Extensions
{
    public static class ApiExtension
    {
        public static IServiceCollection AddApiExtention(this IServiceCollection services)
        {
            services.AddScoped<IProductQueryHandler, ProductQueryHandler>();

            return services;
        }
    }
}
