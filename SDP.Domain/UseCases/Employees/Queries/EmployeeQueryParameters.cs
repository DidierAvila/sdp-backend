using SDP.Domain.Common;

namespace SDP.Domain.UseCases.Employees.Queries
{
    public class EmployeeQueryParameters : QueryParameters
    {
        // Propiedades específicas para el filtrado de empleados
        public string? LastName { get; set; }
        public string? Title { get; set; }
    }
}
