using Microsoft.AspNetCore.Mvc;
using SDP.API.Utils;
using SDP.Domain.Dtos;
using SDP.Domain.UseCases.Orders.Commands;
using SDP.Domain.UseCases.Orders.Queries;

namespace SDP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderQueryHandler _orderQueryHandler;
        private readonly ICreateOrderCommandHandler _createOrderCommandHandler;

        public OrderController(
            IOrderQueryHandler orderQueryHandler,
            ICreateOrderCommandHandler createOrderCommandHandler)
        {
            _orderQueryHandler = orderQueryHandler;
            _createOrderCommandHandler = createOrderCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] OrderQueryParameters parameters,
            CancellationToken cancellationToken)
        {
            var result = await _orderQueryHandler.GetAllOrdersAsync(parameters, cancellationToken);
            return this.CreatePagedResponse(result);
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
        public async Task<IActionResult> GetByCustomerId(
            int customerId,
            [FromQuery] OrderQueryParameters parameters,
            CancellationToken cancellationToken)
        {
            var result = await _orderQueryHandler.GetOrdersByCustomerIdAsync(customerId, parameters, cancellationToken);
            return this.CreatePagedResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create(
            [FromBody] CreateOrderDto createOrderDto,
            CancellationToken cancellationToken)
        {
            var result = await _createOrderCommandHandler.CreateOrderAsync(createOrderDto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.OrderId }, result);
        }
    }
}
