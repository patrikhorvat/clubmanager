using CloudManager.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudManager.Api.Controllers
{
    [Authorize]
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(
            IEmployeeRepository employeeRepository,
            ILogger<EmployeeController> logger
            )
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok();
        }
    }
}
