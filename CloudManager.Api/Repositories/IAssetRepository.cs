using CloudManager.Api.DtoObjects;
using CloudManager.Api.Entities;
using CloudManager.Api.Models;

namespace CloudManager.Api.Repositories
{
    public interface IAssetRepository
    {
        Task<Asset?> FindById(int id);
        Task<CountEntityResponse> GetAssetCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetBallCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetGoalCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetYerseyCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetMachineCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetRestCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetBrokenCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAssetSocksCount(CountEntityRequest request);
        Task<OverviewResponse<AssetDto>> AssetOverview(OverviewRequest request);
        Task<GetEntityResponse<AssetDto>> GetAsset(GetEntityRequest request);
        Task<ManageEntityResponse<ManageEntityRequest<AssetDto>>> CreateAsset(ManageEntityRequest<AssetDto> request);
        Task<List<AssetTypeDto>> GetAssetTypes();
        Task<ManageEntityResponse<ManageEntityRequest<AssetDto>>> UpdateAsset(ManageEntityRequest<AssetDto> request);
        Task<DeleteEntityResponse> DeleteAsset(DeleteEntityRequest request);
    }
}
