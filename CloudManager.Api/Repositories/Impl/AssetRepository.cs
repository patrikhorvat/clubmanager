using CloudManager.Api.DtoObjects;
using CloudManager.Api.Entities;
using CloudManager.Api.Helpers;
using CloudManager.Api.Mapping;
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
                               .QueryAsync<AssetDto>($"SELECT * FROM dbo.vAsset ORDER BY Id DESC");

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

        public async Task<GetEntityResponse<AssetDto>> GetAsset(GetEntityRequest request)
        {
            var response = new GetEntityResponse<AssetDto>()
            {
                Request = request,
                ResponseToken = Guid.NewGuid(),
                Success = true
            };

            try
            {
                var e = await _dbContext.Assets
                  .Include(x => x.UserCreatedNavigation)
                  .Include(x => x.UserLastModifiedNavigation)
                  .Include(x => x.StatusNavigation)
                  .Include(x => x.TypeNavigation)
                  .SingleAsync(p => p.Id == request.EntityId && p.Active == true);

                var entity = new AssetDto()
                {
                    Id = e.Id,
                    Club = e.Club.GetValueOrDefault(),
                    DateCreated = e.DateCreated,
                    LastModified = e.LastModified,
                    StatusColor = e.StatusNavigation.Color,
                    StatusId = e.StatusNavigation.Id,
                    StatusName = e.StatusNavigation.Name,
                    UserCreatedId = e.UserCreated,
                    UserLastModifiedId = e.UserLastModified,
                    Condition = e.Condition,
                    Description = e.Description,
                    Name = e.Name,
                    Type = e.Type
                };

                if (e != null && e.UserCreatedNavigation != null)
                {
                    entity.UserCreatedDisplayName = e.UserCreatedNavigation.FirstName;
                }

                if (e != null && e.UserLastModifiedNavigation != null)
                {
                    entity.UserLastModifiedDisplayName = e.UserLastModifiedNavigation.FirstName;
                }

                if (e != null && e.TypeNavigation != null)
                {
                    entity.AssetTypeName = e.TypeNavigation.Name;
                }

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

        public async Task<ManageEntityResponse<ManageEntityRequest<AssetDto>>> CreateAsset(ManageEntityRequest<AssetDto> request)
        {
            var response = new ManageEntityResponse<ManageEntityRequest<AssetDto>>()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request,
                Success = true
            };

            try
            {
                var dto = request.Dto;

                var entity = new Entities.Asset()
                {
                    DateCreated = dto.DateCreated,
                    UserCreated = dto.UserCreatedId.GetValueOrDefault(),
                    Description = dto.Description,
                    Name = dto.Name,
                    Club = dto.Club,
                    Type = dto.Type.GetValueOrDefault(),
                    Condition = dto.Condition,
                    Status = dto.StatusId.GetValueOrDefault(),
                    Active = true
                };

                await _dbContext.Assets.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                response.EntityId = entity.Id;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<ManageEntityResponse<ManageEntityRequest<AssetDto>>> UpdateAsset(ManageEntityRequest<AssetDto> request)
        {
            var response = new ManageEntityResponse<ManageEntityRequest<AssetDto>>()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request,
                Success = true
            };

            try
            {
                var dto = request.Dto;

                var entity = await _dbContext.Assets.SingleAsync(x => x.Id == dto.Id);

                entity.UserLastModified = dto.UserLastModifiedId;
                entity.Description = dto.Description;
                entity.Name = dto.Name;
                entity.Condition = dto.Condition;
                entity.Type = dto.Type.GetValueOrDefault();
                entity.LastModified = dto.LastModified;

                _dbContext.Assets.Update(entity);
                await _dbContext.SaveChangesAsync();

                response.EntityId = entity.Id;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
            }

            return response;
        }

        public async Task<List<AssetTypeDto>> GetAssetTypes()
        {
            var result = new List<AssetTypeDto>();
            var languages = await _dbContext.AssetTypes.ToListAsync();

            if (languages == null)
                return result;

            result.AddRange(languages.Select(l => l.MapToResult()));

            return result;
        }

        public async Task<DeleteEntityResponse> DeleteAsset(DeleteEntityRequest request)
        {
            var response = new DeleteEntityResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request,
                Success = true
            };

            try
            {
                var entity = await _dbContext.Assets
               .SingleAsync(x => x.Id == request.EntityId);

                entity.Active = false;
                entity.LastModified = DateTimeOffset.UtcNow;
                entity.UserLastModified = request.AuthInfo.UserId;

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.GetBaseException().Message;
                _logger.LogError(ex, "AssetRepository.DeleteAsset: Request={@Request}", request);
            }

            return response;
        }

    }
}
