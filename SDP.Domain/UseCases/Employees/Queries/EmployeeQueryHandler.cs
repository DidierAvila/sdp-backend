using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Repository;

namespace SDP.Domain.UseCases.Employees.Queries
{
    public class EmployeeQueryHandler : IEmployeeQueryHandler
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper) 
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAll(cancellationToken);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
    }
}
