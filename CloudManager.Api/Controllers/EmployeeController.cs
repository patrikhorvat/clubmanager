using CloudManager.Api.Mapping;
using CloudManager.Api.Models;
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

        [HttpPost("overview")]
        public async Task<IActionResult> Overview()
        {
            var authInfo = new AuthInfo() { };

            var query = new QueryParams(){ };

            if (string.IsNullOrWhiteSpace(query.OrderByClause))
                query.OrderByClause = "ORDER BY DateCreated DESC";

            var request = new OverviewRequest()
            {
                RequestToken = Guid.NewGuid(),
                AuthInfo = authInfo,
                QueryParams = query
            };

            var response = await _employeeRepository.EmployeesOverview(request);

            if (!response.Success)
                return BadRequest();

            return new ObjectResult(new
            {
                Data = response.Data.Select(x => x.MapToModel()),
                Total = response.Total
            });
        }

        [HttpPost("overview/players")]
        public async Task<IActionResult> OverviewPlayers()
        {
            var authInfo = new AuthInfo() { };

            var query = new QueryParams() { };

            if (string.IsNullOrWhiteSpace(query.OrderByClause))
                query.OrderByClause = "ORDER BY DateCreated DESC";

            query.WhereClause = $@" WHERE Id IN ( SELECT Employee FROM dbo.EmployeeWorkplace WHERE Workplace = 3 AND Active = 1 AND IsCurrent = 1 ) ";

            var request = new OverviewRequest()
            {
                RequestToken = Guid.NewGuid(),
                AuthInfo = authInfo,
                QueryParams = query
            };

            var response = await _employeeRepository.EmployeesOverview(request);

            if (!response.Success)
                return BadRequest();

            return new ObjectResult(new
            {
                Data = response.Data.Select(x => x.MapToModel()),
                Total = response.Total
            });
        }

        [HttpPost("overview/coaches")]
        public async Task<IActionResult> OverviewCoaches()
        {
            var authInfo = new AuthInfo() { };

            var query = new QueryParams() { };

            if (string.IsNullOrWhiteSpace(query.OrderByClause))
                query.OrderByClause = "ORDER BY DateCreated DESC";

            query.WhereClause = $@" WHERE Id IN ( SELECT Employee FROM dbo.EmployeeWorkplace WHERE Workplace = 2 AND Active = 1 AND IsCurrent = 1 ) ";

            var request = new OverviewRequest()
            {
                RequestToken = Guid.NewGuid(),
                AuthInfo = authInfo,
                QueryParams = query
            };

            var response = await _employeeRepository.EmployeesOverview(request);

            if (!response.Success)
                return BadRequest();

            return new ObjectResult(new
            {
                Data = response.Data.Select(x => x.MapToModel()),
                Total = response.Total
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var authInfo = new AuthInfo() { };

            var request = new GetEntityRequest()
            {
                AuthInfo = authInfo,
                RequestToken = Guid.NewGuid(),
                EntityId = id
            };

            var response = await _employeeRepository.GetEmployee(request);

            if (!response.Success)
                return BadRequest();

            return Ok(new { entity = response.Entity.MapToModel() });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var connectionString = _configurationHelper.GetDefaultConnectionString();
            return Ok();
        }
    }
}
