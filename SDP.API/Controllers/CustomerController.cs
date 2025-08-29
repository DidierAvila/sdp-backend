using Microsoft.AspNetCore.Mvc;
using SDP.API.Utils;
using SDP.Domain.Dtos;
using SDP.Domain.UseCases.Customers.Queries;

namespace SDP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerQueryHandler _customerQueryHandler;

        public CustomerController(ICustomerQueryHandler customerQueryHandler)
        {
            _customerQueryHandler = customerQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] CustomerQueryParameters parameters,
            CancellationToken cancellationToken)
        {
            var result = await _customerQueryHandler.GetAllCustomersAsync(parameters, cancellationToken);
            return this.CreatePagedResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _customerQueryHandler.GetCustomerByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}