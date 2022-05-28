using BilgeAdam.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.Api.Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }
        [HttpGet("list")]
        public IActionResult GetPagedEmployee([FromQuery] int count, [FromQuery] int page)
        {
            var result = service.GetPagedEmployees(count, page);
            return Ok(result);
        }
    }
}
