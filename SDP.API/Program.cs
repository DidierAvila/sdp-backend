using SDP.API.Extensions;
using SDP.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using SDP.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar FluentValidation y registrar los validadores
builder.Services.AddFluentValidationConfiguration();

// Configuración de CORS
builder.Services.AddCorsPolicy(builder.Configuration);
// OpenAPI minimal (ya estaba)
builder.Services.AddOpenApi();
// SwaggerGen para documentación interactiva
builder.Services.AddSwaggerGen();

// Configure Entity Framework
builder.Services.AddDbContext<SdpContex>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApiExtention();

builder.Services.AddApiMapper();


var app = builder.Build();

// Configure the HTTP request pipeline.
// El middleware de manejo de errores debe ser lo primero en la pipeline
app.UseErrorHandling();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Swagger UI solo en desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SDP.API v1");
        c.RoutePrefix = string.Empty; // Swagger UI en la raíz
    });
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors("AllowSdpFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
