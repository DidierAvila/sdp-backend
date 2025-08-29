using SDP.API.Extensions; // Ensure AutoMapper namespace is included

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApiExtention();
builder.Services.AddApiMapper();
// OpenAPI minimal (ya estaba)
builder.Services.AddOpenApi();
// SwaggerGen para documentación interactiva
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseAuthorization();

app.MapControllers();

app.Run();
