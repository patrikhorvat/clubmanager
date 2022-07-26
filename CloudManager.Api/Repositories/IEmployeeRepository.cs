using CloudManager.Api.Entities;

namespace CloudManager.Api.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> FindById(int id);
    }
}
