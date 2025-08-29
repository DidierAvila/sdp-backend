using Microsoft.AspNetCore.Mvc;
using SDP.API.Utils;
using SDP.Domain.Dtos;
using SDP.Domain.UseCases.Products.Queries;

namespace SDP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductQueryHandler _productQueryHandler;

        public ProductController(IProductQueryHandler productQueryHandler)
        {
            _productQueryHandler = productQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] ProductQueryParameters parameters,
            CancellationToken cancellationToken)
        {
            var result = await _productQueryHandler.GetAllProductsAsync(parameters, cancellationToken);
            return this.CreatePagedResponse(result);
        }
    }
}
