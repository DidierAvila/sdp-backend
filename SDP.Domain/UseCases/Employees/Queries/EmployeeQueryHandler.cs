using System.Linq.Expressions;
using AutoMapper;
using SDP.Domain.Common;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;
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

        public async Task<PagedList<EmployeeDto>> GetAllEmployeesAsync(EmployeeQueryParameters parameters, CancellationToken cancellationToken)
        {
            Expression<Func<Employee, bool>>? filterExpression = null;
            
            // Aplicar filtros de búsqueda si se han proporcionado
            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                filterExpression = e => e.LastName.Contains(parameters.SearchTerm) || 
                                        e.FirstName.Contains(parameters.SearchTerm) ||
                                        e.Title.Contains(parameters.SearchTerm);
            }
            
            // Aplicar filtros específicos
            if (!string.IsNullOrWhiteSpace(parameters.LastName))
            {
                var lastNameFilter = (Expression<Func<Employee, bool>>)(e => e.LastName.Contains(parameters.LastName));
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Employee, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(lastNameFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : lastNameFilter;
            }
            
            if (!string.IsNullOrWhiteSpace(parameters.Title))
            {
                var titleFilter = (Expression<Func<Employee, bool>>)(e => e.Title.Contains(parameters.Title));
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Employee, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(titleFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : titleFilter;
            }

            // Obtener datos paginados
            var (employees, totalCount) = await _employeeRepository.GetPagedAsync(
                filterExpression,
                parameters.PageNumber,
                parameters.PageSize,
                parameters.OrderBy,
                cancellationToken);

            // Mapear a DTOs y devolver página
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return new PagedList<EmployeeDto>(employeeDtos, totalCount, parameters.PageNumber, parameters.PageSize);
        }
    }
}
