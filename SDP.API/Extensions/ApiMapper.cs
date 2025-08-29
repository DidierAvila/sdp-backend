using SDP.Domain.UseCases.Employees.Mapping;

namespace SDP.API.Extensions
{
    public static class ApiMapper 
    {
        public static IServiceCollection AddApiMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<EmployeeMapping>());

            return services;
        }
    }
}
