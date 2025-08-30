using System;

namespace SDP.Domain.Exceptions
{
    /// <summary>
    /// Se lanza cuando los datos proporcionados son inválidos o no cumplen con las reglas de validación
    /// </summary>
    public class ValidationException : SdpException
    {
        public ValidationException(string message) 
            : base(message, "VALIDATION_ERROR")
        {
        }
        
        public ValidationException(string fieldName, string errorDetail) 
            : base($"Error de validación en el campo '{fieldName}': {errorDetail}", "VALIDATION_ERROR")
        {
        }
    }
}
