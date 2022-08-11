using CloudManager.Api.Entities;
using CloudManager.Api.Models;

namespace CloudManager.Api.Repositories
{
    public interface IAssetRepository
    {
        Task<Asset?> FindById(int id);
        //Task<OverviewResponse<EmployeeDto>> EmployeesOverview(OverviewRequest request);
        Task<CountEntityResponse> GetAssetCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetBallCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetGoalCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetYerseyCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetMachineCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetRestCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetBrokenCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetSocksCount(CountEntityRequest request);
    }
}
