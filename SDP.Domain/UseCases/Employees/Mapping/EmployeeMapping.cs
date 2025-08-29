using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;

namespace SDP.Domain.UseCases.Employees.Mapping
{
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping()
        {
            // Mapeo de Customer a CustomerDto
            CreateMap<Employee, EmployeeDto>();

            // Mapeo de CustomerDto a Customer
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
