using CloudManager.Api.Helpers;
using CloudManager.Api.Mapping;
using CloudManager.Api.Models;
using CloudManager.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudManager.Api.Controllers
{
    [Authorize]
    [Route("api/asset")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IConfigurationHelper _configurationHelper;
        private readonly IAssetRepository _assetRepository;

        public AssetController(
            ILogger<EmployeeController> logger,
            IConfigurationHelper configurationHelper,
            IAssetRepository assetRepository
            )
        {
            _configurationHelper = configurationHelper;
            _logger = logger;
            _assetRepository = assetRepository;
        }

        [HttpPost("overview")]
        public async Task<IActionResult> Overview()
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

            var response = await _assetRepository.AssetOverview(request);

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
        public async Task<IActionResult> GetAsset(int id)
        {
            var authInfo = new AuthInfo() { };

            var request = new GetEntityRequest()
            {
                AuthInfo = authInfo,
                RequestToken = Guid.NewGuid(),
                EntityId = id
            };

            var response = await _assetRepository.GetAsset(request);

            if (!response.Success)
                return BadRequest();

            return Ok(new { entity = response.Entity.MapToModel() });
        }

    }
}
