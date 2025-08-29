using Microsoft.AspNetCore.Mvc;
using SDP.Domain.Dtos;
using SDP.Domain.UseCases.Orders.Queries;

namespace SDP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderQueryHandler _orderQueryHandler;

        public OrderController(IOrderQueryHandler orderQueryHandler)
        {
            _orderQueryHandler = orderQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _orderQueryHandler.GetAllOrdersAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _orderQueryHandler.GetOrderByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetByCustomerId(int customerId, CancellationToken cancellationToken)
        {
            var result = await _orderQueryHandler.GetOrdersByCustomerIdAsync(customerId, cancellationToken);
            return Ok(result);
        }
    }
}
