using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.TagDtos;

namespace DapperProject.Services.TagServices
{
    public class TagService : ITagService
    {
        private readonly DapperContext _dapperContext;

        public TagService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<ResultTagDto>> GetAllTagAsync()
        {
            string query = "select * from TblTag";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultTagDto>(query);
            return values.ToList();
        }

        public async Task CreateTagAsync(CreateTagDto createTagDto)
        {
            string query = "insert into TblTag (TagName) values (@tagname)";
            var parameters = new DynamicParameters();
            parameters.Add("@tagname", createTagDto.TagName);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTagAsync(int id)
        {
            string query = "delete from TblTag where TagId=@tagid";
            var parameters = new DynamicParameters();
            parameters.Add("@tagid", id);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task<GetByIdTagDto> GetTagAsync(int id)
        {
            string query = "select * from TblTag Where TagId=@tagid";
            var parameters = new DynamicParameters();
            parameters.Add("tagid", id);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdTagDto>(query, parameters);
            return values;
        }
        public async Task UpdateTagAsync(UpdateTagDto updateTagDto)
        {
            string query = "update TblTag Set TagName=@tagname where TagId=@tagid";
            var parameters = new DynamicParameters();
            parameters.Add("@tagname", updateTagDto.TagName);
            parameters.Add("@tagid", updateTagDto.TagId);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
