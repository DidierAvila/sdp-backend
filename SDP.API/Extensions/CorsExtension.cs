using System.Text.Json;

namespace SDP.API.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSdpFrontend", builder =>
                {
                    builder
                        .WithOrigins("http://localhost:4200")  // Permite solicitudes específicamente desde tu front-end Angular
                        .AllowAnyMethod()                      // Permite cualquier método HTTP (GET, POST, PUT, DELETE, etc.)
                        .AllowAnyHeader()                      // Permite cualquier encabezado en la solicitud
                        .AllowCredentials()                    // Permite que se envíen cookies en solicitudes cross-origin
                        .WithExposedHeaders("X-Pagination");   // Permite que el front-end lea el encabezado de paginación
                });
            });

            return services;
        }
    }
}
