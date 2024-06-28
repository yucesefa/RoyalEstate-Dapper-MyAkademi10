using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.AdvertDtos;

namespace DapperProject.Services.AdvertServices
{
    public class AdvertService : IAdvertService
    {
        private readonly DapperContext _dapperContext;

        public AdvertService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<Last4AdvertDto>> GetLast4AdvertAsync()
        {
            string query = "select AdvertId,ImageUrl,Title,AdvertType,Price,AdvertStatus,Description,M2,RoomCount,BathroomCount,LocationName\r\nFrom(select top 4 AdvertId,ImageUrl,Title,AdvertType,Price,AdvertStatus,Description,M2,RoomCount,BathroomCount,LocationName\r\nfrom TblAdvert inner join TblLocation on \r\nTblAdvert.LocationId=TblLocation.LocationId order by \r\nAdvertId desc) as subquery\r\norder by AdvertId asc";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<Last4AdvertDto>(query);
            return values.ToList();
        }

        public async Task<List<Last6AdvertDto>> GetLast6AdvertAsync()
        {
            string query = "select AdvertId,ImageUrl,Title,AdvertType,Price,AdvertStatus,LocationName\r\nFrom(select top 6 AdvertId,ImageUrl,Title,AdvertType,Price,AdvertStatus,LocationName\r\nfrom TblAdvert inner join TblLocation on \r\nTblAdvert.LocationId=TblLocation.LocationId order by \r\nAdvertId desc) as subquery\r\norder by AdvertId asc";
            var connection = _dapperContext.CreateConnection();
            var values  = await connection.QueryAsync<Last6AdvertDto>(query);
            return values.ToList();
        }
    }
}
