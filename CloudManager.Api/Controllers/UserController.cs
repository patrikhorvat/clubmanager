using CloudManager.Api.Helpers;
using CloudManager.Api.Mapping;
using CloudManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CloudManager.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(
            IUserRepository userRepository,
            ILogger<UserController> logger
            )
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetByUserId(userId);

            if (user == null)
                return NotFound();

            return Ok(user.MapToModel());
        }
    }
}
