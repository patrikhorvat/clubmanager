using ClubManagerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagerAPI.Controllers
{
    [Route("api/shared")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly ILogger<SharedController> _logger;

        public SharedController(ILogger<SharedController> logger)
        {
            _logger = logger;
        }

        #region Status

        [HttpGet]
        [Route("status/get/{id}")]
        public async Task<IActionResult> GetStatus(int id)
        {
            var status = new StatusModel() { };

            return Ok(status);
        }

        [HttpPost("status/list")]
        public async Task<IActionResult> StatusList()
        {
            var statuses = new List<StatusModel>();

            return new ObjectResult(new
            {
                Data = statuses
            });
        }

        #endregion
    }
}
