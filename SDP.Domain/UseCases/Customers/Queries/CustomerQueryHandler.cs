using System.Linq.Expressions;
using AutoMapper;
using SDP.Domain.Common;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;
using SDP.Domain.Repository;

namespace SDP.Domain.UseCases.Customers.Queries
{
    public class CustomerQueryHandler : ICustomerQueryHandler
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<CustomerDto>> GetAllCustomersAsync(CustomerQueryParameters parameters, CancellationToken cancellationToken)
        {
            Expression<Func<Customer, bool>>? filterExpression = null;
            
            // Aplicar filtros de búsqueda si se han proporcionado
            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                filterExpression = c => c.CompanyName.Contains(parameters.SearchTerm) || 
                                        c.ContactName.Contains(parameters.SearchTerm) ||
                                        c.ContactTitle.Contains(parameters.SearchTerm);
            }
            
            // Aplicar filtros específicos
            if (!string.IsNullOrWhiteSpace(parameters.CompanyName))
            {
                var companyFilter = (Expression<Func<Customer, bool>>)(c => c.CompanyName.Contains(parameters.CompanyName));
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Customer, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(companyFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : companyFilter;
            }
            
            if (!string.IsNullOrWhiteSpace(parameters.ContactName))
            {
                var contactFilter = (Expression<Func<Customer, bool>>)(c => c.ContactName.Contains(parameters.ContactName));
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Customer, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(contactFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : contactFilter;
            }
            
            if (!string.IsNullOrWhiteSpace(parameters.Country))
            {
                var countryFilter = (Expression<Func<Customer, bool>>)(c => c.Country.Contains(parameters.Country));
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Customer, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(countryFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : countryFilter;
            }

            // Obtener datos paginados
            var (customers, totalCount) = await _customerRepository.GetPagedAsync(
                filterExpression,
                parameters.PageNumber,
                parameters.PageSize,
                parameters.OrderBy,
                cancellationToken);

            // Mapear a DTOs y devolver página
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return new PagedList<CustomerDto>(customerDtos, totalCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByID(id, cancellationToken);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
