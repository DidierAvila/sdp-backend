using Microsoft.AspNetCore.Mvc;
using SDP.Domain.Dtos;
using SDP.Domain.UseCases.OrderDetails.Queries;

namespace SDP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailQueryHandler _orderDetailQueryHandler;

        public OrderDetailController(IOrderDetailQueryHandler orderDetailQueryHandler)
        {
            _orderDetailQueryHandler = orderDetailQueryHandler;
        }

        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetByOrderId(
            int orderId, CancellationToken cancellationToken)
        {
            var result = await _orderDetailQueryHandler.GetOrderDetailsByOrderIdAsync(orderId, cancellationToken);
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
