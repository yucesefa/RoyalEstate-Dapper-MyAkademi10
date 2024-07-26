namespace DapperProject.Dtos.AgentDtos
{
    public class UpdateAgentDto
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentSurname { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
