using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.AdvertDtos;
using DapperProject.Dtos.SliderDtos;

namespace DapperProject.Services.AdvertServices
{
    public class AdvertService : IAdvertService
    {
        private readonly DapperContext _dapperContext;

        public AdvertService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateAdvertAsync(CreateAdvertDto createAdvertDto)
        {
            string query = "Insert into TblAdvert (ImageId,Title,LocationId,TagId,Description,CategoryId,AdvertStatus,AgentId,RoomCount,BathroomCount,Price,M2,VideoEmbed) values (@imageId,@title,@locationId,@tagId,@description,@categoryId,@advertStatus,@agentId,@roomCount,@bathroomCount,@price,@m2,@videoEmbed)";
            var parameters = new DynamicParameters();
            parameters.Add("@imageId", createAdvertDto.ImageId);
            parameters.Add("@title", createAdvertDto.Title);
            parameters.Add("@locationId", createAdvertDto.LocationId);
            parameters.Add("@tagId", createAdvertDto.TagId);
            parameters.Add("@description", createAdvertDto.Description);
            parameters.Add("@categoryId", createAdvertDto.CategoryId);
            parameters.Add("@advertStatus", createAdvertDto.AdvertStatus);
            parameters.Add("@agentId", createAdvertDto.AgentId);
            parameters.Add("@roomCount", createAdvertDto.RoomCount);
            parameters.Add("@bathroomCount", createAdvertDto.BathroomCount);
            parameters.Add("@price", createAdvertDto.Price);
            parameters.Add("@m2", createAdvertDto.M2);
            parameters.Add("@videoEmbed", createAdvertDto.VideoEmbed);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAdvertAsync(int id)
        {
            string query = "delete from TblAdvert Where AdvertId=@advertId";
            var parameters = new DynamicParameters();
            parameters.Add("@advertId", id);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task<GetByIdAdvertDto> GetAdvertAsync(int id)
        {
            string query = "select AdvertId,TblImage.ImageId,Title,TblCategory.CategoryId,TblTag.TagId,TblAgent.AgentId,Price,AdvertStatus,TblAdvert.Description,M2,RoomCount,BathroomCount,TblLocation.LocationId from TblAdvert inner join TblCategory on TblAdvert.CategoryId=TblCategory.CategoryId inner join TblImage on TblAdvert.ImageId=TblImage.ImageId inner join TblLocation on TblAdvert.LocationId=TblLocation.LocationId inner join TblTag on TblAdvert.TagId=TblTag.TagId inner join TblAgent on TblAdvert.AgentId=TblAgent.AgentId where AdvertId=@advertId";
            var parameters = new DynamicParameters();
            parameters.Add("@advertId", id);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdAdvertDto>(query, parameters);
            return values;
        }

        public async Task<int> GetAdvertCount()
        {
            string query = "select Count(*) from TblAdvert";
            var connection = _dapperContext.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<List<GetAdvertDetailCategoryCount>> GetAdvertDetailCategoryCountsAsync()
        {
            string query = "\r\nSELECT CategoryName, COUNT(AdvertId) as CategoryCount\r\nFROM TblAdvert \r\nINNER JOIN TblCategory  ON TblAdvert.CategoryId = TblCategory.CategoryId\r\nGROUP BY CategoryName ORDER BY CategoryCount DESC;";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<GetAdvertDetailCategoryCount>(query);
            return values.ToList();
        }

        public async Task<GetByIdAdvertDetailDto> GetByIdAdvertAsync(int id)
        {
            string query = "select AdvertId,ImageUrl1,ImageUrl2,ImageUrl3,Title,CategoryName,TagId,AgentId,Price,AdvertStatus,Description,M2,RoomCount,BathroomCount,LocationName from TblAdvert\r\ninner join TblCategory on \r\nTblAdvert.CategoryId=TblCategory.CategoryId\r\ninner join TblLocation on\r\nTblAdvert.LocationId=TblLocation.LocationId\r\ninner join TblImage on\r\nTblAdvert.ImageId =TblImage.ImageId\r\nwhere AdvertId=@advertId";
            var parameters = new DynamicParameters();
            parameters.Add("@advertId", id);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdAdvertDetailDto>(query, parameters);
            return values;
        }

        public async Task<List<Last2AdvertDto>> GetLast2AdvertAsync()
        {
            string query = "select AdvertId,ImageUrl1,Title,CategoryName,Price,AdvertStatus,Description,M2,RoomCount,BathroomCount,LocationName\r\nFrom(select top 2 AdvertId,ImageUrl1,Title,CategoryName,Price,AdvertStatus,Description,M2,RoomCount,BathroomCount,LocationName\r\nfrom TblAdvert inner join TblLocation on \r\nTblAdvert.LocationId=TblLocation.LocationId inner join TblCategory on TblAdvert.CategoryId=TblCategory.CategoryId inner join TblImage on TblAdvert.ImageId=TblImage.ImageId order by \r\nAdvertId desc) as subquery\r\norder by AdvertId asc";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<Last2AdvertDto>(query);
            return values.ToList();
        }

        public async Task<List<Last4AdvertDto>> GetLast4AdvertAsync()
        {
            string query = "select AdvertId,ImageUrl1,Title,CategoryName,Price,AdvertStatus,Description,M2,RoomCount,BathroomCount,LocationName\r\nFrom(select top 4 AdvertId,ImageUrl1,Title,CategoryName,Price,AdvertStatus,Description,M2,RoomCount,BathroomCount,LocationName\r\nfrom TblAdvert inner join TblLocation on \r\nTblAdvert.LocationId=TblLocation.LocationId inner join TblCategory on TblAdvert.CategoryId=TblCategory.CategoryId inner join TblImage on TblAdvert.ImageId=TblImage.ImageId order by \r\nAdvertId desc) as subquery\r\norder by AdvertId asc";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<Last4AdvertDto>(query);
            return values.ToList();
        }

        public async Task<List<Last6AdvertDto>> GetLast6AdvertAsync()
        {
            string query = "select AdvertId,ImageUrl1,Title,CategoryName,Price,AdvertStatus,LocationName\r\nFrom(select top 6 AdvertId,ImageUrl1,Title,CategoryName,Price,AdvertStatus,LocationName\r\nfrom TblAdvert inner join TblLocation on \r\nTblAdvert.LocationId=TblLocation.LocationId inner join TblCategory on TblAdvert.CategoryId=TblCategory.CategoryId inner join TblImage on TblAdvert.ImageId=TblImage.ImageId order by \r\nAdvertId desc) as subquery\r\norder by AdvertId asc";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<Last6AdvertDto>(query);
            return values.ToList();
        }

        public async Task<List<GetListSearchAdvertDto>> GetListSearchAdvertAsync(int location,int category)
        {
            string query = "SELECT AdvertId,ImageUrl1,Title,LocationName,Description,CategoryName,AdvertStatus,RoomCount,BathroomCount,Price,M2,VideoEmbed FROM TblAdvert INNER JOIN TblImage\r\nON TblAdvert.ImageId = TblImage.ImageId INNER JOIN TblLocation ON TblAdvert.LocationId = TblLocation.LocationId INNER JOIN TblCategory\r\nON TblAdvert.CategoryId = TblCategory.CategoryId WHERE TblAdvert.LocationId = @location And TblAdvert.CategoryId =@category";

            var parameters = new DynamicParameters();
            parameters.Add("@location", location);
            parameters.Add("@category", category);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<GetListSearchAdvertDto>(query,parameters);
            return values.ToList();
        }

        public async Task<List<ResultAdvertDto>> GetResultAdvertAsync()
        {
            string query = "\r\nselect AdvertId,ImageUrl1,Title,LocationName,Description,CategoryName,AdvertStatus,RoomCount,BathroomCount,Price,M2 FROM TblAdvert inner join\r\nTblCategory on\r\nTblAdvert.CategoryId=TblCategory.CategoryId \r\ninner join TblLocation on\r\nTblAdvert.LocationId=TblLocation.LocationId\r\ninner join TblImage on\r\nTblAdvert.ImageId=TblImage.ImageId";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultAdvertDto>(query);
            return values.ToList();
        }

        public async Task<List<ResultSliderDto>> GetResultSliderAdvertAsync()
        {
            string query = "\r\nselect AdvertId,ImageUrl1,Title,LocationName,Description,Price FROM TblAdvert \r\ninner join TblLocation on\r\nTblAdvert.LocationId=TblLocation.LocationId\r\ninner join TblImage on\r\nTblAdvert.ImageId=TblImage.ImageId";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultSliderDto>(query);
            return values.ToList();
        }

        public async Task UpdateAdvertAsync(UpdateAdvertDto updateAdvertDto)
        {
            string query = "Update TblAdvert Set ImageId=@imageId,Title=@title,LocationId=@locationId,TagId=@tagId,Description=@description,CategoryId=@categoryId,AdvertStatus=@advertStatus,AgentId=@agentId,RoomCount=@roomCount,BathroomCount=@bathRoomCount,Price=@price,M2=@m2,VideoEmbed=@videoEmbed where AdvertId=@advertId";
            var parameters = new DynamicParameters();
            parameters.Add("@advertId", updateAdvertDto.AdvertId);
            parameters.Add("@imageId", updateAdvertDto.ImageId);
            parameters.Add("@title", updateAdvertDto.Title);
            parameters.Add("@locationId", updateAdvertDto.LocationId);
            parameters.Add("@tagId", updateAdvertDto.TagId);
            parameters.Add("@description", updateAdvertDto.Description);
            parameters.Add("@categoryId", updateAdvertDto.CategoryId);
            parameters.Add("@advertStatus", updateAdvertDto.AdvertStatus);
            parameters.Add("@agentId", updateAdvertDto.AgentId);
            parameters.Add("@roomCount", updateAdvertDto.RoomCount);
            parameters.Add("@bathRoomCount", updateAdvertDto.BathroomCount);
            parameters.Add("@price", updateAdvertDto.Price);
            parameters.Add("@m2", updateAdvertDto.M2);
            parameters.Add("@videoEmbed", updateAdvertDto.VideoEmbed);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
