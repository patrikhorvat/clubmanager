using CloudManager.Api.Mapping;
using CloudManager.Api.Models;
using CloudManager.Api.Helpers;
using CloudManager.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CloudManager.Api.DtoObjects;

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
        private readonly IUserRepository _userRepository;

        public EmployeeController(
            IEmployeeRepository employeeRepository,
            ILogger<EmployeeController> logger,
            IConfigurationHelper configurationHelper,
            IUserRepository userRepository
            )
        {
            _employeeRepository = employeeRepository;
            _configurationHelper = configurationHelper;
            _logger = logger;
            _userRepository = userRepository;
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

        [HttpPost("overview/members/{teamId}")]
        public async Task<IActionResult> OverviewMembers(int teamId)
        {
            var authInfo = new AuthInfo() { };

            var query = new QueryParams() { };

            if (string.IsNullOrWhiteSpace(query.OrderByClause))
                query.OrderByClause = "ORDER BY DateCreated DESC";

            query.WhereClause = $@" WHERE Id IN ( SELECT Employee FROM dbo.EmployeeWorkplace 
                                                WHERE (Workplace = 3 OR Workplace = 2) 
                                                AND Active = 1 AND IsCurrent = 1 ) 
                                                AND Id IN ( SELECT Employee FROM dbo.EmployeeTeam 
                                                WHERE Team = {teamId} 
                                                AND Active = 1 AND IsCurrent = 1 ) ";

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

        [HttpPost("overview/members/unsorted")]
        public async Task<IActionResult> OverviewUnsortedMembers(int teamId)
        {
            var authInfo = new AuthInfo() { };

            var query = new QueryParams() { };

            if (string.IsNullOrWhiteSpace(query.OrderByClause))
                query.OrderByClause = "ORDER BY DateCreated DESC";

            query.WhereClause = $@" WHERE Id IN ( SELECT Employee FROM dbo.EmployeeWorkplace 
                                                WHERE (Workplace = 3 OR Workplace = 2) 
                                                AND Active = 1 AND IsCurrent = 1 ) 
                                                AND Id NOT IN ( SELECT Employee FROM dbo.EmployeeTeam 
                                                WHERE Active = 1 AND IsCurrent = 1 ) ";

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

        [AllowAnonymous]
        [HttpGet("types")]
        public async Task<IActionResult> GetAssetTypes()
        {
            var result = await _employeeRepository.GetEmployeeTypes();

            var types = new List<EmployeeTypeModel>();

            types.AddRange(result.Select(c => c.MapToViewModel()));

            return Ok(types);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(EmployeeManageModel model)
        {
            var authInfo = new AuthInfo() { };

            var userId = User.GetUserId();

            var user = await _userRepository.GetByUserId(userId);

            var request = new ManageEntityRequest<EmployeeDto>()
            {
                RequestToken = Guid.NewGuid(),
                AuthInfo = authInfo,
                Dto = new EmployeeDto()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    WorkplaceId = model.Type,
                    DateCreated = DateTimeOffset.UtcNow,
                    StatusId = 1,
                    UserCreatedId = userId,
                    ClubId = user.ClubId
                }
            };

            var response = await _employeeRepository.CreateEmployee(request);

            if (!response.Success)
                return BadRequest();

            return Ok(response.EntityId);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EmployeeManageModel model)
        {
            var authInfo = new AuthInfo() { };

            var userId = User.GetUserId();

            var request = new ManageEntityRequest<EmployeeDto>()
            {
                RequestToken = Guid.NewGuid(),
                AuthInfo = authInfo,
                Dto = new EmployeeDto()
                {
                    Id = model.Id.GetValueOrDefault(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    LastModified = DateTimeOffset.UtcNow,
                    UserLastModifiedId = userId
                }
            };

            var response = await _employeeRepository.UpdateEmployee(request);

            if (!response.Success)
                return BadRequest();

            return Ok(response.EntityId);
        }

    }
}
