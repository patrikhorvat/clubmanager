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
                UserLastModifiedDisplayName = dto.UserLastModifiedDisplayName,
                StatusColor = dto.StatusColor,
                WorkplaceId = dto.WorkplaceId,
                WorkplaceLabel = dto.WorkplaceLabel,
                WorkplaceName = dto.WorkplaceName
            };
        }

        public static AssetModel MapToModel(this AssetDto dto)
        {
            if (dto == null)
                return null;

            return new AssetModel
            {
                Id = dto.Id,
                DateCreated = dto.DateCreated,
                LastModified = dto.LastModified,
                StatusId = dto.StatusId,
                UserCreatedId = dto.UserCreatedId,
                UserLastModifiedId = dto.UserLastModifiedId,
                StatusName = dto.StatusName,
                UserCreatedDisplayName = dto.UserCreatedDisplayName,
                UserLastModifiedDisplayName = dto.UserLastModifiedDisplayName,
                StatusColor = dto.StatusColor,
                AssetTypeLabel = dto.AssetTypeLabel,
                AssetTypeName = dto.AssetTypeName,
                Club=dto.Club,
                Condition=dto.Condition,
                Description=dto.Description,
                Name=dto.Name,
                Type = dto.Type
            };
        }

    }
}
