using System;

namespace SDP.Domain.Exceptions
{
    /// <summary>
    /// Se lanza cuando un recurso solicitado no se encuentra
    /// </summary>
    public class NotFoundException : SdpException
    {
        public NotFoundException(string message) 
            : base(message, "NOT_FOUND")
        {
        }

        public NotFoundException(string entityName, object id) 
            : base($"La entidad '{entityName}' con ID '{id}' no fue encontrada.", "NOT_FOUND")
        {
        }
    }
}
