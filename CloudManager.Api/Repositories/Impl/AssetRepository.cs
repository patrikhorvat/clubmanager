using CloudManager.Api.DtoObjects;
using CloudManager.Api.Entities;
using CloudManager.Api.Helpers;
using CloudManager.Api.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CloudManager.Api.Repositories.Impl
{
    public class AssetRepository : IAssetRepository
    {

        private readonly ILogger<EmployeeRepository> _logger;
        private readonly ClubManagerContext _dbContext;
        private readonly IConfigurationHelper _configurationHelper;

        public AssetRepository(
            ClubManagerContext dbContext,
            ILogger<EmployeeRepository> logger,
            IConfigurationHelper configurationHelper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _configurationHelper = configurationHelper;
        }

        public async Task<Asset?> FindById(int id)
        {
            return await _dbContext.Assets
              .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<CountEntityResponse> GetAssetCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.Assets
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

        public async Task<CountEntityResponse> GetAssetBallCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.Assets
                    .Include(x => x.TypeNavigation)
                          .Where(u => u.Active == true && u.TypeNavigation.Label == "BALL")
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

        public async Task<CountEntityResponse> GetAssetGoalCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.Assets
                    .Include(x => x.TypeNavigation)
                          .Where(u => u.Active == true && u.TypeNavigation.Label == "GOAL")
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

        public async Task<CountEntityResponse> GetAssetYerseyCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.Assets
                    .Include(x => x.TypeNavigation)
                          .Where(u => u.Active == true && u.TypeNavigation.Label == "YERSEY")
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

        public async Task<CountEntityResponse> GetAssetMachineCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.Assets
                    .Include(x => x.TypeNavigation)
                          .Where(u => u.Active == true && u.TypeNavigation.Label == "MACHINE")
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

        public async Task<CountEntityResponse> GetAssetRestCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.Assets
                    .Include(x => x.TypeNavigation)
                          .Where(u => u.Active == true && u.TypeNavigation.Label == "REST")
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

        public async Task<CountEntityResponse> GetAssetBrokenCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.Assets
                    .Include(x => x.StatusNavigation)
                          .Where(u => u.Active == true && u.StatusNavigation.Label == "BROKEN")
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
        public async Task<CountEntityResponse> GetAssetSocksCount(CountEntityRequest request)
        {
            var response = new CountEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };
            try
            {
                var c = await _dbContext.Assets
                    .Include(x => x.TypeNavigation)
                          .Where(u => u.Active == true && u.TypeNavigation.Label == "SOCKS")
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

        public async Task<OverviewResponse<AssetDto>> AssetOverview(OverviewRequest request)
        {
            var response = new OverviewResponse<AssetDto>()
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
                            .QueryAsync<AssetDto>($"SELECT * FROM dbo.vAsset {request.QueryParams.WhereClause} {request.QueryParams.OrderByClause} ");

                        response.Total = await connection
                            .QueryFirstOrDefaultAsync<int>($"SELECT COUNT(*) FROM dbo.vAsset {request.QueryParams.WhereClause}");
                    }
                    else
                    {
                        response.Data = await connection
                               .QueryAsync<AssetDto>($"SELECT * FROM dbo.vAsset");

                        response.Total = await connection
                            .QueryFirstOrDefaultAsync<int>($"SELECT COUNT(*) FROM dbo.vAsset ");
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
