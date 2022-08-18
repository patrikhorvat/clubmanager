using CloudManager.Api.DtoObjects;
using CloudManager.Api.Models;

namespace CloudManager.Api.Repositories
{
    public interface ISharedRepository
    {
        Task<OverviewResponse<TeamDto>> TeamsOverview(OverviewRequest request);
        Task<GetEntityResponse<TeamDto>> GetTeam(GetEntityRequest request);
    }
}
