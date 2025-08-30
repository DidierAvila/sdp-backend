using System;

namespace SDP.Domain.Exceptions
{
    /// <summary>
    /// Excepción base para todas las excepciones personalizadas de la aplicación
    /// </summary>
    public abstract class SdpException : Exception
    {
        public string ErrorCode { get; } = "UNKNOWN_ERROR";

        protected SdpException(string message) 
            : base(message)
        {
        }

        protected SdpException(string message, string errorCode) 
            : base(message)
        {
            ErrorCode = errorCode;
        }

        protected SdpException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected SdpException(string message, string errorCode, Exception innerException) 
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
