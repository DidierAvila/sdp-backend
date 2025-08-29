using Microsoft.AspNetCore.Mvc;
using SDP.Domain.Dtos;

namespace SDP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipperController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipperDto>>> GetAll()
        {
            return Ok(new[] { "Product1", "Product2", "Product3" });
        }
    }
}
