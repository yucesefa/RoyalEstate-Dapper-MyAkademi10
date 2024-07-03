
using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.AgentDtos;

namespace DapperProject.Services.AgentServices
{
	public class AgentService : IAgentService
	{
		private readonly DapperContext _context;

		public AgentService(DapperContext context)
		{
			_context = context;
		}

		public async Task<int> GetAllAgentCountAsync()
		{
			string query = "select count(*) from TblAgent";
			var connection = _context.CreateConnection();
			int value = await connection.QueryFirstOrDefaultAsync<int>(query);
			return value;

		}

		public async Task<List<ResultAgentDto>> GetAllAgentsAsync()
		{
			string query = "select * from TblAgent";
			var connections = _context.CreateConnection();
			var value = await connections.QueryAsync<ResultAgentDto>(query);
			return value.ToList();
		}
	}
}
