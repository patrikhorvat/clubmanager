using CloudManager.Api.Helpers;
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
        private readonly IConfigurationHelper _configurationHelper;

        public EmployeeController(
            IEmployeeRepository employeeRepository,
            ILogger<EmployeeController> logger,
            IConfigurationHelper configurationHelper
            )
        {
            _employeeRepository = employeeRepository;
            _configurationHelper = configurationHelper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var connectionString = _configurationHelper.GetDefaultConnectionString();
            return Ok();
        }
    }
}
