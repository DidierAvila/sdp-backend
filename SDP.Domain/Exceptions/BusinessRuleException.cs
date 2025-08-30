using System;

namespace SDP.Domain.Exceptions
{
    /// <summary>
    /// Se lanza cuando una operación no es válida debido a la lógica de negocio
    /// </summary>
    public class BusinessRuleException : SdpException
    {
        public BusinessRuleException(string message) 
            : base(message, "BUSINESS_RULE_VIOLATION")
        {
        }
        
        public BusinessRuleException(string message, Exception innerException) 
            : base(message, "BUSINESS_RULE_VIOLATION", innerException)
        {
        }
    }
}
