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
                            .QueryAsync<EmployeeDto>($"SELECT * FROM dbo.vEmployee {request.QueryParams.WhereClause} {request.QueryParams.OrderByClause} ");

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

        public async Task<CountEntityResponse> GetEmployeesCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.Employees
                          .Where(u => u.Active == true)
                    .CountAsync();

                response.Count = c;
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<CountEntityResponse> GetPlayersCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.EmployeeWorkplaces
                    .Include(x=> x.WorkplaceNavigation)
                          .Where(u => u.Active == true && u.IsCurrent == true && u.WorkplaceNavigation.Label == "PLAYER")
                    .CountAsync();

                response.Count = c;
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<CountEntityResponse> GetAdminisCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.EmployeeWorkplaces
                    .Include(x => x.WorkplaceNavigation)
                          .Where(u => u.Active == true && u.IsCurrent == true && u.WorkplaceNavigation.Label == "ADMINISTRATOR")
                    .CountAsync();

                response.Count = c;
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<CountEntityResponse> GetCoachesCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.EmployeeWorkplaces
                    .Include(x => x.WorkplaceNavigation)
                          .Where(u => u.Active == true && u.IsCurrent == true && u.WorkplaceNavigation.Label == "COACH")
                    .CountAsync();

                response.Count = c;
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<CountEntityResponse> GetRestCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.EmployeeWorkplaces
                    .Include(x => x.WorkplaceNavigation)
                          .Where(u => u.Active == true && u.IsCurrent == true && u.WorkplaceNavigation.Label == "REST")
                    .CountAsync();

                response.Count = c;
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<CountEntityResponse> GetMaintenanceCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.EmployeeWorkplaces
                    .Include(x => x.WorkplaceNavigation)
                          .Where(u => u.Active == true && u.IsCurrent == true && u.WorkplaceNavigation.Label == "MAINTENANCE")
                    .CountAsync();

                response.Count = c;
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<CountEntityResponse> GetInjuryCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.Employees
                    .Include(x => x.StatusNavigation)
                          .Where(u => u.Active == true && u.StatusNavigation.Label == "INJURY")
                    .CountAsync();

                response.Count = c;
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<CountEntityResponse> GetLeadCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.EmployeeWorkplaces
                    .Include(x => x.WorkplaceNavigation)
                          .Where(u => u.Active == true && u.IsCurrent == true && u.WorkplaceNavigation.Label == "LEAD")
                    .CountAsync();

                response.Count = c;
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<GetEntityResponse<EmployeeDto>> GetEmployee(GetEntityRequest request)
        {
            var response = new GetEntityResponse<EmployeeDto>()
            {
                Request = request,
                ResponseToken = Guid.NewGuid(),
                Success = true
            };

            try
            {
                var e = await _dbContext.Employees
                  .Include(x => x.UserCreatedNavigation)
                  .Include(x => x.UserLastModifiedNavigation)
                  .Include(x => x.StatusNavigation)
                  .Include(x => x.ClubNavigation)
                  .SingleAsync(p => p.Id == request.EntityId && p.Active == true);

                var entity = new EmployeeDto()
                {
                    Id = e.Id,
                    Birthday = e.Birthday,
                    ClubId = e.Club.GetValueOrDefault(),
                    DateCreated = e.DateCreated,
                    DateEmployeed = e.DateEmployeed,
                    EmployedTo = e.EmployedTo,
                    FirstName = e.FirstName,
                    LastModified = e.LastModified,
                    LastName = e.LastName,
                    Oib = e.Oib,
                    StatusColor = e.StatusNavigation.Color,
                    StatusId = e.StatusNavigation.Id,
                    StatusName = e.StatusNavigation.Name,
                    UserCreatedId = e.UserCreated,
                    UserLastModifiedId = e.UserLastModified
                };

                if (e != null && e.UserCreatedNavigation != null) { 
                entity.UserCreatedDisplayName = e.UserCreatedNavigation.FirstName;
                }

                if (e != null && e.UserLastModifiedNavigation != null)
                {
                    entity.UserLastModifiedDisplayName = e.UserLastModifiedNavigation.FirstName;
                }

                if (e != null && e.ClubNavigation != null)
                {
                    entity.ClubName = e.ClubNavigation.Name;
                }


                response.Entity = entity;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
                _logger.LogError(ex, "GetCouponUseCase.ExecuteAsync: Request={@Request}", request);
            }

            return response;
        }


    }
}
