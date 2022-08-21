using CloudManager.Api.Helpers;
using CloudManager.Api.Mapping;
using CloudManager.Api.Models;
using CloudManager.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudManager.Api.Controllers
{
    [Route("api/shared")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly ILogger<SharedController> _logger;
        private readonly ISharedRepository _repository;
        private readonly IConfigurationHelper _configurationHelper;

        public SharedController(
            ISharedRepository repository,
            ILogger<SharedController> logger,
            IConfigurationHelper configurationHelper
            )
        {
            _repository = repository;
            _configurationHelper = configurationHelper;
            _logger = logger;
        }

        [HttpPost("overview/teams")]
        public async Task<IActionResult> OverviewTeams()
        {
            var authInfo = new AuthInfo() { };

            var query = new QueryParams() { };

            if (string.IsNullOrWhiteSpace(query.OrderByClause))
                query.OrderByClause = "ORDER BY DateCreated DESC";

            var request = new OverviewRequest()
            {
                RequestToken = Guid.NewGuid(),
                AuthInfo = authInfo,
                QueryParams = query
            };

            var response = await _repository.TeamsOverview(request);

            if (!response.Success)
                return BadRequest();

            return new ObjectResult(new
            {
                Data = response.Data.Select(x => x.MapToModel()),
                Total = response.Total
            });
        }

        [HttpGet]
        [Route("team/{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var authInfo = new AuthInfo() { };

            var request = new GetEntityRequest()
            {
                AuthInfo = authInfo,
                RequestToken = Guid.NewGuid(),
                EntityId = id
            };

            var response = await _repository.GetTeam(request);

            if (!response.Success)
                return BadRequest();

            return Ok(new { entity = response.Entity.MapToModel() });
        }

        [HttpDelete]
        [Route("team/member/{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var authInfo = new AuthInfo();

            var userId = User.GetUserId();

            authInfo.UserId = userId;

            var request = new DeleteEntityRequest()
            {
                AuthInfo = authInfo,
                RequestToken = Guid.NewGuid(),
                EntityId = id
            };

            var response = await _repository.RemoveTeamMember(request);

            if (!response.Success)
                return BadRequest();

            return Ok();
        }

    }
}
