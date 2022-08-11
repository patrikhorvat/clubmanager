using CloudManager.Api.Helpers;
using CloudManager.Api.Models;
using CloudManager.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudManager.Api.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IConfigurationHelper _configurationHelper;
        private readonly IAssetRepository _assetRepository;

        public DashboardController(
            IEmployeeRepository employeeRepository,
            ILogger<EmployeeController> logger,
            IConfigurationHelper configurationHelper,
            IAssetRepository assetRepository
            )
        {
            _employeeRepository = employeeRepository;
            _configurationHelper = configurationHelper;
            _logger = logger;
            _assetRepository = assetRepository;
        }

        [HttpGet("count-employees")]
        public async Task<IActionResult> GetPartnersCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _employeeRepository.GetEmployeesCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-asset")]
        public async Task<IActionResult> GetAssetCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _assetRepository.GetAssetCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-asset-ball")]
        public async Task<IActionResult> GetAssetBallCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _assetRepository.GetAssetBallCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-asset-yersey")]
        public async Task<IActionResult> GetAssetYerseyCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _assetRepository.GetAssetYerseyCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-asset-goal")]
        public async Task<IActionResult> GetAssetGoalCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _assetRepository.GetAssetGoalCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }


        [HttpGet("count-asset-machine")]
        public async Task<IActionResult> GetAssetMachineCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _assetRepository.GetAssetMachineCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-asset-rest")]
        public async Task<IActionResult> GetAssetRestCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _assetRepository.GetAssetRestCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-asset-broken")]
        public async Task<IActionResult> GetAssetBrokenCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _assetRepository.GetAssetBrokenCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-asset-socks")]
        public async Task<IActionResult> GetAssetSocksCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _assetRepository.GetAssetSocksCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

    }
}
