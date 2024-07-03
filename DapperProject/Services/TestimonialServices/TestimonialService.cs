
using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.TestimonialDtos;

namespace DapperProject.Services.TestimonialServices
{
	public class TestimonialService : ITestimonialService
	{
		private readonly DapperContext _context;

		public TestimonialService(DapperContext context)
		{
			_context = context;
		}

		public async Task<int> GetAllTestimonialCountAsync()
		{
			string query = "select count(*) from TblTestimonial";
			var connection = _context.CreateConnection();
			int value = await connection.QueryFirstOrDefaultAsync<int>(query);
			return value;
		}

		public async Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync()
		{
			string query = "select * from TblTestimonial";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultTestimonialDto>(query);
			return values.ToList();
		}
	}
}
