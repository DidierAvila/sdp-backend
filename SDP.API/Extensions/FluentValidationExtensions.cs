using FluentValidation;
using FluentValidation.AspNetCore;
using SDP.Domain.Entities;
using SDP.Domain.Validators;

namespace SDP.API.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection AddFluentValidationConfiguration(this IServiceCollection services)
        {
            // Configurar FluentValidation en ASP.NET Core
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            
            // Registrar los validadores de entidades manualmente
            services.AddScoped<IValidator<Customer>, CustomerValidator>();
            services.AddScoped<IValidator<Employee>, EmployeeValidator>();
            services.AddScoped<IValidator<Order>, OrderValidator>();
            services.AddScoped<IValidator<Product>, ProductValidator>();
            services.AddScoped<IValidator<Shipper>, ShipperValidator>();
            
            return services;
        }
    }
}
