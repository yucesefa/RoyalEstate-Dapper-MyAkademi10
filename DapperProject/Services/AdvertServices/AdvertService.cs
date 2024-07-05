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

        public async Task<GetByIdAdvertDto> GetByIdAdvertAsync(int id)
        {
            string query = "select  AdvertId,ImageUrl1,Title,CategoryName,Price,AdvertStatus,Description,M2,RoomCount,BathroomCount,LocationName from TblAdvert\r\ninner join TblCategory on \r\nTblAdvert.CategoryId=TblCategory.CategoryId\r\ninner join TblLocation on\r\nTblAdvert.LocationId=TblLocation.LocationId\r\ninner join TblImage on\r\nTblAdvert.ImageId =TblImage.ImageId\r\nwhere AdvertId=@advertId";
            var parameters = new DynamicParameters();
            parameters.Add("@advertId", id);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdAdvertDto>(query, parameters);
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

        public async Task<List<GetListSearchAdvertDto>> GetListSearchAdvertAsync(string word, int location, float minPrice, float maxPrice,int category)
        {
            string query = "";
            if (location > 0 )
            {
                query = "SELECT \r\n    AdvertId,\r\n    ImageUrl1,\r\n    Title,\r\n    LocationName,\r\n    Description,\r\n    CategoryName,\r\n    AdvertStatus,\r\n    RoomCount,\r\n    BathroomCount,\r\n    Price,\r\n    M2,\r\n    VideoEmbed \r\nFROM \r\n    TblAdvert\r\nINNER JOIN \r\n    TblImage ON TblAdvert.ImageId = TblImage.ImageId\r\nINNER JOIN \r\n    TblLocation ON TblAdvert.LocationId = TblLocation.LocationId\r\nINNER JOIN \r\n    TblCategory ON TblAdvert.CategoryId = TblCategory.CategoryId\r\nWHERE \r\n    Title LIKE '%' + @word + '%' \r\n    AND TblAdvert.LocationId = @location \r\n    AND TblAdvert.CategoryId = @category \r\n    AND Price >= @minPrice \r\n    AND Price <= @maxPrice;";
            }
            else
            {
                query = "select AdvertId,ImageUrl1,Title,LocationName,Description,CategoryName,AdvertStatus,RoomCount,BathroomCount,Price,M2,VideoEmbed from TblAdvert\r\ninner join TblImage on\r\nTblAdvert.ImageId=TblImage.ImageId\r\ninner join TblLocation on\r\nTblAdvert.LocationId=TblLocation.LocationId\r\ninner join TblCategory on\r\nTblAdvert.CategoryId=TblCategory.CategoryId\r\nwhere Title Like '%' + @word +'%' and (TblAdvert.CategoryId=@category)  and (Price >= @minPrice and Price <=@maxPrice)";
            }
            var parameters = new DynamicParameters();
            parameters.Add("@word", word);
            parameters.Add("@location", location);
            parameters.Add("@category", category);
            parameters.Add("@minPrice", minPrice);
            parameters.Add("@maxPrice", maxPrice);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<GetListSearchAdvertDto>(query,parameters);
            return values.ToList();
        }
        public async Task<float> GetMaxPrice()
        {
            string query = "select Top 1 Price from TblAdvert order by Price Desc";
            var connection = _dapperContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<float> GetMinPrice()
        {
            string query = "select Top 1 Price from TblAdvert order by Price asc";
            var connection = _dapperContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
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
    }
}
