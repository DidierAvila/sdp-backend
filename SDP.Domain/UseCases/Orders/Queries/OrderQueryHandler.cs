using System.Linq.Expressions;
using AutoMapper;
using SDP.Domain.Common;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;
using SDP.Domain.Repository;

namespace SDP.Domain.UseCases.Orders.Queries
{
    public class OrderQueryHandler : IOrderQueryHandler
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<OrderDto>> GetAllOrdersAsync(OrderQueryParameters parameters, CancellationToken cancellationToken)
        {
            Expression<Func<Order, bool>>? filterExpression = null;
            
            // Aplicar filtros específicos
            if (parameters.FromDate.HasValue)
            {
                var fromDateFilter = (Expression<Func<Order, bool>>)(o => o.OrderDate >= parameters.FromDate.Value);
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Order, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(fromDateFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : fromDateFilter;
            }
            
            if (parameters.ToDate.HasValue)
            {
                var toDateFilter = (Expression<Func<Order, bool>>)(o => o.OrderDate <= parameters.ToDate.Value);
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Order, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(toDateFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : toDateFilter;
            }
            
            if (parameters.CustomerId.HasValue)
            {
                var customerFilter = (Expression<Func<Order, bool>>)(o => o.CustId == parameters.CustomerId.Value);
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Order, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(customerFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : customerFilter;
            }
            
            if (parameters.EmployeeId.HasValue)
            {
                var employeeFilter = (Expression<Func<Order, bool>>)(o => o.EmpId == parameters.EmployeeId.Value);
                filterExpression = filterExpression != null 
                    ? Expression.Lambda<Func<Order, bool>>(
                        Expression.AndAlso(
                            filterExpression.Body,
                            Expression.Invoke(employeeFilter, filterExpression.Parameters)),
                        filterExpression.Parameters)
                    : employeeFilter;
            }

            // Obtener datos paginados
            var (orders, totalCount) = await _orderRepository.GetPagedAsync(
                filterExpression,
                parameters.PageNumber,
                parameters.PageSize,
                parameters.OrderBy,
                cancellationToken);

            // Mapear a DTOs y devolver página
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return new PagedList<OrderDto>(orderDtos, totalCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByID(id, cancellationToken);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<PagedList<OrderDto>> GetOrdersByCustomerIdAsync(int customerId, OrderQueryParameters parameters, CancellationToken cancellationToken)
        {
            Expression<Func<Order, bool>> filterExpression = o => o.CustId == customerId;
            
            // Aplicar filtros adicionales
            if (parameters.FromDate.HasValue)
            {
                var fromDateFilter = (Expression<Func<Order, bool>>)(o => o.OrderDate >= parameters.FromDate.Value);
                filterExpression = Expression.Lambda<Func<Order, bool>>(
                    Expression.AndAlso(
                        filterExpression.Body,
                        Expression.Invoke(fromDateFilter, filterExpression.Parameters)),
                    filterExpression.Parameters);
            }
            
            if (parameters.ToDate.HasValue)
            {
                var toDateFilter = (Expression<Func<Order, bool>>)(o => o.OrderDate <= parameters.ToDate.Value);
                filterExpression = Expression.Lambda<Func<Order, bool>>(
                    Expression.AndAlso(
                        filterExpression.Body,
                        Expression.Invoke(toDateFilter, filterExpression.Parameters)),
                    filterExpression.Parameters);
            }
            
            if (parameters.EmployeeId.HasValue)
            {
                var employeeFilter = (Expression<Func<Order, bool>>)(o => o.EmpId == parameters.EmployeeId.Value);
                filterExpression = Expression.Lambda<Func<Order, bool>>(
                    Expression.AndAlso(
                        filterExpression.Body,
                        Expression.Invoke(employeeFilter, filterExpression.Parameters)),
                    filterExpression.Parameters);
            }

            // Obtener datos paginados
            var (orders, totalCount) = await _orderRepository.GetPagedAsync(
                filterExpression,
                parameters.PageNumber,
                parameters.PageSize,
                parameters.OrderBy,
                cancellationToken);

            // Mapear a DTOs y devolver página
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return new PagedList<OrderDto>(orderDtos, totalCount, parameters.PageNumber, parameters.PageSize);
        }
    }
}
