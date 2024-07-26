
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

        public async Task CreateAgentAsync(CreateAgentDto createAgentDto)
        {
			string query = "insert into TblAgent (AgentName,AgentSurname,Description,ImageUrl) values (@agentname,@agentsurname,@description,@imageurl)";
			var parameters = new DynamicParameters();
			parameters.Add("@agentname", createAgentDto.AgentName);
			parameters.Add("@agentsurname", createAgentDto.AgentSurname);
			parameters.Add("@description", createAgentDto.Description);
			parameters.Add("@imageurl", createAgentDto.ImageUrl);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAgentAsync(int id)
        {
			string query = "delete from TblAgent where AgentId=@agentid";
            var parameters = new DynamicParameters();
            parameters.Add("@agentid",id);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query,parameters);

        }

        public async Task<GetByIdAgentDto> GetAgentAsync(int id)
        {
			string query = "select * from TblAgent Where AgentId=@agentid";
			var parameters = new DynamicParameters();
			parameters.Add("agentid", id);
			var connection = _context.CreateConnection();
			var values =await connection.QueryFirstOrDefaultAsync<GetByIdAgentDto>(query,parameters);
			return values;
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

        public async Task UpdateAgentAsync(UpdateAgentDto updateAgentDto)
        {
			string query = "update TblAgent Set AgentName=@agentname,AgentSurname=@agentsurname,Description=@description,ImageUrl=@imageurl where AgentId=@agentid";
			var parameters = new DynamicParameters();
			parameters.Add("@agentname", updateAgentDto.AgentName);
			parameters.Add("@agentsurname", updateAgentDto.AgentSurname);
			parameters.Add("@description", updateAgentDto.Description);
			parameters.Add("@imageurl", updateAgentDto.ImageUrl);
			parameters.Add("@agentid", updateAgentDto.AgentId);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
        }
    }
}
