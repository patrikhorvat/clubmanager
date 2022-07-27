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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(
            IUserRepository userRepository,
            ILogger<UserController> logger,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _userRepository = userRepository;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var context = _httpContextAccessor.HttpContext;
            var userClaim = context.User.Claims.SingleOrDefault(c => c.Type == "UserId");
            var userId = int.Parse(userClaim.Value.ToString());

            var user = await _userRepository.GetByUserId(userId);

            if (user == null)
                return NotFound();

            return Ok(user.MapToModel());
        }
    }
}
