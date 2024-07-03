using DapperProject.Dtos.AgentDtos;

namespace DapperProject.Services.AgentServices
{
	public interface IAgentService
	{
		Task<int> GetAllAgentCountAsync();
		Task<List<ResultAgentDto>> GetAllAgentsAsync();
	}
}
