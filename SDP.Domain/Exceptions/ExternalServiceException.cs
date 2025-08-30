using System;

namespace SDP.Domain.Exceptions
{
    /// <summary>
    /// Se lanza cuando ocurre un error al interactuar con recursos externos (bases de datos, servicios externos, etc.)
    /// </summary>
    public class ExternalServiceException : SdpException
    {
        public ExternalServiceException(string message) 
            : base(message, "EXTERNAL_SERVICE_ERROR")
        {
        }
        
        public ExternalServiceException(string serviceName, string message) 
            : base($"Error en el servicio externo '{serviceName}': {message}", "EXTERNAL_SERVICE_ERROR")
        {
        }

        public ExternalServiceException(string message, Exception innerException) 
            : base(message, "EXTERNAL_SERVICE_ERROR", innerException)
        {
        }
    }
}
