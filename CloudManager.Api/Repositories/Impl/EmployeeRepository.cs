using CloudManager.Api.Entities;
using CloudManager.Api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using CloudManager.Api.DtoObjects;
using CloudManager.Api.Helpers;

namespace CloudManager.Api.Repositories.Impl
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly ClubManagerContext _dbContext;
        private readonly IConfigurationHelper _configurationHelper;

        public EmployeeRepository(
            ClubManagerContext dbContext,
            ILogger<EmployeeRepository> logger,
            IConfigurationHelper configurationHelper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _configurationHelper = configurationHelper;
        }

        public async Task<Employee?> FindById(int id)
        {
            return await _dbContext.Employees
                .Include(x=>x.ClubNavigation)
                .Include(x=>x.StatusNavigation)
                    .ThenInclude(y=>y.Group)
                .SingleOrDefaultAsync(e=>e.Id == id);
        }

        public async Task<OverviewResponse<EmployeeDto>> EmployeesOverview(OverviewRequest request)
        {
            var response = new OverviewResponse<EmployeeDto>()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var connectionString = _configurationHelper.GetDefaultConnectionString();

                using (var connection = new SqlConnection(connectionString))
                {
                    if (request.QueryParams != null && request.QueryParams.WhereClause != null)
                    {
                        response.Data = await connection
                            .QueryAsync<EmployeeDto>($"SELECT * FROM dbo.vEmployee {request.QueryParams.WhereClause} {request.QueryParams.OrderByClause} OFFSET {request.QueryParams.Skip} ROWS FETCH NEXT {request.QueryParams.Take} ROWS ONLY");

                        response.Total = await connection
                            .QueryFirstOrDefaultAsync<int>($"SELECT COUNT(*) FROM dbo.vEmployee {request.QueryParams.WhereClause}");
                    }
                    else {
                        response.Data = await connection
                               .QueryAsync<EmployeeDto>($"SELECT * FROM dbo.vEmployee");

                        response.Total = await connection
                            .QueryFirstOrDefaultAsync<int>($"SELECT COUNT(*) FROM dbo.vEmployee ");
                    }
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }
            return response;
        }

    }
}
