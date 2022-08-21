using CloudManager.Api.DtoObjects;
using CloudManager.Api.Entities;
using CloudManager.Api.Helpers;
using CloudManager.Api.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CloudManager.Api.Repositories.Impl
{
    public class SharedRepository : ISharedRepository
    {
        private readonly ILogger<SharedRepository> _logger;
        private readonly ClubManagerContext _dbContext;
        private readonly IConfigurationHelper _configurationHelper;

        public SharedRepository(
            ClubManagerContext dbContext,
            ILogger<SharedRepository> logger,
            IConfigurationHelper configurationHelper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _configurationHelper = configurationHelper;
        }

        public async Task<GetEntityResponse<TeamDto>> GetTeam(GetEntityRequest request)
        {
            var response = new GetEntityResponse<TeamDto>()
            {
                Request = request,
                ResponseToken = Guid.NewGuid(),
                Success = true
            };

            try
            {
                var e = await _dbContext.Teams
                  .Include(x => x.StatusNavigation)
                  .Include(x => x.ClubNavigation)
                  .SingleAsync(p => p.Id == request.EntityId && p.Active == true);

                var entity = new TeamDto()
                {
                    Id = e.Id,
                    StatusColor = e.StatusNavigation.Color,
                    StatusId = e.StatusNavigation.Id,
                    StatusName = e.StatusNavigation.Name,
                    Club = e.Club,
                    League = e.League,
                    Name =e.Name
                };

                response.Entity = entity;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<OverviewResponse<TeamDto>> TeamsOverview(OverviewRequest request)
        {
            var response = new OverviewResponse<TeamDto>()
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
                            .QueryAsync<TeamDto>($"SELECT * FROM dbo.vTeam {request.QueryParams.WhereClause} {request.QueryParams.OrderByClause} ");

                        response.Total = await connection
                            .QueryFirstOrDefaultAsync<int>($"SELECT COUNT(*) FROM dbo.vTeam {request.QueryParams.WhereClause}");
                    }
                    else
                    {
                        response.Data = await connection
                               .QueryAsync<TeamDto>($"SELECT * FROM dbo.vTeam");

                        response.Total = await connection
                            .QueryFirstOrDefaultAsync<int>($"SELECT COUNT(*) FROM dbo.vTeam ");
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

        public async Task<DeleteEntityResponse> RemoveTeamMember(DeleteEntityRequest request)
        {
            var response = new DeleteEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request,
                Success = true
            };

            try
            {
                var entity = await _dbContext.EmployeeTeams
                 .SingleAsync(x => x.Employee == request.EntityId 
                                         && x.IsCurrent == true 
                                         && x.Active == true);

                entity.Active = false;
                entity.DateTo = DateTimeOffset.UtcNow;

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
                _logger.LogError(ex, "SharedRepository.RemoveTeamMember: Request={@Request}", request);
            }

            return response;
        }

    }
}
