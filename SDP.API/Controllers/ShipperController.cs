using Microsoft.AspNetCore.Mvc;
using SDP.API.Utils;
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
        public async Task<IActionResult> GetAll(
            [FromQuery] ShipperQueryParameters parameters,
            CancellationToken cancellationToken)
        {
            var result = await _shipperQueryHandler.GetAllShippersAsync(parameters, cancellationToken);
            return this.CreatePagedResponse(result);
        }
    }
}
