using CloudManager.Api.DtoObjects;
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
        private readonly IUserRepository _userRepository;

        public AssetController(
            ILogger<EmployeeController> logger,
            IConfigurationHelper configurationHelper,
            IAssetRepository assetRepository,
            IUserRepository userRepository
            )
        {
            _configurationHelper = configurationHelper;
            _logger = logger;
            _assetRepository = assetRepository;
            _userRepository = userRepository;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create(AssetManageModel model)
        {
            var authInfo = new AuthInfo() { };

            var userId = User.GetUserId();

            var user = await _userRepository.GetByUserId(userId);

            var request = new ManageEntityRequest<AssetDto>()
            {
                RequestToken = Guid.NewGuid(),
                AuthInfo = authInfo,
                Dto = new AssetDto()
                {
                    Description = model.Description,
                    Name = model.Name,
                    Type = model.Type,
                    Condition = model.Condition,
                    DateCreated = DateTimeOffset.UtcNow,
                    StatusId = 4,
                    UserCreatedId = userId,
                    Club = user.ClubId
                }
            };

            var response = await _assetRepository.CreateAsset(request);

            if (!response.Success)
                return BadRequest();

            return Ok(response.EntityId);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(AssetManageModel model)
        {
            var authInfo = new AuthInfo() { };

            var userId = User.GetUserId();

            var user = await _userRepository.GetByUserId(userId);

            var request = new ManageEntityRequest<AssetDto>()
            {
                RequestToken = Guid.NewGuid(),
                AuthInfo = authInfo,
                Dto = new AssetDto()
                {
                    Id = model.Id,
                    Description = model.Description,
                    Name = model.Name,
                    Type = model.Type,
                    Condition = model.Condition,
                    LastModified = DateTimeOffset.UtcNow,
                    UserLastModifiedId = userId
                }
            };

            var response = await _assetRepository.UpdateAsset(request);

            if (!response.Success)
                return BadRequest();

            return Ok(response.EntityId);
        }

        [AllowAnonymous]
        [HttpGet("types")]
        public async Task<IActionResult> GetAssetTypes()
        {
            var result = await _assetRepository.GetAssetTypes();

            var types = new List<AssetTypeModel>();

            types.AddRange(result.Select(c => c.MapToViewModel()));

            return Ok(types);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
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

            var response = await _assetRepository.DeleteAsset(request);

            if (!response.Success)
                return BadRequest();

            return Ok();
        }

    }
}
