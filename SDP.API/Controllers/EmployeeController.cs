using Microsoft.AspNetCore.Mvc;
using SDP.Domain.Dtos;
using SDP.Domain.UseCases.Employees.Queries;

namespace SDP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeQueryHandler _employeeQueryHandler;

        public EmployeeController(IEmployeeQueryHandler employeeQueryHandler)
        {
            _employeeQueryHandler = employeeQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _employeeQueryHandler.GetAllEmployeesAsync(cancellationToken);
            return Ok(result);
        }
    }
}
