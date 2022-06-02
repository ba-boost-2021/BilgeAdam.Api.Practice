using BilgeAdam.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.Api.Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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