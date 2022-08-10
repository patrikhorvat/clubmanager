using CloudManager.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudManager.Api.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly ClubManagerContext _dbContext;

        public UserRepository(
            ClubManagerContext dbContext,
            ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<User?> GetByIdentityUserId(string identityUserId)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(u => u.IdentityUserId == identityUserId && u.Active == true);
        }

        public async Task<User?> GetByUserId(int userId)
        {
            return await _dbContext.Users
                .Include(u=>u.IdentityUser)
                .Include(u=>u.Club)
                .SingleOrDefaultAsync(u => u.Id == userId 
                && u.Active == true);
        }
    }
}
