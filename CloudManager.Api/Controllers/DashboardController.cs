using CloudManager.Api.Helpers;
using CloudManager.Api.Models;
using CloudManager.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudManager.Api.Controllers
{
    [Authorize]
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

        #region Employee Dashboard

        [HttpGet("count-employees")]
        public async Task<IActionResult> GetEmployeesCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _employeeRepository.GetEmployeesCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-employees-players")]
        public async Task<IActionResult> GetPlayersCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _employeeRepository.GetPlayersCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-employees-admins")]
        public async Task<IActionResult> GetAdminsCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _employeeRepository.GetAdminisCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-employees-coaches")]
        public async Task<IActionResult> GetCoachesCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _employeeRepository.GetCoachesCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-employees-rest")]
        public async Task<IActionResult> GetRestCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _employeeRepository.GetRestCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-employees-lead")]
        public async Task<IActionResult> GetLeadCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _employeeRepository.GetLeadCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-employees-maintenance")]
        public async Task<IActionResult> GetMaintenanceCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _employeeRepository.GetMaintenanceCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        [HttpGet("count-employees-injury")]
        public async Task<IActionResult> GetInjuryCount()
        {
            var authInfo = new AuthInfo() { };

            var result = await _employeeRepository.GetInjuryCount(new CountEntityRequest { });

            return new ObjectResult(result.Count);

        }

        #endregion

        #region Asset Dashboard

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
        #endregion

    }
}
