using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SDP.Domain.Exceptions;

namespace SDP.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "Error no controlado: {Message}", exception.Message);

            var statusCode = HttpStatusCode.InternalServerError;
            var errorCode = "INTERNAL_SERVER_ERROR";
            var message = "Se produjo un error interno. Por favor, inténtelo de nuevo más tarde.";
            
            // Determinar el código de estado y el mensaje según el tipo de excepción
            switch (exception)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorCode = notFoundException.ErrorCode;
                    message = notFoundException.Message;
                    break;
                    
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    errorCode = validationException.ErrorCode;
                    message = validationException.Message;
                    break;
                    
                case BusinessRuleException businessRuleException:
                    statusCode = HttpStatusCode.Conflict;
                    errorCode = businessRuleException.ErrorCode;
                    message = businessRuleException.Message;
                    break;
                    
                case ExternalServiceException externalServiceException:
                    statusCode = HttpStatusCode.ServiceUnavailable;
                    errorCode = externalServiceException.ErrorCode;
                    message = externalServiceException.Message;
                    break;
            }

            var response = new
            {
                code = errorCode,
                message = message,
                timestamp = DateTime.UtcNow
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
