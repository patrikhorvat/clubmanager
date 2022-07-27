using CloudManager.Api.Entities;
using CloudManager.Api.Models;

namespace CloudManager.Api.Mapping
{
    public static class UserMapper
    {
        public static UserModel? MapToModel(this User model)
        {
            if (model == null)
                return null;

            var vm = new UserModel()
            {
                Id = model.Id,
                Email = model.IdentityUser?.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.IdentityUser?.UserName,
                Club = model.Club.MapToModel()
            };

            return vm;
        }
    }
}
