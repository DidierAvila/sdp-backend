using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IValidator<Domain.Entities.Customer>, CustomerValidator>();
            services.AddScoped<IValidator<Domain.Entities.Employee>, EmployeeValidator>();
            services.AddScoped<IValidator<Domain.Entities.Order>, OrderValidator>();
            services.AddScoped<IValidator<Domain.Entities.Product>, ProductValidator>();
            services.AddScoped<IValidator<Domain.Entities.Shipper>, ShipperValidator>();
            
            return services;
        }
    }
}
