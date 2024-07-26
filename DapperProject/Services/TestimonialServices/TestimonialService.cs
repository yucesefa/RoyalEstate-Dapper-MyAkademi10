
using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.TestimonialDtos;
using DapperProject.Dtos.TestimonialDtos;

namespace DapperProject.Services.TestimonialServices
{
	public class TestimonialService : ITestimonialService
	{
		private readonly DapperContext _dapperContext;

		public TestimonialService(DapperContext context)
		{
			_dapperContext = context;
		}

		public async Task<int> GetAllTestimonialCountAsync()
		{
			string query = "select count(*) from TblTestimonial";
			var connection = _dapperContext.CreateConnection();
			int value = await connection.QueryFirstOrDefaultAsync<int>(query);
			return value;
		}

		public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
		{
			string query = "select * from TblTestimonial";
			var connection = _dapperContext.CreateConnection();
			var values = await connection.QueryAsync<ResultTestimonialDto>(query);
			return values.ToList();
		}

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            string query = "insert into TblTestimonial (NameSurname,Title,Description,ImageUrl) values (@nameSurname,@title,@description,@imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@nameSurname", createTestimonialDto.NameSurname);
            parameters.Add("@title", createTestimonialDto.Title);
            parameters.Add("@description", createTestimonialDto.Description);
            parameters.Add("@imageUrl", createTestimonialDto.ImageUrl);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            string query = "delete from TblTestimonial where TestimonialId=@testimonialid";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialid", id);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task<GetByIdTestimonialDto> GetTestimonialAsync(int id)
        {
            string query = "select * from TblTestimonial Where TestimonialId=@testimonialid";
            var parameters = new DynamicParameters();
            parameters.Add("testimonialid", id);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(query, parameters);
            return values;
        }
        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            string query = "update TblTestimonial Set NameSurname=@nameSurname,Title=@title,Description=@description,ImageUrl=@imageUrl where TestimonialId=@testimonialid";
            var parameters = new DynamicParameters();
            parameters.Add("@nameSurname", updateTestimonialDto.NameSurname);
            parameters.Add("@title", updateTestimonialDto.Title);
            parameters.Add("@description", updateTestimonialDto.Description);
            parameters.Add("@imageUrl", updateTestimonialDto.ImageUrl);
            parameters.Add("@testimonialid", updateTestimonialDto.TestimonialId);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
