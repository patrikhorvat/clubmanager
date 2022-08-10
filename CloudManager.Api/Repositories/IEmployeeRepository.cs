using CloudManager.Api.DtoObjects;
using CloudManager.Api.Entities;
using CloudManager.Api.Models;

namespace CloudManager.Api.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> FindById(int id);
        Task<OverviewResponse<EmployeeDto>> EmployeesOverview(OverviewRequest request);
    }
}
