using CloudManager.Api.Entities;

namespace CloudManager.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdentityUserId(string identityUserId);
    }
}
