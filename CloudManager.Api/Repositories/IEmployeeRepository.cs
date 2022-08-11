using CloudManager.Api.DtoObjects;
using CloudManager.Api.Entities;
using CloudManager.Api.Models;

namespace CloudManager.Api.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> FindById(int id);
        Task<OverviewResponse<EmployeeDto>> EmployeesOverview(OverviewRequest request);
        Task<CountEntityResponse> GetEmployeesCount(CountEntityRequest request);
        Task<CountEntityResponse> GetPlayersCount(CountEntityRequest request);
        Task<CountEntityResponse> GetAdminisCount(CountEntityRequest request);
        Task<CountEntityResponse> GetLeadCount(CountEntityRequest request);
        Task<CountEntityResponse> GetMaintenanceCount(CountEntityRequest request);
        Task<CountEntityResponse> GetRestCount(CountEntityRequest request);
        Task<CountEntityResponse> GetCoachesCount(CountEntityRequest request);
        Task<CountEntityResponse> GetInjuryCount(CountEntityRequest request);
    }
}
