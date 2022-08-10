using CloudManager.Api.DtoObjects;
using CloudManager.Api.Entities;
using CloudManager.Api.Models;

namespace CloudManager.Api.Mapping
{
    public static class SharedMapper
    {
        public static EmployeeModel MapToModel(this EmployeeDto dto)
        {
            if (dto == null)
                return null;

            return new EmployeeModel
            {
                Id = dto.Id,
                DateCreated = dto.DateCreated,
                LastModified = dto.LastModified,
                Birthday = dto.Birthday,
                ClubId = dto.ClubId,
                DateEmployeed = dto.DateEmployeed,
                EmployedTo = dto.EmployedTo,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Oib = dto.Oib,
                StatusId = dto.StatusId,
                UserCreatedId = dto.UserCreatedId,
                UserLastModifiedId = dto.UserLastModifiedId,
                ClubName = dto.ClubName,
                StatusName = dto.StatusName,
                UserCreatedDisplayName = dto.UserCreatedDisplayName,
                UserLastModifiedDisplayName = dto.UserLastModifiedDisplayName
            };
        }

        public static ClubModel MapToModel(this Club dto)
        {
            if (dto == null)
                return null;

            return new ClubModel
            {
                Id = dto.Id,
                Name = dto.Name
                
            };
        }

        public static UserModel MapToModel(this User dto)
        {
            if (dto == null)
                return null;

            return new UserModel
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName

            };
        }

    }
}
