using CloudManager.Api.Entities;
using CloudManager.Api.Models;

namespace CloudManager.Api.Mapping
{
    public static class ClubMapper
    {
        public static ClubModel? MapToModel(this Club model)
        {
            if (model == null)
                return null;

            return new ClubModel()
            {
                Id = model.Id,
                DateFound = model.DateFound,
                Description = model.Description,
                Name = model.Name
            };
        }
    }
}
