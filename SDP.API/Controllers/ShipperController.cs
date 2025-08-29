using Microsoft.AspNetCore.Mvc;
using SDP.Domain.Dtos;
using SDP.Domain.UseCases.Shippers.Queries;

namespace SDP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperQueryHandler _shipperQueryHandler;

        public ShipperController(IShipperQueryHandler shipperQueryHandler)
        {
            _shipperQueryHandler = shipperQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipperDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _shipperQueryHandler.GetAllShippersAsync(cancellationToken);
            return Ok(result);
        }
    }
}
