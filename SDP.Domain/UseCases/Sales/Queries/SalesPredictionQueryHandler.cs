using SDP.Domain.Common;
using SDP.Domain.Dtos;
using SDP.Domain.Entities;
using SDP.Domain.Repository;

namespace SDP.Domain.UseCases.Sales.Queries
{
    public class SalesPredictionQueryHandler : ISalesPredictionQueryHandler
    {
        private IEnumerable<SalesPredictionDto> OrderResults(IEnumerable<SalesPredictionDto> results, string orderBy)
        {
            var orderParams = orderBy.Trim().Split(',');
            
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyName = param.Split(' ')[0].Trim();
                var sortingOrder = param.EndsWith(" desc", StringComparison.OrdinalIgnoreCase);
                
                switch (propertyName.ToLower())
                {
                    case "customername":
                        results = sortingOrder 
                            ? results.OrderByDescending(p => p.CustomerName)
                            : results.OrderBy(p => p.CustomerName);
                        break;
                    case "lastorderdate":
                        results = sortingOrder 
                            ? results.OrderByDescending(p => p.LastOrderDate)
                            : results.OrderBy(p => p.LastOrderDate);
                        break;
                    case "nextpredictedorder":
                        results = sortingOrder 
                            ? results.OrderByDescending(p => p.NextPredictedOrder)
                            : results.OrderBy(p => p.NextPredictedOrder);
                        break;
                    default:
                        // Si no se reconoce la propiedad, ordenamos por nombre del cliente
                        results = results.OrderBy(p => p.CustomerName);
                        break;
                }
            }
            
            return results;
        }
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public SalesPredictionQueryHandler(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public async Task<PagedList<SalesPredictionDto>> GetSalesPredictionAsync(SalesPredictionQueryParameters parameters, CancellationToken cancellationToken)
        {
            // Obtenemos todos los clientes y sus órdenes
            var customers = await _customerRepository.GetAll(cancellationToken);
            var orders = await _orderRepository.GetAll(cancellationToken);

            var results = new List<SalesPredictionDto>();

            foreach (var customer in customers)
            {
                // Obtenemos las órdenes del cliente, ordenadas por fecha
                var customerOrders = orders
                    .Where(o => o.CustId == customer.CustId)
                    .OrderBy(o => o.OrderDate)
                    .ToList();

                // Si el cliente no tiene órdenes, continuamos con el siguiente
                if (!customerOrders.Any())
                    continue;

                // Calculamos el promedio de días entre órdenes
                double averageDaysBetweenOrders = 0;
                
                if (customerOrders.Count > 1)
                {
                    double totalDaysBetweenOrders = 0;
                    for (int i = 1; i < customerOrders.Count; i++)
                    {
                        var daysDifference = (customerOrders[i].OrderDate - customerOrders[i-1].OrderDate).TotalDays;
                        totalDaysBetweenOrders += daysDifference;
                    }
                    averageDaysBetweenOrders = totalDaysBetweenOrders / (customerOrders.Count - 1);
                }
                else
                {
                    // Si solo hay una orden, asumimos un valor predeterminado (30 días)
                    averageDaysBetweenOrders = 30;
                }

                // Obtenemos la fecha de la última orden
                var lastOrderDate = customerOrders.Last().OrderDate;

                // Calculamos la fecha de la próxima orden
                var nextPredictedOrder = lastOrderDate.AddDays(averageDaysBetweenOrders);

                // Creamos el DTO con la predicción
                results.Add(new SalesPredictionDto
                {
                    CustomerName = customer.CompanyName,
                    LastOrderDate = lastOrderDate,
                    NextPredictedOrder = nextPredictedOrder
                });
            }
            
            // Aplicamos filtrado si se proporciona un nombre de cliente
            if (!string.IsNullOrWhiteSpace(parameters.CustomerName))
            {
                results = results.Where(p => p.CustomerName.Contains(parameters.CustomerName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            
            // Aplicamos búsqueda general si se proporciona
            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                results = results.Where(p => 
                    p.CustomerName.Contains(parameters.SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            
            // Ordenamos los resultados
            if (!string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                // Ordenamos según el criterio especificado
                results = OrderResults(results, parameters.OrderBy).ToList();
            }
            else
            {
                // Por defecto, ordenamos por nombre del cliente
                results = results.OrderBy(p => p.CustomerName).ToList();
            }
            
            // Calculamos el total antes de la paginación
            int totalCount = results.Count;
            
            // Aplicamos paginación
            var pagedResults = results
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList();
            
            return new PagedList<SalesPredictionDto>(pagedResults, totalCount, parameters.PageNumber, parameters.PageSize);
        }
    }
}
