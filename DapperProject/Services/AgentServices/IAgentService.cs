using DapperProject.Dtos.AgentDtos;

namespace DapperProject.Services.AgentServices
{
	public interface IAgentService
	{
		Task<int> GetAllAgentCountAsync();
		Task<List<ResultAgentDto>> GetAllAgentsAsync();
		Task CreateAgentAsync(CreateAgentDto createAgentDto);
		Task DeleteAgentAsync(int id);
		Task UpdateAgentAsync(UpdateAgentDto updateAgentDto);
		Task<GetByIdAgentDto> GetAgentAsync(int id);
	}
}
