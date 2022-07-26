using CloudManager.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudManager.Api.Repositories.Impl
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly ClubManagerContext _dbContext;

        public EmployeeRepository(
            ClubManagerContext dbContext,
            ILogger<EmployeeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Employee?> FindById(int id)
        {
            return await _dbContext.Employees
                .Include(x=>x.ClubNavigation)
                .Include(x=>x.StatusNavigation)
                    .ThenInclude(y=>y.Group)
                .SingleOrDefaultAsync(e=>e.Id == id);
        }
    }
}
